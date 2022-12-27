using System.ComponentModel;
using System.Linq;
using Infragistics.DragDrop;
using PFConsole.Annotations;
using PFConsole.Util;
using PFModels.Data;

namespace PFConsole.ViewModels
{
    public class OptionVM : INotifyPropertyChanged, IDragDropHandler
    {
        private Option _optionModel;

        public Option OptionModel
        {
            get { return _optionModel; }
            set
            {
                if (Equals(value, _optionModel)) return;
                _optionModel = value;

                _optionModel.PropertyChanged += (sender, args) =>
                {
                    if (args.PropertyName == "Value")
                        OnPropertyChanged("IsModified");
                };

                OnPropertyChanged("OptionModel");
                OnPropertyChanged("IsModified");
            }
        }
        public bool IsModified
        {
            get { return OptionModel.Value != OptionModel.Meta.Default; }
        }

        public string Group
        {
            get { return OptionModel.Meta.Group; }
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

        public void CommitDrop(DragDropEventArgs e)
        {
            if (e.Data is Interface)
                OptionModel.Value = (e.Data as Interface).Name;
            else if (e.Data is Macro)
            {
                if ((e.Data as Macro).Content.GetContentType() == typeof(Interface))
                    OptionModel.Value = "$" + (e.Data as Macro).Name;
            }
        }

        public bool IsDropTarget(DragDropEventArgs e, params string[] channel)
        {
            if (!(e.Data is Interface) && !((e.Data is Macro) && (e.Data as Macro).GetContentType() == typeof(Interface)))
                return false;

            return (channel.Contains("Interface") || channel.Contains("Macro")) && OptionModel.Key == "Loginterface";
        }
    }
}