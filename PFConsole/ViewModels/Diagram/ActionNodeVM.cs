using System.ComponentModel;
using PFConsole.Annotations;
using PFConsole.Util.Diagram;

namespace PFConsole.ViewModels.Diagram
{
    public enum PassAction
    {
        Block,
        Pass
    }

    public enum BlockAction
    {
        [Description("")]
        Default,
        [Description("drop")]
        Drop,
        [Description("return")]
        Return,
        [Description("return-rst")]
        ReturnRST,
        [Description("return-icmp")]
        ReturnIMCP,
        [Description("return-icmp6")]
        ReturnIMCP6
    }

    public class ActionNodeVM : DiagramVMBase, INotifyPropertyChanged
    {
        private bool _setToPass;
        private BlockAction _blockType;
        private bool _isQuick;

        [Configurable("IsQuick", typeof(bool), "Quick Rules", "Quick", "Defines if rule created by this select is Quick.", false)]
        [DefaultValue(false)]
        public bool IsQuick
        {
            get { return _isQuick; }
            set
            {
                if (value.Equals(_isQuick)) return;
                _isQuick = value;
                OnPropertyChanged("IsQuick");
            }
        }

        public bool SetToPass
        {
            get { return _setToPass; }
            set
            {
                if (value.Equals(_setToPass)) return;
                _setToPass = value;
                OnPropertyChanged("SetToPass");
                OnPropertyChanged("Action");
            }
        }

        [Configurable("Action", typeof(PassAction), "General", "Action", "Whether to pass or block the traffic that reaches this node", false)]
        [DefaultValue(PassAction.Block)]
        public PassAction Action
        {
            get { return SetToPass ? PassAction.Pass : PassAction.Block; }
            set
            {
                switch (value)
                {
                    case PassAction.Block:
                        SetToPass = false;
                        break;
                    case PassAction.Pass:
                        SetToPass = true;
                        break;
                }
            }
        }

        [Configurable("BlockType", typeof(BlockAction), "Misc", "Block Policy", "Block Rule behavior. The default behaviour is to drop packets silently, however this can be overridden, by setting the block-policy option", false)]
        [DefaultValue(BlockAction.Default)]
        public BlockAction BlockType
        {
            get { return _blockType; }
            set
            {
                if (value == _blockType) return;
                _blockType = value;
                OnPropertyChanged("BlockType");
            }
        }

        public ActionNodeVM()
        {
            BlockType = BlockAction.Default;
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