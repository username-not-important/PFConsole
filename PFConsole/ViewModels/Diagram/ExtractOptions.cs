using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using PFConsole.Annotations;
using PFConsole.Util.Diagram;

namespace PFConsole.ViewModels.Diagram
{
    public class ExtractOptions : INotifyPropertyChanged
    {
        private bool _extractAsMacro;
        private string _extractName;

        [Configurable("ExtractAsMacro", typeof(bool), "Extract Options", "Extract as Macro", "Define where to use as Inline text in PF Rule or extract as macro.", false)]
        [DefaultValue(false)]
        public bool ExtractAsMacro
        {
            get { return _extractAsMacro; }
            set
            {
                if (value.Equals(_extractAsMacro)) return;
                _extractAsMacro = value;
                OnPropertyChanged("ExtractAsMacro");
                OnPropertyChanged("IsChanged");
            }
        }

        [Configurable("ExtractName", typeof(string), "Extract Options", "Macro Name", "Set the extracted macro name.", false)]
        [DefaultValue("")]
        public string ExtractName
        {
            get { return _extractName; }
            set
            {
                if (value == _extractName) return;
                _extractName = value.Replace("$", "");
                OnPropertyChanged("ExtractName");
                OnPropertyChanged("IsChanged");
            }
        }

        
        public bool IsChanged
        {
            get { return ExtractAsMacro || ExtractName != ""; }
        }

        public ExtractOptions()
        {
            ExtractName = "";
        }

        public void Reset()
        {
            ExtractAsMacro = false;
            ExtractName = "";
        }

        public string Text
        {
            get { return ToString(); }
        }

        public override string ToString()
        {
            return !ExtractAsMacro ? "-" : "$" + ExtractName;
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
