using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using PFConsole.Project;
using PFConsole.VisualResources;
using PFModels.Data;
using PFModels.Data.Validation;
using PFModels.Data.Validation.Rules;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for AssignMacroWindow.xaml
    /// </summary>
    public partial class AssignMacroWindow : Window
    {
        public AssignMacroWindow()
        {
            InitializeComponent();
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            string error = "";

            if (!Validator.Validate(_TB_MacroName.Text, out error, new MacroNameValidator()))
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = error;

                return;
            }

            if (_ListInput.SelectedItems.Count == 0)
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = "You have to define the value for macro.";

                return;
            }

            _ErrorBlock.Visibility = Visibility.Collapsed;
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PFProject.Instance.Macros.AssignMacro(_TB_MacroName.Text, getContent());
            Close();
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PFProject.Instance.Macros.AssignMacro(_TB_MacroName.Text, getContent());

            _ListInput.SelectedItems = new ObservableCollection<MacroContent>();
        }

        private MacroContent getContent()
        {
            if (_ListInput.SelectedItems.Count == 1)
                return _ListInput.SelectedItems[0];

            return new PFList
            {
                Items = _ListInput.SelectedItems
            };
        }

        private bool _TB_Type_HandleSelectionChanged = true;

        private void _TB_Type_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (_TB_Type_HandleSelectionChanged)
            {
                if (_ListInput.SelectedItems.Count != 0)
                {
                    var prompt = JMessageBox.Show("You have items added to the Macro Value. If you change the type, They'll be removed. Are you sure?", "Change Macro type", MessageBoxButton.YesNo);
                    if (prompt == MessageBoxResult.No)
                    {
                        _TB_Type_HandleSelectionChanged = false;
                        (sender as ComboBox).SelectedItem = e.RemovedItems[0];

                        return;
                    }
                }
            }

            _TB_Type_HandleSelectionChanged = true;
        }
    }
}