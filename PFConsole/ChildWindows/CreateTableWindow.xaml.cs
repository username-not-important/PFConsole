using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PFConsole.Project;
using PFModels.Data;
using PFModels.Data.Validation;
using PFModels.Data.Validation.Rules;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for CreateTableWindow.xaml
    /// </summary>
    public partial class CreateTableWindow : Window
    {
        public CreateTableWindow()
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

            if (!Validator.Validate(_TB_Name.Text, out error, new NonEmptyTextValidator()))
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = error;

                return;
            }

            if (_Radio_File.IsChecked.GetValueOrDefault() && !Validator.Validate(_TB_FileName.Text, out error, new NonEmptyTextValidator()))
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = error;

                return;
            }

            _ErrorBlock.Visibility = Visibility.Collapsed;
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PFProject.Instance.Tables.AddTable(createTable());
            Close();
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PFProject.Instance.Tables.AddTable(createTable());
        }

        private Table createTable()
        {
            Table t = new Table();
            t.Name = _TB_Name.Text;
            t.Attribute = (_Radio_Attrib_None.IsChecked.GetValueOrDefault() ? "" : (_Radio_Attrib_Const.IsChecked.GetValueOrDefault() ? "const" : "persist"));

            if (_Radio_File.IsChecked.GetValueOrDefault())
                t.Content = new FileIPAddressList {FileName = _TB_FileName.Text};
            else if (_Radio_IPList.IsChecked.GetValueOrDefault())
                t.Content = new PFList {Items = new ObservableCollection<MacroContent>(_ListInput.SelectedItems)};

            return t;
        }
    }
}