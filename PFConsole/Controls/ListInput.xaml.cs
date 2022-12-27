using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using PFConsole.Annotations;
using PFConsole.Project;
using PFModels.Data;
using PFModels.Data.Validation;
using PFModels.Data.Validation.Rules;

namespace PFConsole.Controls
{
    /// <summary>
    ///     Interaction logic for ListInput.xaml
    /// </summary>
    public partial class ListInput : INotifyPropertyChanged
    {
        #region DependencyProperties

        public static readonly DependencyProperty SelectedItemsProperty = DependencyProperty.Register(
            "SelectedItems", typeof(ObservableCollection<MacroContent>), typeof(ListInput), new PropertyMetadata());

        public static readonly DependencyProperty InputTypeProperty = DependencyProperty.Register(
            "InputType", typeof(string), typeof(ListInput), new FrameworkPropertyMetadata(InputTypeChangedCallback));

        public static readonly DependencyProperty ShowMacrosProperty = DependencyProperty.Register(
            "ShowMacros", typeof(bool), typeof(ListInput), new PropertyMetadata(true));

        private static void InputTypeChangedCallback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            (sender as ListInput).UpdateInputTypeRequirements(e.NewValue.ToString());
        }

        #endregion

        public bool ShowMacros
        {
            get { return (bool) GetValue(ShowMacrosProperty); }
            set { SetValue(ShowMacrosProperty, value); }
        }

        public class AssignmentItem
        {
            public string Value { get; set; }
            public string Group { get; set; }

            public AssignmentItem()
            {}

            public AssignmentItem(string value, string group)
            {
                Value = value;
                Group = group;
            }
        }

        #region MacroOptions

        private ObservableCollection<AssignmentItem> _options;
        public ObservableCollection<AssignmentItem> Options
        {
            get { return _options; }
            set
            {
                if (Equals(value, _options)) return;
                _options = value;
                OnPropertyChanged("Options");
            }
        }

        private void UpdateInputTypeRequirements(string newValue)
        {
            _InputBox.Options = new List<string>();
            SelectedItems.Clear();

            PFProject.Instance.Interfaces.Interfaces.CollectionChanged -= (sender, args) => UpdateInterfaceData();
            PFProject.Instance.Macros.Macros.CollectionChanged -= (sender, args) => UpdateInterfaceData();
            PFProject.Instance.Macros.Macros.CollectionChanged -= (sender, args) => UpdateIPAddressData();
            PFProject.Instance.Macros.Macros.CollectionChanged -= (sender, args) => UpdateHostNameData();
            PFProject.Instance.Macros.Macros.CollectionChanged -= (sender, args) => UpdatePortNumberData();

            if (newValue == "Interface(s)")
            {
                UpdateInterfaceData();

                PFProject.Instance.Interfaces.Interfaces.CollectionChanged += (sender, args) => UpdateInterfaceData();
                PFProject.Instance.Macros.Macros.CollectionChanged += (sender, args) => UpdateInterfaceData();
            }
            else if (newValue == "IP Address(es)")
            {
                UpdateIPAddressData();

                PFProject.Instance.Macros.Macros.CollectionChanged += (sender, args) => UpdateIPAddressData();
            }
            else if (newValue == "Host Name(s)")
            {
                UpdateHostNameData();

                PFProject.Instance.Macros.Macros.CollectionChanged += (sender, args) => UpdateHostNameData();
            }
            else if (newValue == "Port Value(s)")
            {
                UpdatePortNumberData();

                PFProject.Instance.Macros.Macros.CollectionChanged += (sender, args) => UpdatePortNumberData();
            }
        }

        private void UpdateInterfaceData()
        {
            List<AssignmentItem> source = new List<AssignmentItem>();

            if (!ShowMacros)
                return;

            source.AddRange(PFProject.Instance.Macros.Macros.Where(m => m.Content.GetContentType() == typeof(Interface)).
                Select(m => new AssignmentItem("$" + m.Name, "Macros")));

            source.AddRange(PFProject.Instance.Interfaces.Interfaces.Select(i => new AssignmentItem(i.Name, "Interfaces")));

            _InputBox.DisplayMemberPath = "Value";
            _InputBox.FreeInput = true;
            _InputBox.ShowCombobox = true;

            Options = new ObservableCollection<AssignmentItem>(source);

            ListCollectionView lv = new ListCollectionView(source);
            lv.GroupDescriptions.Add(new PropertyGroupDescription("Group"));

            _InputBox.Options = lv;
        }

        private void UpdateIPAddressData()
        {
            List<AssignmentItem> source = new List<AssignmentItem>();

            if (!ShowMacros)
                return;

            source.AddRange(PFProject.Instance.Macros.Macros.Where(m => m.Content.GetContentType() == typeof(IPv4Address)).
                Select(m => new AssignmentItem("$" + m.Name, "Macros")));

            _InputBox.DisplayMemberPath = "Value";
            _InputBox.FreeInput = true;
            _InputBox.ShowCombobox = true;

            Options = new ObservableCollection<AssignmentItem>(source);

            ListCollectionView lv = new ListCollectionView(source);
            lv.GroupDescriptions.Add(new PropertyGroupDescription("Group"));

            _InputBox.Options = lv;
        }

        private void UpdateHostNameData()
        {
            List<AssignmentItem> source = new List<AssignmentItem>();

            if (!ShowMacros)
                return;

            source.AddRange(PFProject.Instance.Macros.Macros.Where(m => m.Content.GetContentType() == typeof(HostName)).
                Select(m => new AssignmentItem("$" + m.Name, "Macros")));

            _InputBox.DisplayMemberPath = "Value";
            _InputBox.FreeInput = true;
            _InputBox.ShowCombobox = true;

            Options = new ObservableCollection<AssignmentItem>(source);

            ListCollectionView lv = new ListCollectionView(source);
            lv.GroupDescriptions.Add(new PropertyGroupDescription("Group"));

            _InputBox.Options = lv;
        }

        private void UpdatePortNumberData()
        {
            List<AssignmentItem> source = new List<AssignmentItem>();

            if (!ShowMacros)
                return;

            source.AddRange(PFProject.Instance.Macros.Macros.Where(m => m.Content.GetContentType() == typeof(PortValue)).
                Select(m => new AssignmentItem("$" + m.Name, "Macros")));

            _InputBox.DisplayMemberPath = "Value";
            _InputBox.FreeInput = true;
            _InputBox.ShowCombobox = true;

            Options = new ObservableCollection<AssignmentItem>(source);

            ListCollectionView lv = new ListCollectionView(source);
            lv.GroupDescriptions.Add(new PropertyGroupDescription("Group"));

            _InputBox.Options = lv;
        }

        #endregion

        public string InputType
        {
            get { return (string) GetValue(InputTypeProperty); }
            set { SetValue(InputTypeProperty, value); }
        }

        public ObservableCollection<MacroContent> SelectedItems
        {
            get { return (ObservableCollection<MacroContent>) GetValue(SelectedItemsProperty); }
            set { SetValue(SelectedItemsProperty, value); }
        }

        public List<IValidator> ValidationRules
        {
            get
            {
                switch (InputType)
                {
                    case "IP Address(es)":
                        return new List<IValidator> {new IPv4SubnetValidator()};
                    case "Interface(s)":
                        return new List<IValidator> {new InterfaceNameValidator()};
                    case "Port Value(s)":
                        return new List<IValidator> {new NonEmptyTextValidator()};
                    case "Host Name(s)":
                        return new List<IValidator> {new NonEmptyTextValidator()};
                    default:
                        return new List<IValidator> {new NonEmptyTextValidator()};
                }
            }
        }

        public ListInput()
        {
            SetValue(SelectedItemsProperty, new ObservableCollection<MacroContent>());

            InitializeComponent();
        }

        private void AddCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            string error = "";
            if (_ErrorBlock == null)
            {
                e.CanExecute = false;
                return;
            }

            string text = _InputBox.Text;

            if (!Validator.Validate(text, out error, ValidationRules.ToArray()))
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = error;

                return;
            }

            if (InputType == "Interface(s)" && Options != null && Options.FirstOrDefault(item => item.Value == text) == null)
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = "You have to choose a valid macro/interface as value.";

                return;
            }

            if (SelectedItems.FirstOrDefault(c => c.Equals(GetEnteredValue())) != null)
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = "You have already added this Item.";

                return;
            }

            if (InputType == "IP Address(es)" && (text[0] == '$' && Options != null && Options.FirstOrDefault(item => item.Value == text) == null))
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = "You have to enter a valid macro name/ip address as value.";

                return;
            }

            _ErrorBlock.Visibility = Visibility.Collapsed;
            e.CanExecute = true;
        }

        private void AddCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            MacroContent value = GetEnteredValue();

            SelectedItems.Add(value);

            _CB_Negate.IsChecked = false;
            _InputBox.Text = "";
        }

        private void _ListItem_Remove_Click(object sender, RoutedEventArgs e)
        {
            var content = (sender as Button).Tag as MacroContent;
            SelectedItems.Remove(content);
        }

        private MacroContent GetEnteredValue()
        {
            string text = _InputBox.Text;
            if (InputType == "Interface(s)")
            {
                MacroContent content;
                if (text[0] == '$')
                    content = PFProject.Instance.Macros[text.Substring(1)];
                else
                    content = PFProject.Instance.Interfaces[text];

                return (_CB_Negate.IsChecked.GetValueOrDefault() ? new NegatedMacroContent(content) : content);
            }

            if (InputType == "IP Address(es)")
            {
                MacroContent content;
                if (text[0] == '$')
                    content = PFProject.Instance.Macros[text.Substring(1)];
                else
                    content = new IPv4Address {Text = text};

                return (_CB_Negate.IsChecked.GetValueOrDefault() ? new NegatedMacroContent(content) : content);
            }

            if (InputType == "Host Name(s)")
            {
                MacroContent content;

                if (text[0] == '$')
                    content = PFProject.Instance.Macros[text.Substring(1)];
                else
                    content = new HostName {Name = text};

                return (_CB_Negate.IsChecked.GetValueOrDefault() ? new NegatedMacroContent(content) : content);
            }

            if (InputType == "Port Value(s)")
            {
                MacroContent content;

                if (text[0] == '$')
                    content = PFProject.Instance.Macros[text.Substring(1)];
                else
                    content = new PortValue {Port = text};

                return (_CB_Negate.IsChecked.GetValueOrDefault() ? new NegatedMacroContent(content) : content);
            }

            return null;
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