using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using PFConsole.Annotations;
using PFConsole.Project;
using PFModels.Data;

namespace PFConsole.Views.DiagramItems
{
    /// <summary>
    ///     Interaction logic for InterfaceItem.xaml
    /// </summary>
    public partial class InterfaceItem : INotifyPropertyChanged
    {
        private ObservableCollection<Macro> _interfaceMacros;
        public ObservableCollection<Macro> InterfaceMacros
        {
            get { return _interfaceMacros; }
            set
            {
                if (Equals(value, _interfaceMacros)) return;
                _interfaceMacros = value;
                OnPropertyChanged("InterfaceMacros");
            }
        }

        public static readonly DependencyProperty SelectionProperty = DependencyProperty.Register(
            "Selection", typeof(Macro), typeof(InterfaceItem), new FrameworkPropertyMetadata {BindsTwoWayByDefault = true});

        public Macro Selection
        {
            get { return (Macro) GetValue(SelectionProperty); }
            set { SetValue(SelectionProperty, value); }
        }

        public InterfaceItem()
        {
            UpdateInterfaces();

            InitializeComponent();

            PFProject.Instance.Interfaces.Interfaces.CollectionChanged += (sender, args) => UpdateInterfaces();
            PFProject.Instance.Macros.Macros.CollectionChanged += (sender, args) => UpdateInterfaces();
        }

        private void UpdateInterfaces()
        {
            InterfaceMacros = new ObservableCollection<Macro>(PFProject.Instance.Macros.Macros.Where(m => m.GetContentType() == typeof(Interface)));
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