using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using PFConsole.Annotations;
using PFConsole.ChildWindows;
using PFConsole.Logs;
using PFConsole.Project.DataHelpers;
using PFConsole.Properties;
using PFConsole.VisualResources;
using PFModels.Data;

namespace PFConsole.Project
{
    public class MacroRepository : INotifyPropertyChanged
    {
        public ObservableCollection<Macro> Macros { get; set; }

        public MacroRepository()
        {
            Macros = new ObservableCollection<Macro>();
        }

        public Macro this[string name]
        {
            get { return Macros.FirstOrDefault(m => m.Name == name); }
        }

        public Macro this[MacroContent content]
        {
            get { return Macros.FirstOrDefault(m => m.Content.Equals(content)); }
        }

        public void AssignMacro(string name, MacroContent content)
        {
            Macro macro = new Macro();
            macro.Name = name;
            macro.Content = content;

            if (this[name] != null)
            {
                if (PromptRemoveMacro())
                {
                    RemoveMacro(name);
                    addMacro(macro);

                    return;
                }
                return;
            }

            var find = this[content];
            if (find != null)
            {
                if (PromptRemoveContent())
                {
                    RemoveMacro(find);
                    addMacro(macro);

                    return;
                }
                return;
            }

            addMacro(macro);
        }

        private void addMacro(Macro macro)
        {
            Macros.Add(macro);
            Logger.Instance.Log(String.Format("Macro {0} Assigned to {1} .", macro.Name, macro.Content));

            PFProject.Instance.RequiresSave = true;
        }

        private bool PromptRemoveMacro()
        {
            var prompt = JMessageBox.Show(Resources.MacroRepository_PromptRemoveMacro_Message,
                "Duplicate Macro", MessageBoxButton.YesNo, MessageBoxImage.Warning, MessageBoxOptions.None);

            return prompt == MessageBoxResult.Yes;
        }

        private bool PromptRemoveContent()
        {
            var prompt = JMessageBox.Show(Resources.MacroRepository_PromptRemove_Message,
                "Duplicate Object", MessageBoxButton.YesNo, MessageBoxImage.Question);

            return prompt == MessageBoxResult.Yes;
        }

        private void CommitRemoveMacro(Macro macro)
        {
            Macros.Remove(macro);

            Logger.Instance.Log(String.Format("Macro {0} was Deleted.", macro.Name));
            PFProject.Instance.RequiresSave = true;
        }

        public void RemoveMacro(Macro macro)
        {
            TraverseMacroHelper helper = new TraverseMacroHelper();
            var usages = helper.GetMacroUsage(PFProject.Instance, macro);

            if (usages.Count != 0)
                RemoveMacroPrompt.Prompt(macro, usages);
            else
                CommitRemoveMacro(macro);
        }

        public void RemoveMacro(string name)
        {
            var find = this[name];
            if (find != null) RemoveMacro(find);
        }

        public void RemoveMacro(MacroContent content)
        {
            var find = this[content];
            if (find != null)
                RemoveMacro(find);
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