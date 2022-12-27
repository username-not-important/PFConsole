using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Documents;
using PFConsole.Annotations;
using PFConsole.Util.Diagram;

namespace PFConsole.ViewModels.Diagram
{
    public enum STOMode
    {
        KeepState,
        ModulateState,
        SYNProxyState
    }

    public static class STOModeEx
    {
        public static string Description(this STOMode mode)
        {
            switch (mode)
            {
                case STOMode.KeepState:
                    return "keep state";
                case STOMode.ModulateState:
                    return "modulate state";
                case STOMode.SYNProxyState:
                    return "synproxy state";
                default:
                    throw new ArgumentOutOfRangeException("mode");
            }
        }
    }
    

    public class STONodeVM : DiagramVMBase, INotifyPropertyChanged
    {
        private int _max;
        private bool _sourceTrackRule;
        private int _maxSrcConn;
        private int _maxSrcNode;
        private string _maxSrcConnRate;
        private bool _flush;
        private STOMode _mode;
        private FlagCheckMask _tcpFlags;
        private ExtractOptions _extractOptions;
        private string _overload;

        [Configurable("TCPFlags", typeof(FlagCheckMask), "General", "TCP Flags", "Sets TCP flags check and mask", false)]
        public FlagCheckMask TCPFlags
        {
            get { return _tcpFlags; }
            set
            {
                if (Equals(value, _tcpFlags)) return;

                _tcpFlags = value;
                OnPropertyChanged("TCPFlags");
            }
        }

        public void ResetTCPFlags()
        {
            TCPFlags = new FlagCheckMask();
        }

        public bool ShouldSerializeTCPFlags()
        {
            return TCPFlags.IsChanged;
        }

        [Configurable("Mode", typeof(STOMode), "General", "Mode", "Sets the maximum number of states.", false)]
        [DefaultValue(0)]
        public STOMode Mode
        {
            get { return _mode; }
            set
            {
                if (value == _mode) return;
                _mode = value;
                OnPropertyChanged("Mode");
            }
        }

        [Configurable("Max", typeof(int), "ST Options (used with KeepState mode)", "Max", "Sets the maximum number of states.", false)]
        [DefaultValue(0)]
        public int Max
        {
            get { return _max; }
            set
            {
                if (value == _max) return;
                _max = value;
                OnPropertyChanged("Max");
            }
        }

        [Configurable("SourceTrackRule", typeof(bool), "ST Options (used with KeepState mode)", "Source-Track-Rule", "Use Source-Track-Rule", false)]
        [DefaultValue(false)]
        public bool SourceTrackRule
        {
            get { return _sourceTrackRule; }
            set
            {
                if (value.Equals(_sourceTrackRule)) return;
                _sourceTrackRule = value;
                OnPropertyChanged("SourceTrackRule");
            }
        }

        [Configurable("MaxSrcConn", typeof(int), "ST Options (used with KeepState mode)", "Max Src Conn", "Maximum number of source connections", false)]
        [DefaultValue(0)]
        public int MaxSrcConn
        {
            get { return _maxSrcConn; }
            set
            {
                if (value == _maxSrcConn) return;
                _maxSrcConn = value;
                OnPropertyChanged("MaxSrcConn");
            }
        }

        [Configurable("MaxSrcNode", typeof(int), "ST Options (used with KeepState mode)", "Max Src Node", "Maximum number of source nodes", false)]
        [DefaultValue(0)]
        public int MaxSrcNode
        {
            get { return _maxSrcNode; }
            set
            {
                if (value == _maxSrcNode) return;
                _maxSrcNode = value;
                OnPropertyChanged("MaxSrcNode");
            }
        }

        [Configurable("MaxSrcConnRate", typeof(string), "ST Options (used with KeepState mode)", "Max Src Conn Rate", "Maximum number for source connection rate", false)]
        [DefaultValue("")]
        public string MaxSrcConnRate
        {
            get { return _maxSrcConnRate; }
            set
            {
                if (value == _maxSrcConnRate) return;
                _maxSrcConnRate = value;
                OnPropertyChanged("MaxSrcConnRate");
            }
        }

        [Configurable("Overload", typeof(string), "ST Options (used with KeepState mode)", "Overload Table", "", false)]
        [DefaultValue("")]
        public string Overload
        {
            get { return _overload; }
            set
            {
                if (value == _overload) return;
                _overload = value.Replace("<","").Replace(">","");
                OnPropertyChanged("Overload");
            }
        }

        [Configurable("Flush", typeof(bool), "ST Options (used with KeepState mode)", "Flush", "Use Flush", false)]
        [DefaultValue(false)]
        public bool Flush
        {
            get { return _flush; }
            set
            {
                if (value.Equals(_flush)) return;
                _flush = value;
                OnPropertyChanged("Flush");
            }
        }

        [Configurable("ExtractOptions", typeof(ExtractOptions), "Compile Options", "Extract Options", "PFRule Compilation Options", false)]
        public ExtractOptions ExtractOptions
        {
            get { return _extractOptions; }
            set
            {
                if (Equals(value, _extractOptions)) return;
                _extractOptions = value;
                OnPropertyChanged("ExtractOptions");
            }
        }

        public void ResetExtractOptions()
        {
            ExtractOptions.Reset();
        }

        public bool ShouldSerializeExtractOptions()
        {
            return ExtractOptions.IsChanged;
        }

        public STONodeVM()
        {
            MaxSrcConnRate = "";
            Overload = "";

            TCPFlags = new FlagCheckMask();

            ExtractOptions = new ExtractOptions();
            ExtractOptions.PropertyChanged += (sender, args) => OnPropertyChanged("ExtractOptions");
        }

        public override string GetInlineDefinition()
        {
            string result = "";
            if (ShouldSerializeTCPFlags())
                result += string.Format("flags {0} {1}", TCPFlags.Code, (Mode != STOMode.KeepState ? Mode.Description() + " " : ""));

            var states = getChangedStateProperties();
            if (states.Length != 0)
            {
                result += "(" + states[0];
                for (int i = 1; i < states.Length; i++)
                    result += string.Format(", {0}", states[i]);

                result += ")";
            }

            return result.Replace("  "," ").Trim(' ');
        }

        private string[] getChangedStateProperties()
        {
            List<string> changed = new List<string>();

            if (Max != 0) changed.Add("max " + Max);
            if (SourceTrackRule) changed.Add("source-track");
            if (MaxSrcNode != 0) changed.Add("max-src-nodes " + MaxSrcNode);
            if (MaxSrcConn != 0) changed.Add("max-src-conn " + MaxSrcConn);
            if (MaxSrcConnRate != "") changed.Add("max-src-conn-rate " + MaxSrcConnRate);
            if (Overload != "") changed.Add("overload " + Overload);
            if (Flush) changed.Add("flush");

            return changed.ToArray();
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

    public class FlagCheckMask : INotifyPropertyChanged
    {
        private FlagListVM _check;
        private FlagListVM _mask;

        public FlagListVM Check
        {
            get { return _check; }
            set
            {
                if (Equals(value, _check)) return;
                _check = value;

                Check.PropertyChanged += InnerPropertiesChanged;

                OnPropertyChanged("Check");
                OnPropertyChanged("IsChanged");
            }
        }

        public void ResetCheck()
        {
            Check = new FlagListVM();
            Check.PropertyChanged += InnerPropertiesChanged;
        }

        public bool ShouldSerializeCheck()
        {
            return Check.IsChanged;
        }

        public FlagListVM Mask
        {
            get { return _mask; }
            set
            {
                if (Equals(value, _mask)) return;
                _mask = value;

                Mask.PropertyChanged += InnerPropertiesChanged;

                OnPropertyChanged("Mask");
                OnPropertyChanged("IsChanged");
            }
        }

        public void ResetMask()
        {
            Mask = new FlagListVM();
            Mask.PropertyChanged += InnerPropertiesChanged;
        }

        public bool ShouldSerializeMask()
        {
            return Mask.IsChanged;
        }

        public FlagCheckMask()
        {
            ResetCheck();
            ResetMask();
        }

        private void InnerPropertiesChanged(object sender, PropertyChangedEventArgs propertyChangedEventArgs)
        {
            OnPropertyChanged("IsChanged");
            OnPropertyChanged("Code");
        }

        public override string ToString()
        {
            string mask = Mask.ToString();

            return Check + (mask == "" ? "" : "/") + mask;
        }

        public bool IsChanged
        {
            get { return Check.IsChanged || Mask.IsChanged; }
        }

        public string Code
        {
            get { return ToString(); }
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