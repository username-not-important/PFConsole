using System;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class Interface : MacroContent, INotifyPropertyChanged, ICloneable
    {
        private string _name;
        private string _description;

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
        public string Description
        {
            get { return _description; }
            set
            {
                if (value == _description) return;
                _description = value;
                OnPropertyChanged("Description");
            }
        }

        public override string ToString()
        {
            return "Interface " + Name + (!String.IsNullOrEmpty(Description) ? String.Format("(" + Description + ")") : "");
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

        public object Clone()
        {
            return new Interface
            {
                Name = Name, Description = Description
            };
        }

        public override bool Equals(object obj)
        {
            if (obj as Interface == null) return false;
            return (obj as Interface).Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override Type GetContentType()
        {
            return typeof(Interface);
        }

        public override string GetInlineDefinition(bool quotes)
        {
            return Name;
        }
    }
}