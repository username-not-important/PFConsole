using System;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class FileIPAddressList : IPAddress, INotifyPropertyChanged
    {
        private string _fileName;
        public string FileName
        {
            get { return _fileName; }
            set
            {
                if (value == _fileName) return;
                _fileName = value;
                OnPropertyChanged("FileName");
            }
        }

        public override Type GetContentType()
        {
            return typeof(FileIPAddressList);
        }

        public override string GetInlineDefinition(bool quotes)
        {
            return "\"" + FileName + "\"";
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