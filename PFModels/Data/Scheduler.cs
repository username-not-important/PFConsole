using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class Scheduler : INotifyPropertyChanged
    {
        private SchedulerType _type;
        private BandwidthValue _totalBandwidth;
        private string _defaultQueue;
        private string _name;

        public SchedulerType Type
        {
            get { return _type; }
            set
            {
                if (value == _type) return;
                _type = value;
                OnPropertyChanged("Type");
            }
        }
        public BandwidthValue TotalBandwidth
        {
            get { return _totalBandwidth; }
            set
            {
                if (Equals(value, _totalBandwidth)) return;
                _totalBandwidth = value;
                OnPropertyChanged("TotalBandwidth");
            }
        }

        public string DefaultQueue
        {
            get { return _defaultQueue; }
            set
            {
                if (value == _defaultQueue) return;
                _defaultQueue = value;
                OnPropertyChanged("DefaultQueue");
            }
        }
        public string Name
        {
            get { return _name; }
            set
            {
                if (value == _name) return;
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public Scheduler()
        {
            Type = SchedulerType.HFSC;
            TotalBandwidth = new BandwidthValue();
            Name = "";
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