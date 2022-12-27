using System.ComponentModel;
using System.Xml.Serialization;
using PFConsole.Annotations;
using PFConsole.Project;
using PFConsole.Util.Diagram;
using PFModels.Data;

namespace PFConsole.ViewModels.Diagram
{
    public class InterfaceSelectorVM : DiagramVMBase, INotifyPropertyChanged
    {
        private Macro _macroModel;

        [XmlIgnore]
        public Macro MacroModel
        {
            get { return _macroModel; }
            set
            {
                if (Equals(value, _macroModel)) return;
                _macroModel = value;

                OnPropertyChanged("MacroModel");
                OnPropertyChanged("IsMacroNull");
                OnPropertyChanged("Interface");
            }
        }

        [XmlIgnore]
        public bool IsMacroNull
        {
            get { return MacroModel == null; }
        }

        [Configurable("Interface", typeof(string), "Misc", "Interface", "The Name of Macro Assigned with this Nodes Interface.", true)]
        public string Interface
        {
            get { return IsMacroNull ? "" : MacroModel.Name; }
            set
            {
                if (value == "")
                    MacroModel = null;
                else
                {
                    var m = PFProject.Instance.Macros[value];
                    MacroModel = m;
                }
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

        public string Text
        {
            get { return IsMacroNull ? "" : "$" + Interface; }
        }
    }
}