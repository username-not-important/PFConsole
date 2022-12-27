using System.Collections.ObjectModel;
using System.ComponentModel;
using PFConsole.Annotations;
using PFConsole.Project.DataHelpers;
using PFConsole.Util.Diagram;
using PFModels.Data;

namespace PFConsole.ViewModels.Diagram
{
    public class FilterNodeVM : DiagramVMBase, INotifyPropertyChanged
    {
        private AddressFamily _addressFamily;
        private Proto _protocol;
        private ObservableCollection<MacroContent> _sourceAddress;
        private ObservableCollection<MacroContent> _destinationAddress;
        private ObservableCollection<MacroContent> _sourcePort;
        private ObservableCollection<MacroContent> _destinationPort;

        [Configurable("AddressFamily", typeof(AddressFamily), "Addresses", "Address Family", "Set the type of addresses for this filter.", false)]
        [DefaultValue(AddressFamily.None)]
        public AddressFamily AddressFamily
        {
            get { return _addressFamily; }
            set
            {
                if (value == _addressFamily) return;
                _addressFamily = value;
                OnPropertyChanged("AddressFamily");
            }
        }

        [Configurable("Protocol", typeof(Proto), "Protocols", "Protocol", "Filter anything with this protocol", false)]
        [DefaultValue(Proto.None)]
        public Proto Protocol
        {
            get { return _protocol; }
            set
            {
                if (value == _protocol) return;
                _protocol = value;
                OnPropertyChanged("Protocol");
            }
        }

        [Configurable("SourceAddress", typeof(ObservableCollection<MacroContent>), "Addresses", "Source Address", "Set the source address for this filter.", false)]
        public ObservableCollection<MacroContent> SourceAddress
        {
            get { return _sourceAddress; }
            set
            {
                if (value == _sourceAddress) return;
                _sourceAddress = value;

                OnPropertyChanged("SourceAddress");
            }
        }

        public void ResetSourceAddress()
        {
            SourceAddress = new ObservableCollection<MacroContent>();
        }

        public bool ShouldSerializeSourceAddress()
        {
            return SourceAddress.Count != 0;
        }

        [Configurable("SourcePort", typeof(ObservableCollection<MacroContent>), "Addresses", "Source Port", "Set the source port for this filter.", false)]
        public ObservableCollection<MacroContent> SourcePort
        {
            get { return _sourcePort; }
            set
            {
                if (Equals(value, _sourcePort)) return;
                _sourcePort = value;
                OnPropertyChanged("SourcePort");
            }
        }

        public void ResetSourcePort()
        {
            SourcePort = new ObservableCollection<MacroContent>();
        }

        public bool ShouldSerializeSourcePort()
        {
            return SourcePort.Count != 0;
        }

        [Configurable("DestinationAddress", typeof(ObservableCollection<MacroContent>), "Addresses", "Destination Address & Port", "Set the destination address for this filter.", false)]
        public ObservableCollection<MacroContent> DestinationAddress
        {
            get { return _destinationAddress; }
            set
            {
                if (value == _destinationAddress) return;
                _destinationAddress = value;
                OnPropertyChanged("DestinationAddress");
            }
        }

        public void ResetDestinationAddress()
        {
            SourceAddress = new ObservableCollection<MacroContent>();
        }

        public bool ShouldSerializeDestinationAddress()
        {
            return DestinationAddress.Count != 0;
        }

        [Configurable("DestinationPort", typeof(ObservableCollection<MacroContent>), "Addresses", "Destination Port", "Set the destination port for this filter.", false)]
        public ObservableCollection<MacroContent> DestinationPort
        {
            get { return _destinationPort; }
            set
            {
                if (Equals(value, _destinationPort)) return;
                _destinationPort = value;
                OnPropertyChanged("DestinationPort");
            }
        }

        public void ResetDestinationPort()
        {
            DestinationPort = new ObservableCollection<MacroContent>();
        }

        public bool ShouldSerializeDestinationPort()
        {
            return DestinationPort.Count != 0;
        }

        public FilterNodeVM()
        {
            AddressFamily = AddressFamily.None;
            Protocol = Proto.None;

            SourceAddress = new ObservableCollection<MacroContent>();
            DestinationAddress = new ObservableCollection<MacroContent>();

            SourcePort = new ObservableCollection<MacroContent>();
            DestinationPort = new ObservableCollection<MacroContent>();
        }

        public override void FixSerializationIssues()
        {
            SourceAddress = ExistingMacroHelper.AssignExistingMacros(_sourceAddress);
            SourcePort = ExistingMacroHelper.AssignExistingMacros(_sourcePort);

            DestinationAddress = ExistingMacroHelper.AssignExistingMacros(_destinationAddress);
            DestinationPort = ExistingMacroHelper.AssignExistingMacros(_destinationPort);
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

    public enum AddressFamily
    {
        [Description("")]
        None,
        [Description("inet")]
        Inet,
        [Description("inet6")]
        Inet6
    };

    public enum Proto
    {
        [Description("")]
        None,
        [Description("tcp")]
        TCP,
        [Description("udp")]
        UDP,
        [Description("icmp")]
        ICMP
    }
}