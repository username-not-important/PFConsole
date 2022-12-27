using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;
using Microsoft.Win32;
using PFConsole.Annotations;
using PFConsole.Project;

namespace PFConsole.ChildWindows
{
    /// <summary>
    ///     Interaction logic for NewProjectWindow.xaml
    /// </summary>
    public partial class NewProjectWindow : INotifyPropertyChanged
    {
        private string _filePath;

        public NewProjectWindow()
        {
            InitializeComponent();
        }

        public string FilePath
        {
            get { return _filePath; }
            private set
            {
                if (value == _filePath) return;
                _filePath = value;
                OnPropertyChanged("FilePath");
            }
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(_TitleBox.Text) || FilePath == "")
                e.CanExecute = false;

            e.CanExecute = true;
        }

        private void SaveCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PFProject.Instance.NewProject(_TitleBox.Text, FilePath);
            PFProject.Save();

            Close();
        }

        private void CloseCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            Close();
        }

        private void _Button_Choose_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog {CheckPathExists = true, OverwritePrompt = true, Filter = "PF Project files (*.pfp)|*.pfp"};

            var result = dialog.ShowDialog();
            if (result != null)
                FilePath = dialog.FileName;
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