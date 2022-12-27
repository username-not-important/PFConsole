using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class Table : INotifyPropertyChanged
    {
        private string _name;
        private string _attribute;
        private MacroContent _content;

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
        public string Attribute
        {
            get { return _attribute; }
            set
            {
                if (value == _attribute) return;
                _attribute = value;
                OnPropertyChanged("Attribute");
            }
        }
        public MacroContent Content
        {
            get { return _content; }
            set
            {
                if (Equals(value, _content)) return;
                _content = value;
                OnPropertyChanged("Content");
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