using System;
using System.ComponentModel;
using System.Xml.Serialization;
using PFConsole.Annotations;
using PFConsole.Util.Diagram;
using PFModels.Data;

namespace PFConsole.ViewModels.Diagram
{
    public class QueueNodeVM : DiagramVMBase, INotifyPropertyChanged
    {
        private Queue _queueModel;

        public Queue QueueModel
        {
            get { return _queueModel; }
            set
            {
                if (Equals(value, _queueModel)) return;
                _queueModel = value;

                _queueModel.PropertyChanged += (sender, args) =>
                {
                    OnPropertyChanged("IsNameEmpty");
                    OnPropertyChanged("EndNodeLabel");
                };

                (_queueModel.Content as INotifyPropertyChanged).PropertyChanged += (sender, args) => OnPropertyChanged("EndNodeLabel");

                OnPropertyChanged("QueueModel");
            }
        }

        [XmlIgnore]
        public bool IsNameEmpty
        {
            get { return String.IsNullOrWhiteSpace(QueueModel.Name); }
        }

        [XmlIgnore]
        [Configurable("QueueName", typeof(string), "Misc", "Name", "The Name of Queue assigned to this node.", false)]
        public string QueueName
        {
            get { return QueueModel.Name; }
            set
            {
                if (QueueModel != null && !String.IsNullOrWhiteSpace(value))
                    QueueModel.Name = value;
            }
        }

        [XmlIgnore]
        public string EndNodeLabel
        {
            get
            {
                if (QueueModel != null)
                {
                    if (QueueModel.Content is HFSCContent)
                        return (QueueModel.Content as HFSCContent).Bandwidth.ToString();

                    if (QueueModel.Content is CBQContent)
                        return (QueueModel.Content as CBQContent).Bandwidth.ToString();

                    if (QueueModel.Content is PriQContent)
                        return "Priority " + (QueueModel.Content as PriQContent).Priority;
                }
                return "";
            }
        }

        public QueueNodeVM()
        {
            QueueModel = new Queue();
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