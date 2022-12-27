using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using PFConsole.Annotations;
using PFConsole.Project;
using PFModels.Data;
using PFModels.Data.Validation;
using PFModels.Data.Validation.Rules;

namespace PFConsole
{
    public partial class NewInterfaceWindow : INotifyPropertyChanged
    {
        private Interface _interfaceModel;
        public Interface InterfaceModel
        {
            get { return _interfaceModel; }
            set
            {
                if (Equals(value, _interfaceModel)) return;
                _interfaceModel = value;
                OnPropertyChanged("InterfaceModel");
            }
        }

        public NewInterfaceWindow()
        {
            _interfaceModel = new Interface();

            InitializeComponent();
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            string error = "";

            if (!Validator.Validate(InterfaceModel.Name, out error, new InterfaceNameValidator()) ||
                (_TB_MacroName.Text != "" && !Validator.Validate(_TB_MacroName.Text, out error, new MacroNameValidator())))
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = error;

                return;
            }

            if (PFProject.Instance.Interfaces[InterfaceModel.Name] != null)
            {
                e.CanExecute = false;
                _ErrorBlock.Visibility = Visibility.Visible;
                _ErrorText.Text = "An Interface with this name already exists.";

                return;
            }

            _ErrorBlock.Visibility = Visibility.Collapsed;
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveInterface();
            Close();
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveInterface();
            InterfaceModel = new Interface();
        }

        public void SaveInterface()
        {
            var clone = InterfaceModel.Clone() as Interface;
            PFProject.Instance.Interfaces.AddInterface(clone, _TB_MacroName.Text);
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