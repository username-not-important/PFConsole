using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PFConsole.Annotations;
using PFConsole.Logs;
using PFModels.Data;

namespace PFConsole.Project
{
    public class TableRepository : INotifyPropertyChanged
    {
        public ObservableCollection<Table> Tables { get; set; }

        public TableRepository()
        {
            Tables = new ObservableCollection<Table>();
        }

        public Table this[string name]
        {
            get { return Tables.FirstOrDefault(t => t.Name == name); }
        }

        public void AddTable(Table t)
        {
            Tables.Add(t);
            Logger.Instance.Log(String.Format("Table {0} Added.", t.Name));

            PFProject.Instance.RequiresSave = true;
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