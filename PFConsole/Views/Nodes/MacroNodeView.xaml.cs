namespace PFConsole.Views.Nodes
{
    /// <summary>
    ///     Interaction logic for MacroNodeView.xaml
    /// </summary>
    public partial class MacroNodeView
    {
        public bool IsExpanded
        {
            get { return Expander.IsChecked.GetValueOrDefault(); }
            set { Expander.IsChecked = value; }
        }

        public MacroNodeView()
        {
            InitializeComponent();
        }
    }
}