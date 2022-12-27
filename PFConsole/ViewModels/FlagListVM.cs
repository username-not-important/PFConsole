using System.ComponentModel;
using PFConsole.Annotations;

namespace PFConsole.ViewModels
{
    public class FlagListVM : INotifyPropertyChanged
    {
        private bool _f;
        private bool _s;
        private bool _r;
        private bool _p;
        private bool _a;
        private bool _e;
        private bool _u;
        private bool _w;

        public bool F
        {
            get { return _f; }
            set
            {
                if (value.Equals(_f)) return;
                _f = value;
                OnPropertyChanged("F");
            }
        }
        public bool S
        {
            get { return _s; }
            set
            {
                if (value.Equals(_s)) return;
                _s = value;
                OnPropertyChanged("S");
            }
        }
        public bool R
        {
            get { return _r; }
            set
            {
                if (value.Equals(_r)) return;
                _r = value;
                OnPropertyChanged("R");
            }
        }
        public bool P
        {
            get { return _p; }
            set
            {
                if (value.Equals(_p)) return;
                _p = value;
                OnPropertyChanged("P");
            }
        }
        public bool A
        {
            get { return _a; }
            set
            {
                if (value.Equals(_a)) return;
                _a = value;
                OnPropertyChanged("A");
            }
        }
        public bool E
        {
            get { return _e; }
            set
            {
                if (value.Equals(_e)) return;
                _e = value;
                OnPropertyChanged("E");
            }
        }
        public bool U
        {
            get { return _u; }
            set
            {
                if (value.Equals(_u)) return;
                _u = value;
                OnPropertyChanged("U");
            }
        }
        public bool W
        {
            get { return _w; }
            set
            {
                if (value.Equals(_w)) return;
                _w = value;
                OnPropertyChanged("W");
            }
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

        public override string ToString()
        {
            return (F ? "F" : "") +
                   (S ? "S" : "") +
                   (R ? "R" : "") +
                   (P ? "P" : "") +
                   (A ? "A" : "") +
                   (E ? "E" : "") +
                   (U ? "U" : "") +
                   (W ? "W" : "");
        }

        public bool IsChanged
        {
            get { return S || R || P || A || E || U || W; }
        }
    }
}