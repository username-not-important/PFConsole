using System.Windows;
using System.Windows.Controls;
using PFConsole.Views.Macros;
using PFModels.Data;

namespace PFConsole.Views
{
    /// <summary>
    ///     Interaction logic for MacroContentView.xaml
    /// </summary>
    public partial class MacroContentView : UserControl
    {
        public static readonly DependencyProperty MacroContentModelProperty = DependencyProperty.Register(
            "MacroContentModel", typeof(MacroContent), typeof(MacroContentView), new PropertyMetadata(default(MacroContent), MacroContentChanged));

        private static void MacroContentChanged(DependencyObject dependencyObject, DependencyPropertyChangedEventArgs e)
        {
            (dependencyObject as MacroContentView).UpdateMacroContentChild();
        }

        public MacroContent MacroContentModel
        {
            get { return (MacroContent) GetValue(MacroContentModelProperty); }
            set { SetValue(MacroContentModelProperty, value); }
        }

        public MacroContentView()
        {
            InitializeComponent();
        }

        private void UpdateMacroContentChild()
        {
            _LayoutGrid.Children.Clear();
            _LayoutGrid.Children.Add(new MacroUIElementSelector().SelectElement(MacroContentModel));
        }
    }
}