using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PFConsole.Annotations;
using PFModels.Data;

namespace PFConsole.Project
{
    public class OptionsRepository : INotifyPropertyChanged
    {
        public ObservableCollection<Option> ModifiedOptions { get; set; }

        public OptionsRepository()
        {
            ModifiedOptions = new ObservableCollection<Option>();
        }

        public Option this[string key]
        {
            get
            {
                var find = ModifiedOptions.FirstOrDefault(o => o.Meta.Key == key);

                if (find != null && !find.Meta.CanUseMultiple)
                    return find;

                find = new Option(key);
                ModifiedOptions.Add(find);

                return find;
            }
        }

        public void RemoveSetting(string key)
        {
            var find = ModifiedOptions.FirstOrDefault(o => o.Meta.Key == key);
            if (find != null)
                RemoveSetting(find);
        }

        public void RemoveSetting(Option option)
        {
            ModifiedOptions.Remove(option);
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