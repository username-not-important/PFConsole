using System.Collections.Generic;
using System.Windows.Input;
using PFModels.Data;

namespace PFConsole.ChildWindows
{
    public partial class RemoveMacroPrompt
    {
        public Macro Target { get; private set; }
        public List<Macro> Dependencies { get; private set; }

        public static void Prompt(Macro target, List<Macro> dependencies)
        {
            RemoveMacroPrompt prompt = new RemoveMacroPrompt(target, dependencies);
            prompt.ShowDialog();
        }

        private RemoveMacroPrompt(Macro target, List<Macro> dependencies)
        {
            Target = target;
            Dependencies = dependencies;

            InitializeComponent();
        }

        private void CloseCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}