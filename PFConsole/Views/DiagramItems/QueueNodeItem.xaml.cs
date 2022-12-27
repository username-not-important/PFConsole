using System.ComponentModel;
using System.Windows;
using PFConsole.Annotations;
using PFConsole.ChildWindows;
using PFModels.Data;

namespace PFConsole.Views.DiagramItems
{
    /// <summary>
    ///     Interaction logic for QueueNodeItem.xaml
    /// </summary>
    public partial class QueueNodeItem : INotifyPropertyChanged
    {
        public static readonly DependencyProperty QueueModelProperty = DependencyProperty.Register(
            "QueueModel", typeof(Queue), typeof(QueueNodeItem), new PropertyMetadata(default(Queue)));

        public Queue QueueModel
        {
            get { return (Queue) GetValue(QueueModelProperty); }
            set { SetValue(QueueModelProperty, value); }
        }

        public QueueNodeItem()
        {
            InitializeComponent();
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

        private void _Button_Edit_Clicked(object sender, RoutedEventArgs e)
        {
            EditQueueWindow win = new EditQueueWindow(QueueModel);
            win.ShowDialog();
        }
    }
}