using System;
using System.Collections.Generic;
using System.ComponentModel;
using Infragistics.Controls.Charts;
using PFConsole.Annotations;
using PFConsole.ContentPages;

namespace PFConsole.VisualResources
{
    public class DiagramManager : INotifyPropertyChanged
    {
        private XamDiagram _activeDiagram;
        private readonly List<string> _validConnections = new List<string>
        {
            //LTR Traffic
            "InterfaceIN**Filter",
            "InterfaceOUT**Filter",
            "Filter**Action",
            "Action**Mark",
            "Action**Queue",
            "Action**QM",
            "Mark**Queue",
            "Mark**QM",
            "QM**Queue",
            "DEF**Queue",
            "Queue**Scheduler",
            "Queue**InterfaceIN",
            "Queue**InterfaceOUT",
            "Scheduler**Scheduler",
            "Scheduler**InterfaceIN",
            "Scheduler**InterfaceOUT",

            //NonDir
            "STO**ActionSTO",
            "ActionLog**Log",

            //RTL Traffic
            "*InterfaceINFilter*",
            "*InterfaceOUTFilter*",
            "*FilterAction*",
            "*ActionMark*",
            "*ActionQueue*",
            "*ActionQM*",
            "*QMQueue*",
            "*DEFQueue*",
            "*QueueScheduler*",
            "*QueueInterfaceIN*",
            "*QueueInterfaceOUT*",
            "*SchedulerScheduler*",
            "*SchedulerInterfaceIN*",
            "*SchedulerInterfaceOUT*",
        };
        private object _selectedDiagramItem;

        #region Singleton

        private static DiagramManager _instance;
        private static object _lock = true;

        public static DiagramManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new DiagramManager();

                    return _instance;
                }
            }
        }

        #endregion

        public XamDiagram ActiveDiagram
        {
            get { return _activeDiagram; }
            set
            {
                if (Equals(value, _activeDiagram)) return;
                _activeDiagram = value;
                OnPropertyChanged("ActiveDiagram");
                OnPropertyChanged("IsDiagramInView");
            }
        }

        public bool IsDiagramInView
        {
            get { return ActiveDiagram != null; }
        }

        public object SelectedDiagramItem
        {
            get { return _selectedDiagramItem; }
            set
            {
                if (Equals(value, _selectedDiagramItem)) return;
                _selectedDiagramItem = value;
                OnPropertyChanged("SelectedDiagramItem");
            }
        }

        private DiagramManager()
        {
            PFDiagramPage.ActiveInstanceChanged += PfDiagramPageOnActiveInstanceChanged;
        }

        private void PfDiagramPageOnActiveInstanceChanged(object sender, EventArgs eventArgs)
        {
            ActiveDiagram = PFDiagramPage.ActiveInstance != null ? PFDiagramPage.ActiveInstance._Diagram : null;
        }

        public bool IsValidConnection(string startNode, string endNode)
        {
            return _validConnections.Contains(startNode + endNode);
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