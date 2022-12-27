using System.ComponentModel;
using System.Xml.Serialization;
using PFModels.Annotations;
using PFModels.Meta;
using PFModels.Repositories;

namespace PFModels.Data
{
    public class Option : INotifyPropertyChanged
    {
        private string _value;

        [XmlIgnore]
        public OptionMeta Meta { get; private set; }

        public string Key
        {
            get { return Meta.Key; }
            set { loadItem(value); }
        }
        public string Value
        {
            get { return _value; }
            set
            {
                if (value == _value) return;
                _value = value;
                OnPropertyChanged("Value");
            }
        }

        public Option(string optionKey)
        {
            Key = optionKey;
        }

        public Option()
        {}

        private void loadItem(string key)
        {
            Meta = OptionsMetaRepository.GetItem(key);
            Value = Meta.Default;
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