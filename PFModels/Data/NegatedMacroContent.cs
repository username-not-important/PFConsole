using System;
using System.ComponentModel;
using PFModels.Annotations;

namespace PFModels.Data
{
    public class NegatedMacroContent : MacroContent, INotifyPropertyChanged
    {
        public MacroContent Content { get; set; }

        public NegatedMacroContent()
        {}

        public NegatedMacroContent(MacroContent content)
        {
            Content = content;
        }

        public override bool Equals(object obj)
        {
            if (obj as NegatedMacroContent != null) return (obj as NegatedMacroContent).Content.Equals(Content);

            return false;
        }

        public override Type GetContentType()
        {
            return Content.GetContentType();
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

        public override string GetInlineDefinition(bool quotes)
        {
            return "!" + Content.GetInlineDefinition(quotes);
        }
    }
}