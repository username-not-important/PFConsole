using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Infragistics.Windows.DockManager;
using PFConsole.Annotations;
using PFConsole.ChildWindows;
using PFConsole.Logs;
using PFConsole.Project;
using PFConsole.ViewModels;
using PFConsole.VisualResources;
using PFModels.Data;
using PFModels.Repositories;

namespace PFConsole.ContentPages
{
    /// <summary>
    ///     Interaction logic for ViewOptionsPage.xaml
    /// </summary>
    public partial class ViewOptionsPage : INotifyPropertyChanged
    {
        private static ViewOptionsPage _instance;

        private ObservableCollection<OptionVM> _allOptions;
        public ObservableCollection<OptionVM> AllOptions
        {
            get { return _allOptions; }
            set
            {
                if (Equals(value, _allOptions)) return;
                _allOptions = value;
                OnPropertyChanged("AllOptions");
            }
        }

        internal static void SetDisplayMode(string mode)
        {
            _instance._optionsTabControl.SelectedIndex = mode == "List" ? 0 : 1;
        }

        internal static void SetFontBase(double size)
        {
            if (_instance != null)
            {
                _instance.Resources["Options_FontSizeBase"] = size;
                _instance.Resources["Options_FontSizeDrop"] = size - 3;
            }
        }

        internal static void SetGrouppingMode(string mode)
        {
            if (mode == "None")
                (_instance.Resources["GrouppedOptionsSource"] as CollectionViewSource).GroupDescriptions.Clear();
            else
            {
                (_instance.Resources["GrouppedOptionsSource"] as CollectionViewSource).GroupDescriptions.Clear();
                (_instance.Resources["GrouppedOptionsSource"] as CollectionViewSource).GroupDescriptions.Add(new PropertyGroupDescription(mode));
            }
        }

        public ViewOptionsPage()
        {
            _instance = this;

            AllOptions = new ObservableCollection<OptionVM>();

            InitializeComponent();

            PFProject.Instance.Options.ModifiedOptions.CollectionChanged += (sender, args) => Update();
            Update();
        }

        public ViewOptionsPage(int n) : this()
        {}

        private void Update()
        {
            AllOptions.Clear();
            foreach (var option in PFProject.Instance.Options.ModifiedOptions)
                AllOptions.Add(new OptionVM {OptionModel = option});

            foreach (var meta in OptionsMetaRepository.GetMetas())
            {
                if (AllOptions.FirstOrDefault(op => op.OptionModel.Meta.Key == meta.Key) != null) continue;

                Option o = new Option(meta.Key);
                AllOptions.Add(new OptionVM {OptionModel = o});
            }

            OnPropertyChanged("AllOptions");
        }

        private void _OptionItem_Modify(object sender, RoutedEventArgs e)
        {
            string key = ((sender as Control).Tag).ToString();

            WindowManager.CreateWindow<ModifyOptionWindow>(true, key);
        }

        private void _OptionItem_Reset(object sender, RoutedEventArgs e)
        {
            Option option = ((sender as Control).Tag as Option);

            if (!WindowManager.GetPermission<ModifyOptionWindow>(option.Key))
            {
                JMessageBox.Show("The modify option Window for this option is already open. Reset the value from there.");
                return;
            }

            PFProject.Instance.Options.RemoveSetting(option);

            Logger.Instance.Log(string.Format("Option {0} Changed to {1}.", option.Meta.Text, option.Meta.Default));
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

        private void ViewOptionsPage_OnLoaded(object sender, RoutedEventArgs e)
        {
            var pane = Tag as ContentPane;
            pane.TabHeader = "Options";
        }
    }
}