using System.Windows;
using System.Windows.Controls;
using PFModels.Data;

namespace PFConsole.Controls.QueueContent
{
    /// <summary>
    ///     Interaction logic for QueueContentProperties.xaml
    /// </summary>
    public partial class QueueContentProperties : UserControl
    {
        public static readonly DependencyProperty SchedulerTypeProperty = DependencyProperty.Register("SchedulerType", typeof(SchedulerType), typeof(QueueContentProperties), new PropertyMetadata(default(SchedulerType), SchedulerTypeChange_Callback));

        private static void SchedulerTypeChange_Callback(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var obj = (sender as QueueContentProperties);

            Load((SchedulerType) e.NewValue, obj);
        }

        private static void Load(SchedulerType type, QueueContentProperties obj)
        {
            obj._grid.Children.Clear();

            switch (type)
            {
                case SchedulerType.HFSC:
                    obj._grid.Children.Add(new HFSCProperties {DataContext = obj.DataContext});
                    break;
                case SchedulerType.CBQ:
                    obj._grid.Children.Add(new CBQProperties {DataContext = obj.DataContext});
                    break;
                case SchedulerType.PriQ:
                    obj._grid.Children.Add(new PriqProperties {DataContext = obj.DataContext});
                    break;
            }
        }

        public QueueContentProperties()
        {
            InitializeComponent();

            DataContextChanged += (sender, args) => Load(SchedulerType, this);
        }

        public SchedulerType SchedulerType
        {
            get { return (SchedulerType) GetValue(SchedulerTypeProperty); }
            set { SetValue(SchedulerTypeProperty, value); }
        }
    }
}