using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using PFConsole.Annotations;
using PFModels.Data;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for NewQueueWindow.xaml
    /// </summary>
    public partial class EditQueueWindow : INotifyPropertyChanged
    {
        public static readonly DependencyProperty QueueModelProperty = DependencyProperty.Register(
            "QueueModel", typeof(Queue), typeof(EditQueueWindow), new PropertyMetadata(default(Queue)));

        public Queue QueueModel
        {
            get { return (Queue) GetValue(QueueModelProperty); }
            set { SetValue(QueueModelProperty, value); }
        }

        public EditQueueWindow(Queue model)
        {
            QueueModel = model;

            InitializeComponent();
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            string error = "";

            _ErrorBlock.Visibility = Visibility.Collapsed;
            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            string s = QueueModel.Name;
            QueueModel.Name = "-";
            QueueModel.Name = s;

            Close();
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