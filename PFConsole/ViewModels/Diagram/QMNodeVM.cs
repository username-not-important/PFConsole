using System.ComponentModel;
using PFConsole.Annotations;
using PFConsole.Util.Diagram;
using PFModels.Data;

namespace PFConsole.ViewModels.Diagram
{
    public class QMNodeVM : DiagramVMBase, INotifyPropertyChanged
    {
        public QM QMModel { get; set; }

        public QMNodeVM()
        {
            QMModel = new QM();
        }

        [Configurable("Mode", typeof(QMMode), "General", "Mode", "Set QM mode for this node.", false)]
        public QMMode Mode
        {
            get { return QMModel.Mode; }
            set { QMModel.Mode = value; }
        }

        [Configurable("ECN", typeof(bool), "General", "ECN", "Enable or disable ECN.", false)]
        public bool ECN
        {
            get { return QMModel.ECN; }
            set { QMModel.ECN = value; }
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