using System;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class Macro : MacroContent, INotifyPropertyChanged
    {
        private string _name;
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

        public override Type GetContentType()
        {
            return Content.GetContentType();
        }

        public override string GetInlineDefinition(bool quotes)
        {
            string reference = "$" + Name;

            return quotes ? string.Format("\" {0} \"", reference) : reference;
        }

        public override bool Equals(object obj)
        {
            if (obj as Macro == null) return false;
            return (obj as Macro).Name == Name;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}