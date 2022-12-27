using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using PFConsole.Project;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for EnterDiagramNameWindow.xaml
    /// </summary>
    public partial class EnterDiagramNameWindow : Window
    {
        public EnterDiagramNameWindow()
        {
            InitializeComponent();
        }

        private bool _canceled = true;

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {}

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_TB_Name.Text))
            {
                _ErrorText.Text = "You must assign a name.";
                _ErrorBlock.Visibility = Visibility.Visible;

                e.CanExecute = false;
                return;
            }

            if (PFProject.Instance.Diagrams.Diagrams.FirstOrDefault(d => d.Name.ToLower() == _TB_Name.Text.ToLower()) != null)
            {
                _ErrorText.Text = "Another Diagram with this name exists.";
                _ErrorBlock.Visibility = Visibility.Visible;

                e.CanExecute = false;
                return;
            }

            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _canceled = false;
            Close();
        }

        public static bool Prompt(out string name)
        {
            EnterDiagramNameWindow win = new EnterDiagramNameWindow();
            win.ShowDialog();

            name = win._TB_Name.Text;
            return win._canceled;
        }
    }
}