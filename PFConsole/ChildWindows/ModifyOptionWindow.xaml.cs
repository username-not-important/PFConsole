using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using Infragistics.DragDrop;
using PFConsole.Annotations;
using PFConsole.Logs;
using PFConsole.Project;
using PFConsole.Util;
using PFModels.Data;
using PFModels.Data.Validation;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for ModifyOptionWindow.xaml
    /// </summary>
    public partial class ModifyOptionWindow : INotifyPropertyChanged, IDragDropHandler
    {
        public class InterfaceOptionItem
        {
            public string Value { get; set; }
            public string Group { get; set; }

            public InterfaceOptionItem()
            {}

            public InterfaceOptionItem(string value, string group)
            {
                Value = value;
                Group = group;
            }
        }

        private Option _optionModel;
        private ObservableCollection<InterfaceOptionItem> _interfaceOptionItems;

        public Option OptionModel
        {
            get { return _optionModel; }
            set
            {
                if (Equals(value, _optionModel)) return;
                _optionModel = value;
                OnPropertyChanged("OptionModel");
            }
        }
        public ObservableCollection<InterfaceOptionItem> InterfaceOptionItems
        {
            get { return _interfaceOptionItems; }
            set
            {
                if (Equals(value, _interfaceOptionItems)) return;
                _interfaceOptionItems = value;
                OnPropertyChanged("InterfaceOptionItems");
            }
        }

        public ModifyOptionWindow(string OptionKey)
        {
            OptionModel = PFProject.Instance.Options[OptionKey];
            InitializeComponent();

            Title = String.Format("Modify Option ({0})", OptionModel.Meta.Text);

            if (OptionModel.Meta.Group == "Interfaces")
            {
                _interfaceDropTarget.IsDropTarget = true;
                UpdateInterfaceData();

                PFProject.Instance.Interfaces.Interfaces.CollectionChanged += (sender, args) => UpdateInterfaceData();
                PFProject.Instance.Macros.Macros.CollectionChanged += (sender, args) => UpdateInterfaceData();
            }
        }

        private void UpdateInterfaceData()
        {
            List<InterfaceOptionItem> source = new List<InterfaceOptionItem> {new InterfaceOptionItem("none", "none")};

            source.AddRange(PFProject.Instance.Macros.Macros.Where(m => m.Content as Interface != null).
                Select(m => new InterfaceOptionItem("$" + m.Name, "Macros")));

            source.AddRange(PFProject.Instance.Interfaces.Interfaces.Select(i => new InterfaceOptionItem(i.Name, "Interfaces")));

            _InputBox.DisplayMemberPath = "Value";

            InterfaceOptionItems = new ObservableCollection<InterfaceOptionItem>(source);
            _InputBox.Options = InterfaceOptionItems;
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

        private void CommandBinding_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (OptionModel.Value == OptionModel.Meta.Default)
                PFProject.Instance.Options.RemoveSetting(OptionModel);
        }

        private void Save_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            string error = "";

            if (!Validator.Validate(_InputBox.Text, out error, OptionModel.Meta.Rules.Select(ValidatorFactory.CreateValidator).ToArray()))
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = error;

                return;
            }

            if (OptionModel.Meta.Group == "Interfaces" && InterfaceOptionItems != null && InterfaceOptionItems.FirstOrDefault(item => item.Value == _InputBox.Text) == null)
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = "You have to choose a valid macro/interface as value.";

                return;
            }

            _ErrorBlock.Visibility = Visibility.Collapsed;
            e.CanExecute = true;
        }

        private void Save_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OptionModel.Value = _InputBox.Text;
            Logger.Instance.Log(string.Format("Option {0} Changed to {1}.", OptionModel.Meta.Text, OptionModel.Value));

            PFProject.Instance.RequiresSave = true;

            Close();
        }

        private void _Button_Reset_Click(object sender, RoutedEventArgs e)
        {
            _InputBox.Text = OptionModel.Meta.Default;
        }

        public void CommitDrop(DragDropEventArgs e)
        {
            var source = e.Data;

            if (source is Macro)
                _InputBox.Text = "$" + (source as Macro).Name;
            else if (source is Interface)
                _InputBox.Text = (source as Interface).Name;
        }

        public bool IsDropTarget(DragDropEventArgs e, params string[] channel)
        {
            if (!_interfaceDropTarget.IsDropTarget)
                return false;

            if (!(e.Data is Interface) && !((e.Data is Macro) && (e.Data as Macro).GetContentType() == typeof(Interface)))
                return false;

            return _interfaceDropTarget.DropChannels.Intersect(channel).Count() != 0;
        }
    }
}