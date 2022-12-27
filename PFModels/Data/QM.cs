using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public enum QMMode
    {
        [Description("red")]
        RED,
        [Description("rio")]
        RIO
    }

    public class QM : INotifyPropertyChanged
    {
        private QMMode _mode;
        private bool _ecn;

        public QMMode Mode
        {
            get { return _mode; }
            set
            {
                if (value == _mode) return;
                _mode = value;
                OnPropertyChanged("Mode");
            }
        }
        public bool ECN
        {
            get { return _ecn; }
            set
            {
                if (value.Equals(_ecn)) return;
                _ecn = value;
                OnPropertyChanged("ECN");
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