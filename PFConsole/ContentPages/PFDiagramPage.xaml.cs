using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using Infragistics.Controls.Charts;
using Infragistics.Windows.DockManager;
using PFConsole.ChildWindows;
using PFConsole.Project;
using PFConsole.Util.Diagram;
using PFConsole.VisualResources;

namespace PFConsole.ContentPages
{
    /// <summary>
    ///     Interaction logic for PFDiagramPage.xaml
    /// </summary>
    public partial class PFDiagramPage : Page
    {
        private static PFDiagramPage _activeInstance;
        public static PFDiagramPage ActiveInstance
        {
            get { return _activeInstance; }
        }

        public static event EventHandler ActiveInstanceChanged;

        protected void onActiveInstanceChanged()
        {
            if (ActiveInstanceChanged != null)
                ActiveInstanceChanged(this, new EventArgs());
        }

        public string DiagramName { get; set; }

        private static string _auxDiagram = "";
        private static Dictionary<string,string> _auxDictionary = new Dictionary<string, string>();

        public PFDiagramPage(string diagramName)
        {
            DiagramName = diagramName;

            InitializeComponent();

            _Diagram.UndoManager.UndoLimit = 5;

            Unloaded += (sender, args) => saveAux();
        }

        #region ActiveInstanceStuff

        private void Window_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            _activeInstance = ((bool) e.NewValue) ? this : null;
            onActiveInstanceChanged();
        }

        private void PFDiagramPage_OnLostFocus(object sender, RoutedEventArgs e)
        {
            _activeInstance = null;
            onActiveInstanceChanged();
        }

        private void PFDiagramPage_OnGotFocus(object sender, RoutedEventArgs e)
        {
            _activeInstance = this;
            onActiveInstanceChanged();
        }

        private void PFDiagramPage_OnGotMouseCapture(object sender, MouseEventArgs e)
        {
            _activeInstance = this;
            onActiveInstanceChanged();
        }

        #endregion

        private void _Diagram_ConnectionConnected(object sender, DiagramConnectionConnectedEventArgs e)
        {
            string error = "";

            if (e.Connection.StartNode == null || e.Connection.EndNode == null)
                error = "Check both ends of your connection.";

            else if (error == "" && Equals(e.Connection.StartNode, e.Connection.EndNode))
                error = "Cannot connect a node to itself";

            else if (error == "" && !DiagramManager.Instance.IsValidConnection(e.Connection.StartNodeConnectionPointName, e.Connection.EndNodeConnectionPointName))
                error = String.Format("Nodes {0} and {1} cannot connect to each other in that order.", e.Connection.StartNodeConnectionPointName, e.Connection.EndNodeConnectionPointName).Replace("*", "");

            //TODO: Autoconnect the nodes to correct connection point

            //TODO: You can not connect more than one STO node to an Action node

            if (error != "")
            {
                JMessageBox.Show(error, "Diagram Coonection", MessageBoxButton.OK, MessageBoxImage.Error);
                _Diagram.Items.Remove(e.Connection);
            }
        }

        private void _Diagram_ConnectionConnecting(object sender, DiagramConnectionConnectingEventArgs e)
        {}

        private void _Diagram_EditModeEntering(object sender, DiagramEditModeEnteringEventArgs e)
        {
            e.Cancel = true;
        }

        private void _Diagram_OnItemAdded(object sender, DiagramItemAddedEventArgs e)
        {
            var tag = e.Item.Tag;
            if (tag == null)
                return;

            var cons = Assembly.GetExecutingAssembly().GetType("PFConsole.ViewModels.Diagram." + tag + "VM").GetConstructor(new Type[0]);
            e.Item.Content = cons.Invoke(new object[0]);
        }

        private void _Diagram_OnItemAdding(object sender, DiagramItemAddingEventArgs e)
        {
            if (e.Item as DiagramConnection != null)
            {
                e.Item.Stroke = new SolidColorBrush(Color.FromRgb(66, 66, 66));
                e.Item.StrokeThickness = 1;
            }
        }

        private void _Diagram_OnSelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
        {
            DiagramManager.Instance.SelectedDiagramItem = e.AddedItems.Length != 1 ? null : e.AddedItems[0].Content;
        }

        private void _Diagram_NodeMoved(object sender, DiagramNodeMovedEventArgs e)
        {
            double centerX = e.NewPosition.X + e.Node.ActualWidth/2;
            double centerY = e.NewPosition.Y + e.Node.ActualHeight/2;

            double newCenterX = RoundTo(centerX, 20);
            double newCenterY = RoundTo(centerY, 20);

            e.Node.Position = new Point(e.NewPosition.X + (newCenterX - centerX), e.NewPosition.Y + (newCenterY - centerY));
        }

        private int RoundTo(double a, int factor)
        {
            return (int) Math.Round(a/factor)*factor;
        }

        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (DiagramName == "")
            {
                string name = "";
                bool cancel = EnterDiagramNameWindow.Prompt(out name);

                if (cancel) return;

                DiagramName = name;
                var pane = Tag as ContentPane;
                pane.TabHeader = DiagramName + " (diagram)";
            }
            
            if (_auxDictionary.ContainsKey(DiagramName))
                _auxDictionary.Remove(DiagramName);

            PFProject.Instance.Diagrams.SaveDiagram(_Diagram, DiagramName);
        }

        public void SaveDiagram()
        {
            Save_Click(this, null);
        }

        private void saveAux()
        {
            DiagramPersistenceManager man = new DiagramPersistenceManager();
            
            if (_auxDictionary.ContainsKey(DiagramName))
                _auxDictionary[DiagramName] = man.Serialize(_Diagram);
            else
                _auxDictionary.Add(DiagramName, man.Serialize(_Diagram));
        }

        private void Load_Click(object sender, RoutedEventArgs e)
        {
            if (DiagramName == "") return;

            DiagramPersistenceManager man = new DiagramPersistenceManager();
            man.DeserializeAndLoad(_Diagram, PFProject.Instance.Diagrams[DiagramName].Data);
        }

        private void loadAux()
        {
            DiagramPersistenceManager man = new DiagramPersistenceManager();
            //man.DeserializeAndLoad(_Diagram, _auxDiagram);

            if (!_auxDictionary.ContainsKey(DiagramName)) return;

            man.DeserializeAndLoad(_Diagram, _auxDictionary[DiagramName]);
            _auxDictionary.Remove(DiagramName);
        }

        private void PFDiagramPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            var pane = Tag as ContentPane;
            if (DiagramName != "")
            {
                pane.TabHeader = DiagramName + " (diagram)";

                if (!_auxDictionary.ContainsKey(DiagramName))
                    Load_Click(this, new RoutedEventArgs());
                else 
                    loadAux();
            }
            else
                pane.TabHeader = "New Filtering Diagram (diagram)";

            _Diagram.ScaleToFit();
        }
    }
}