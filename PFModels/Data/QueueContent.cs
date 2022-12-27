using System;
using System.ComponentModel;
using System.Xml.Serialization;
using PFModels.Annotations;

namespace PFModels.Data
{
    public enum BandwidthUnit
    {
        [Description("b")]
        bps,
        [Description("Kb")]
        Kbps,
        [Description("Mb")]
        Mbps,
        [Description("Gb")]
        Gbps,
        [Description("%")] Percent
    }

    public class BandwidthValue : INotifyPropertyChanged
    {
        private double _value;
        private BandwidthUnit _unit;

        public double Value
        {
            get { return _value; }
            set
            {
                if (value.Equals(_value)) return;
                _value = value;
                OnPropertyChanged("Value");
            }
        }
        public BandwidthUnit Unit
        {
            get { return _unit; }
            set
            {
                if (value == _unit) return;
                _unit = value;
                OnPropertyChanged("Unit");
            }
        }

        public BandwidthValue()
        {
            Value = 100.0;
            Unit = BandwidthUnit.Percent;
        }

        public override string ToString()
        {
            return Value + " " + Unit.GetDescription<BandwidthUnit>();
        }

        public static bool TryParse(string input, out BandwidthValue result)
        {
            result = null;
            try
            {
                if (string.IsNullOrWhiteSpace(input)) return false;

                input = input.Replace(" ", "");

                int i = 0;
                for (i = 0; i < input.Length; i++)
                    if (! char.IsDigit(input[i]) && input[i] != '.')
                        break;

                if (i == 0) return false;

                double value;
                if (! Double.TryParse(input.Substring(0, i), out value))
                    return false;

                string utext = input.Substring(i).Replace("%", "Percent");
                BandwidthUnit unit = (BandwidthUnit) Enum.Parse(typeof(BandwidthUnit), utext, true);

                result = new BandwidthValue
                {
                    Value = value,
                    Unit = unit
                };

                return true;
            }
            catch (Exception e)
            {
                return false;
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

        public bool IsUntouched
        {
            get { return Value == 100 && Unit == BandwidthUnit.Percent; }
        }
    }

    [XmlInclude(typeof(HFSCContent))]
    [XmlInclude(typeof(CBQContent))]
    [XmlInclude(typeof(PriQContent))]
    public abstract class QueueContent
    {
    }

    public class TrippleData : INotifyPropertyChanged
    {
        private string _m1;
        private string _m2;
        private string _d;
        private bool _isEnabled;

        public string M1
        {
            get { return _m1; }
            set
            {
                if (value == _m1) return;
                _m1 = value;
                OnPropertyChanged("M1");
            }
        }
        public string M2
        {
            get { return _m2; }
            set
            {
                if (value == _m2) return;
                _m2 = value;
                OnPropertyChanged("M2");
            }
        }
        public string D
        {
            get { return _d; }
            set
            {
                if (value == _d) return;
                _d = value;
                OnPropertyChanged("D");
            }
        }

        public bool IsEnabled
        {
            get { return _isEnabled; }
            set
            {
                if (value.Equals(_isEnabled)) return;
                _isEnabled = value;
                OnPropertyChanged("IsEnabled");
            }
        }

        public override string ToString()
        {
            return string.Format("( {0} {1} {2} )", M1, D, M2);
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

    public class HFSCContent : QueueContent, INotifyPropertyChanged
    {
        private BandwidthValue _bandwidth;
        private int _length;
        private int _priority;
        private bool _linearServiceCurve;
        private TrippleData _upperLimit;
        private TrippleData _realTime;
        private TrippleData _linkShare;

        public BandwidthValue Bandwidth
        {
            get { return _bandwidth; }
            set
            {
                if (Equals(value, _bandwidth)) return;
                _bandwidth = value;
                OnPropertyChanged("Bandwidth");
            }
        }
        public int Length
        {
            get { return _length; }
            set
            {
                if (value == _length) return;
                _length = value;
                OnPropertyChanged("Length");
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
        public bool LinearServiceCurve
        {
            get { return _linearServiceCurve; }
            set
            {
                if (value.Equals(_linearServiceCurve)) return;
                _linearServiceCurve = value;
                OnPropertyChanged("LinearServiceCurve");
            }
        }

        public TrippleData UpperLimit
        {
            get { return _upperLimit; }
            set
            {
                if (Equals(value, _upperLimit)) return;
                _upperLimit = value;
                OnPropertyChanged("UpperLimit");
            }
        }
        public TrippleData RealTime
        {
            get { return _realTime; }
            set
            {
                if (Equals(value, _realTime)) return;
                _realTime = value;
                OnPropertyChanged("RealTime");
            }
        }
        public TrippleData LinkShare
        {
            get { return _linkShare; }
            set
            {
                if (Equals(value, _linkShare)) return;
                _linkShare = value;
                OnPropertyChanged("LinkShare");
            }
        }

        public HFSCContent()
        {
            Bandwidth = new BandwidthValue();
            Priority = 1;
            Length = 50;

            UpperLimit = new TrippleData();
            RealTime = new TrippleData();
            LinkShare = new TrippleData();
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

    public class CBQContent : QueueContent, INotifyPropertyChanged
    {
        private BandwidthValue _bandwidth;
        private int _length;
        private int _priority;
        private bool _borrow;

        public BandwidthValue Bandwidth
        {
            get { return _bandwidth; }
            set
            {
                if (Equals(value, _bandwidth)) return;
                _bandwidth = value;
                OnPropertyChanged("Bandwidth");
            }
        }
        public int Length
        {
            get { return _length; }
            set
            {
                if (value == _length) return;
                _length = value;
                OnPropertyChanged("Length");
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
        public bool Borrow
        {
            get { return _borrow; }
            set
            {
                if (value.Equals(_borrow)) return;
                _borrow = value;
                OnPropertyChanged("Borrow");
            }
        }

        public CBQContent()
        {
            Bandwidth = new BandwidthValue();
            Priority = 1;
            Length = 50;
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

    public class PriQContent : QueueContent, INotifyPropertyChanged
    {
        private int _length;
        private int _priority;

        public int Length
        {
            get { return _length; }
            set
            {
                if (value == _length) return;
                _length = value;
                OnPropertyChanged("Length");
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

        public PriQContent()
        {
            Length = 50;
            Priority = 1;
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