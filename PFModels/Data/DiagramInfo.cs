using System;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class DiagramInfo : INotifyPropertyChanged, ICloneable
    {
        private string _data;
        private string _name;

        public string Data
        {
            get { return _data; }
            set
            {
                if (value == _data) return;
                _data = value;
                OnPropertyChanged("Data");
            }
        }
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
            return new DiagramInfo
            {
                Data = Data,
                Name = Name
            };
        }
    }
}