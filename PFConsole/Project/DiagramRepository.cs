using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Infragistics.Controls.Charts;
using PFConsole.Annotations;
using PFConsole.Logs;
using PFConsole.Util.Diagram;
using PFModels.Data;

namespace PFConsole.Project
{
    public class DiagramRepository : INotifyPropertyChanged
    {
        public ObservableCollection<DiagramInfo> Diagrams { get; set; }

        public DiagramRepository()
        {
            Diagrams = new ObservableCollection<DiagramInfo>();
        }

        public DiagramInfo this[string name]
        {
            get { return Diagrams.FirstOrDefault(d => d.Name == name); }
        }

        public void SaveDiagram(XamDiagram diagram, string diagramName)
        {
            DiagramPersistenceManager man = new DiagramPersistenceManager();
            var data = man.Serialize(diagram);

            if (this[diagramName] != null)
                this[diagramName].Data = data;
            else
                Diagrams.Add(new DiagramInfo {Data = data, Name = diagramName});

            Logger.Instance.Log(string.Format("Diagram {0} Saved.", diagramName));
            PFProject.Save();
        }

        public void RestoreDiagram(XamDiagram diagram, string diagramName)
        {
            var info = this[diagramName];

            DiagramPersistenceManager man = new DiagramPersistenceManager();
            man.DeserializeAndLoad(diagram, info.Data);

            Logger.Instance.Log(string.Format("Diagram {0} Was restored to the last saved version.", diagramName));
        }

        public void RemoveDiagram(DiagramInfo d)
        {
            RemoveDiagram(d.Name);
        }

        public void RemoveDiagram(string name)
        {
            var find = this[name];
            if (find != null)
            {
                Diagrams.Remove(find);
                PFProject.Instance.Diagrams.RemoveDiagram(find);

                Logger.Instance.Log(String.Format("Diagram {0} was Deleted.\n[This operation requires project to be saved. if it was a mistake close project without saving it.]", find));
                PFProject.Instance.RequiresSave = true;
            }
        }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion
    }
}