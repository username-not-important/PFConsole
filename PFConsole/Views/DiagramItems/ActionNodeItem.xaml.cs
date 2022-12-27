using System.Windows;
using System.Windows.Controls;

namespace PFConsole.Views.DiagramItems
{
    /// <summary>
    ///     Interaction logic for ActionNodeItem.xaml
    /// </summary>
    public partial class ActionNodeItem : UserControl
    {
        public static readonly DependencyProperty SetToPassProperty = DependencyProperty.Register(
            "SetToPass", typeof(bool), typeof(ActionNodeItem), new FrameworkPropertyMetadata {BindsTwoWayByDefault = true});

        public bool SetToPass
        {
            get { return (bool) GetValue(SetToPassProperty); }
            set { SetValue(SetToPassProperty, value); }
        }

        public ActionNodeItem()
        {
            InitializeComponent();
        }
    }
}