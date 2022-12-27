using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PFModels.Data;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for AssignPortsWindow.xaml
    /// </summary>
    public partial class AssignPortsWindow : Window
    {
        public ObservableCollection<MacroContent> Ports { get; set; }

        public AssignPortsWindow(ObservableCollection<MacroContent> ports)
        {
            Ports = ports;

            InitializeComponent();

            _ListInput.SelectedItems = Ports;
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {}

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }
    }
}