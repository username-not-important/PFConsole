using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Xml.Serialization;
using Infragistics.Controls.Charts;
using PFConsole.ViewModels.Diagram;

namespace PFConsole.Util.Diagram
{
    public class DiagramPersistenceManager
    {
        public string Serialize(XamDiagram diagram)
        {
            List<DiagramNodeData> itemDatas = new List<DiagramNodeData>();
            List<DiagramConnectionData> connDatas = new List<DiagramConnectionData>();

            int j = 0;
            for (int i = 0; i < diagram.Items.Count; i++)
            {
                var item = diagram.Items[i];
                if (item is DiagramNode)
                {
                    DiagramNodeData data = new DiagramNodeData
                    {
                        Content = item.Content as DiagramVMBase,
                        Width = item.ActualWidth,
                        Height = item.ActualHeight,
                        ItemTag = item.Tag.ToString(),
                        Position = new Point(item.Bounds.Left, item.Bounds.Top),
                        id = j++,
                        node = item as DiagramNode
                    };

                    itemDatas.Add(data);
                }
            }

            foreach (var item in diagram.Items.OfType<DiagramConnection>())
            {
                DiagramConnectionData data = new DiagramConnectionData
                {
                    Start = itemDatas.FindIndex(d => Equals(d.node, item.StartNode)),
                    StartPoint = item.StartNodeConnectionPointName,
                    End = itemDatas.FindIndex(d => Equals(d.node, item.EndNode)),
                    EndPoint = item.EndNodeConnectionPointName
                };

                connDatas.Add(data);
            }

            string serialize = TextSerializer.XmlSerializeToString(new DiagramData
            {
                ItemDatas = itemDatas, ConnDatas = connDatas
            });
            //File.WriteAllText(Environment.CurrentDirectory + "\\diagram.pfd", serialize);

            return serialize;
        }

        public void DeserializeAndLoad(XamDiagram _Diagram, string text)
        {
            //string text = File.ReadAllText(Environment.CurrentDirectory + "\\diagram.pfd");
            DiagramData datas = TextSerializer.XmlDeserializeFromString<DiagramData>(text);

            foreach (var data in datas.ItemDatas)
                data.Content.FixSerializationIssues();

            _Diagram.Items.Clear();

            foreach (var data in datas.ItemDatas)
            {
                var tag = data.ItemTag;

                DiagramNode node = new DiagramNode();
                node.Style = Application.Current.Resources[tag + "ItemStyle"] as Style;
                node.Content = data.Content;
                node.Position = data.Position;
                node.Width = data.Width;
                node.Height = data.Height;

                _Diagram.Items.Add(node);
            }

            foreach (var connData in datas.ConnDatas)
            {
                DiagramConnection con = new DiagramConnection();
                con.StartNodeConnectionPointName = connData.StartPoint;
                con.StartNode = _Diagram.Items[connData.Start] as DiagramNode;
                con.EndNodeConnectionPointName = connData.EndPoint;
                con.EndNode = _Diagram.Items[connData.End] as DiagramNode;

                con.Stroke = new SolidColorBrush(Color.FromRgb(66, 66, 66));
                con.StrokeThickness = 1;

                _Diagram.Items.Add(con);
            }
        }
    }

    public class DiagramData
    {
        public List<DiagramNodeData> ItemDatas { get; set; }
        public List<DiagramConnectionData> ConnDatas { get; set; }
    }

    public class DiagramNodeData
    {
        [XmlIgnore]
        public int id { get; set; }

        [XmlIgnore]
        public DiagramNode node { get; set; }

        public string ItemTag { get; set; }

        public DiagramVMBase Content { get; set; }
        public Point Position { get; set; }

        public double Width { get; set; }
        public double Height { get; set; }
    }

    public class DiagramConnectionData
    {
        public int Start { get; set; }
        public string StartPoint { get; set; }

        public int End { get; set; }
        public string EndPoint { get; set; }
    }
}