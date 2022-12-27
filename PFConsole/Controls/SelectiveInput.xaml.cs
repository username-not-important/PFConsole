using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace PFConsole.Controls
{
    public partial class SelectiveInput : UserControl
    {
        public static readonly DependencyProperty DefaultValueProperty = DependencyProperty.Register(
            "DefaultValue", typeof(object), typeof(SelectiveInput), new PropertyMetadata(default(object)));

        public static readonly DependencyProperty OptionsProperty = DependencyProperty.Register(
            "Options", typeof(IEnumerable), typeof(SelectiveInput), new PropertyMetadata(default(IEnumerable)));

        public static readonly DependencyProperty FreeInputProperty = DependencyProperty.Register(
            "FreeInput", typeof(bool), typeof(SelectiveInput), new PropertyMetadata(default(bool)));

        public static readonly DependencyProperty ItemTemplateProperty = DependencyProperty.Register(
            "ItemTemplate", typeof(DataTemplate), typeof(SelectiveInput), new PropertyMetadata(new ComboBox().ItemTemplate));

        public static readonly DependencyProperty ItemContainerStyleProperty = DependencyProperty.Register(
            "ItemContainerStyle", typeof(Style), typeof(SelectiveInput), new PropertyMetadata(new ComboBox().ItemContainerStyle));

        public static readonly DependencyProperty PanelTemplateProperty = DependencyProperty.Register(
            "PanelTemplate", typeof(ItemsPanelTemplate), typeof(SelectiveInput), new PropertyMetadata(new ComboBox().ItemsPanel));

        public static readonly DependencyProperty ShowComboboxProperty = DependencyProperty.Register(
            "ShowCombobox", typeof(bool), typeof(SelectiveInput), new PropertyMetadata(default(bool), ShowCombobox_Changed_Callback));

        public static readonly DependencyProperty TextProperty = DependencyProperty.Register(
            "Text", typeof(string), typeof(SelectiveInput), new PropertyMetadata("", TextChangedCallback));

        public static readonly DependencyProperty DisplayMemberPathProperty = DependencyProperty.Register(
            "DisplayMemberPath", typeof(string), typeof(SelectiveInput), new PropertyMetadata(default(string)));

        public static readonly DependencyProperty GroupStyleProperty = DependencyProperty.Register(
            "GroupStyle", typeof(GroupStyle), typeof(SelectiveInput), new PropertyMetadata(default(GroupStyle), GroupStyleChangedCallback));

        private static void GroupStyleChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            (dependencyObject as SelectiveInput)._CB.GroupStyle.Clear();
            (dependencyObject as SelectiveInput)._CB.GroupStyle.Add(e.NewValue as GroupStyle);
        }

        public GroupStyle GroupStyle
        {
            get { return (GroupStyle) GetValue(GroupStyleProperty); }
            set { SetValue(GroupStyleProperty, value); }
        }

        private static void TextChangedCallback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var sender = dependencyObject as SelectiveInput;

            string value = (string) dependencyPropertyChangedEventArgs.NewValue;

            sender._TB.Text = value;

            if (sender.FreeInput)
                sender._CB.Text = value;
            else
                sender._CB.SelectedValue = value;
        }

        private static void ShowCombobox_Changed_Callback(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs dependencyPropertyChangedEventArgs)
        {
            var sender = dependencyObject as SelectiveInput;

            bool value = (bool) dependencyPropertyChangedEventArgs.NewValue;

            sender._TB.Visibility = value ? Visibility.Collapsed : Visibility.Visible;
            sender._CB.Visibility = value ? Visibility.Visible : Visibility.Collapsed;
        }

        public object DefaultValue
        {
            get { return GetValue(DefaultValueProperty); }
            set { SetValue(DefaultValueProperty, value); }
        }

        public IEnumerable Options
        {
            get { return (IEnumerable) GetValue(OptionsProperty); }
            set { SetValue(OptionsProperty, value); }
        }

        public bool FreeInput
        {
            get { return (bool) GetValue(FreeInputProperty); }
            set { SetValue(FreeInputProperty, value); }
        }

        public DataTemplate ItemTemplate
        {
            get { return (DataTemplate) GetValue(ItemTemplateProperty); }
            set { SetValue(ItemTemplateProperty, value); }
        }

        public Style ItemContainerStyle
        {
            get { return (Style) GetValue(ItemContainerStyleProperty); }
            set { SetValue(ItemContainerStyleProperty, value); }
        }

        public ItemsPanelTemplate PanelTemplate
        {
            get { return (ItemsPanelTemplate) GetValue(PanelTemplateProperty); }
            set { SetValue(PanelTemplateProperty, value); }
        }

        public bool ShowCombobox
        {
            get { return (bool) GetValue(ShowComboboxProperty); }
            set { SetValue(ShowComboboxProperty, value); }
        }

        public string Text
        {
            get { return (string) GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        public string DisplayMemberPath
        {
            get { return (string) GetValue(DisplayMemberPathProperty); }
            set { SetValue(DisplayMemberPathProperty, value); }
        }

        public SelectiveInput()
        {
            InitializeComponent();
        }
    }
}