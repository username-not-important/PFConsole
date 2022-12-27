using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PFConsole.Annotations;
using PFConsole.Logs;
using PFModels.Data;

namespace PFConsole.Project
{
    public class InterfaceRepository : INotifyPropertyChanged
    {
        public ObservableCollection<Interface> Interfaces { get; set; }

        public InterfaceRepository()
        {
            Interfaces = new ObservableCollection<Interface>();
        }

        public Interface this[string name]
        {
            get { return Interfaces.FirstOrDefault(i => i.Name == name); }
        }

        public void AddInterface(Interface i, string macroName)
        {
            Interfaces.Add(i);
            Logger.Instance.Log(String.Format("Interface {0} Added.", i.Name));

            if (macroName != "")
                PFProject.Instance.Macros.AssignMacro(macroName, i);

            PFProject.Instance.RequiresSave = true;
        }

        public void RemoveInterface(Interface i)
        {
            RemoveInterface(i.Name);
        }

        public void RemoveInterface(string name)
        {
            var find = this[name];
            if (find != null)
            {
                Interfaces.Remove(find);
                PFProject.Instance.Macros.RemoveMacro(find);

                Logger.Instance.Log(String.Format("Interface {0} was Deleted.\n[This operation requires project to be saved. if it was a mistake close project without saving it.]", find));
                PFProject.Instance.RequiresSave = true;
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