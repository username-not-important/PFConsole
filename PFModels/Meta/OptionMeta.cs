using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Meta
{
    public class OptionMeta : INotifyPropertyChanged
    {
        public string Key { get; set; }
        public string Code { get; set; }
        public string Text { get; set; }
        public string Group { get; set; }
        public string Tooltip { get; set; }
        public string Default { get; set; }

        public bool CanUseMultiple { get; set; }

        public ObservableCollection<object> Options { get; set; }
        public bool ContainsOptions { get; set; }
        public bool FreeInput { get; set; }

        public List<string> Rules { get; set; }

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