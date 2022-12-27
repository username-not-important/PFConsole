using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;
using PFModels.Data;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for AssignIPAddressesWindow.xaml
    /// </summary>
    public partial class AssignIPAddressesWindow : Window
    {
        public ObservableCollection<MacroContent> IPAddresses { get; set; }

        public AssignIPAddressesWindow(ObservableCollection<MacroContent> addresses)
        {
            IPAddresses = addresses;

            InitializeComponent();

            _ListInput.SelectedItems = addresses;
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {}

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            foreach (var item in _ListInput.SelectedItems)
            {
                var address = item as IPv4Address;

                if (address != null) address.Subnet = -1;
            }
            Close();
        }
    }
}