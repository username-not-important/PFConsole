using System;
using System.Collections.Generic;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public enum SchedulerType
    {
        HFSC,
        CBQ,
        PriQ
    };

    public class OldQueue : INotifyPropertyChanged
    {
        private string _name;
        private string _bandwidth;
        private int _priority;
        private int _qLimit;
        private SchedulerType _scheduler;
        private List<string> _options;
        private List<string> _queueList;

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
        public string Bandwidth
        {
            get { return _bandwidth; }
            set
            {
                if (value == _bandwidth) return;
                _bandwidth = value;
                OnPropertyChanged("Bandwidth");
            }
        }
        public int Priority
        {
            get { return _priority; }
            set
            {
                if (value == _priority) return;
                _priority = value;
                OnPropertyChanged("Priority");
            }
        }
        public int QLimit
        {
            get { return _qLimit; }
            set
            {
                if (value == _qLimit) return;
                _qLimit = value;
                OnPropertyChanged("QLimit");
            }
        }
        public SchedulerType Scheduler
        {
            get { return _scheduler; }
            set
            {
                if (value == _scheduler) return;
                _scheduler = value;
                OnPropertyChanged("Scheduler");
            }
        }
        public List<string> Options
        {
            get { return _options; }
            set
            {
                if (Equals(value, _options)) return;
                _options = value;
                OnPropertyChanged("Options");
            }
        }
        public List<string> QueueList
        {
            get { return _queueList; }
            set
            {
                if (Equals(value, _queueList)) return;
                _queueList = value;
                OnPropertyChanged("QueueList");
            }
        }

        public OldQueue()
        {
            Bandwidth = "100%";
            Priority = 1;
            QLimit = 50;
            Scheduler = SchedulerType.HFSC;

            QueueList = new List<string>();
            Options = new List<string>();
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

    public class Queue : INotifyPropertyChanged
    {
        private string _name;
        private SchedulerType _schedulerType;
        private QueueContent _content;

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
        public SchedulerType SchedulerType
        {
            get { return _schedulerType; }
            set
            {
                _schedulerType = value;

                OnPropertyChanged("SchedulerType");

                switch (value)
                {
                    case SchedulerType.HFSC:
                        Content = new HFSCContent();
                        break;
                    case SchedulerType.CBQ:
                        Content = new CBQContent();
                        break;
                    case SchedulerType.PriQ:
                        Content = new PriQContent();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException("value");
                }
            }
        }

        public QueueContent Content
        {
            get { return _content; }
            set
            {
                if (Equals(value, _content)) return;
                _content = value;
                OnPropertyChanged("Content");
            }
        }

        public Queue()
        {
            SchedulerType = SchedulerType.HFSC;
            Name = "New Queue";
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