using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class PFList : MacroContent, INotifyPropertyChanged
    {
        public ObservableCollection<MacroContent> Items { get; set; }

        #region INPC

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public override Type GetContentType()
        {
            if (Items.Count != 0)
                return Items[0].GetContentType();

            return null;
        }

        public override string GetInlineDefinition(bool quotes)
        {
            string s = Items[0].GetInlineDefinition(quotes);
            for (int i = 1; i < Items.Count; i++)
            {
                s += " " + Items[i].GetInlineDefinition(quotes);
            }
            
            return string.Format("{{ {0} }}", s);
        }
    }
}