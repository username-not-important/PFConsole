using System;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class PortValue : MacroContent, INotifyPropertyChanged
    {
        private string _port;
        public string Port
        {
            get { return _port; }
            set
            {
                if (value == _port) return;
                _port = value;
                OnPropertyChanged("Port");
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

        public override Type GetContentType()
        {
            return typeof(PortValue);
        }

        public override string GetInlineDefinition(bool quotes)
        {
            return Port;
        }

        public override string ToString()
        {
            return Port;
        }
    }
}