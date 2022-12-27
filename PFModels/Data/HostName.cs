using System;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class HostName : MacroContent, INotifyPropertyChanged
    {
        private string _name;
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

        public override Type GetContentType()
        {
            return typeof(HostName);
        }

        public override string GetInlineDefinition(bool quotes)
        {
            return Name;
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

        public override bool Equals(object obj)
        {
            if (obj as HostName == null) return false;
            return (obj as HostName).Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

    }
}