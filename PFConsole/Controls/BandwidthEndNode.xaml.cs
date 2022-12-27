using System.Windows;
using System.Windows.Controls;

namespace PFConsole.Controls
{
    /// <summary>
    ///     Interaction logic for BandwidthEndNode.xaml
    /// </summary>
    public partial class BandwidthEndNode : UserControl
    {
        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register(
            "Label", typeof(string), typeof(BandwidthEndNode), new PropertyMetadata(default(string)));

        public string Label
        {
            get { return (string) GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public BandwidthEndNode()
        {
            InitializeComponent();
        }
    }
}