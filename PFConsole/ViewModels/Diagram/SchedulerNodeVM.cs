using System.ComponentModel;
using System.Xml.Serialization;
using PFConsole.Annotations;
using PFConsole.Util.Diagram;
using PFModels.Data;

namespace PFConsole.ViewModels.Diagram
{
    public class SchedulerNodeVM : DiagramVMBase, INotifyPropertyChanged
    {
        private Scheduler _schedulerModel;

        public Scheduler SchedulerModel
        {
            get { return _schedulerModel; }
            set
            {
                if (Equals(value, _schedulerModel)) return;
                _schedulerModel = value;
                OnPropertyChanged("SchedulerModel");
            }
        }

        public SchedulerNodeVM()
        {
            SchedulerModel = new Scheduler();
        }

        [XmlIgnore]
        [Configurable("SchedulerName", typeof(string), "Misc", "Scheduler Name", "The Name of the Scheduler.", false)]
        public string SchedulerName
        {
            get { return SchedulerModel.Name; }
            set { SchedulerModel.Name = value; }
        }

        [XmlIgnore]
        [Configurable("DefaultQueueName", typeof(string), "Misc", "Default Queue Name", "The Name of the Default Queue used for this scheduler.", false)]
        public string DefaultQueueName
        {
            get { return SchedulerModel.DefaultQueue; }
            set
            {
                if (SchedulerModel != null)
                    SchedulerModel.DefaultQueue = value;
            }
        }

        [XmlIgnore]
        [Configurable("BandwidthValue", typeof(string), "Misc", "Total Bandwidth", "The value and unit of total bandwidth.", false)]
        public string BandwidthValue
        {
            get { return SchedulerModel.TotalBandwidth.ToString(); }
            set
            {
                if (SchedulerModel != null)
                {
                    BandwidthValue b;

                    if (!PFModels.Data.BandwidthValue.TryParse(value, out b))
                        return;

                    SchedulerModel.TotalBandwidth = b;
                }
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