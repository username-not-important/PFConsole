using System;
using System.ComponentModel;
using System.IO;
using System.Xml.Serialization;
using PFConsole.Annotations;
using PFConsole.Logs;
using PFConsole.Project.DataHelpers;
using PFConsole.Util;
using PFConsole.VisualResources;

namespace PFConsole.Project
{
    public class PFProject : INotifyPropertyChanged
    {
        #region Singleton

        private static PFProject _instance;
        private static object _lock = true;

        public static PFProject Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new PFProject();

                    return _instance;
                }
            }
        }

        #endregion

        private string _title;
        private bool _projectLoaded;
        private bool _requiresSave;
        private string _projectPath;

        private OptionsRepository _options;
        private MacroRepository _macros;
        private InterfaceRepository _interfaces;
        private TableRepository _tables;
        private DiagramRepository _diagrams;

        public string Title
        {
            get { return _title; }
            set
            {
                if (value == _title) return;
                _title = value;
                OnPropertyChanged("Title");
            }
        }
        public OptionsRepository Options
        {
            get { return _options; }
            set
            {
                if (Equals(value, _options)) return;
                _options = value;
                OnPropertyChanged("Options");
            }
        }
        public MacroRepository Macros
        {
            get { return _macros; }
            set
            {
                if (Equals(value, _macros)) return;
                _macros = value;
                OnPropertyChanged("Macros");
            }
        }
        public InterfaceRepository Interfaces
        {
            get { return _interfaces; }
            set
            {
                if (Equals(value, _interfaces)) return;
                _interfaces = value;
                OnPropertyChanged("Interfaces");
            }
        }
        public TableRepository Tables
        {
            get { return _tables; }
            set
            {
                if (Equals(value, _tables)) return;
                _tables = value;
                OnPropertyChanged("Tables");
            }
        }
        public DiagramRepository Diagrams
        {
            get { return _diagrams; }
            set
            {
                if (Equals(value, _diagrams)) return;
                _diagrams = value;
                OnPropertyChanged("Diagrams");
            }
        }

        #region XMLIgnore

        [XmlIgnore]
        public string ProjectPath
        {
            get { return _projectPath; }
            set
            {
                if (value == _projectPath) return;
                _projectPath = value;
                OnPropertyChanged("ProjectPath");
            }
        }

        [XmlIgnore]
        public bool ProjectLoaded
        {
            get { return _projectLoaded; }
            set
            {
                if (value.Equals(_projectLoaded)) return;
                _projectLoaded = value;
                OnPropertyChanged("ProjectLoaded");
            }
        }

        [XmlIgnore]
        public bool RequiresSave
        {
            get { return _requiresSave; }
            set
            {
                if (value.Equals(_requiresSave)) return;
                _requiresSave = value;
                OnPropertyChanged("RequiresSave");
            }
        }

        #endregion

        private PFProject()
        {
            ClearRepository();
        }

        private void ClearRepository()
        {
            Options = new OptionsRepository();
            Macros = new MacroRepository();
            Interfaces = new InterfaceRepository();
            Tables = new TableRepository();
            Diagrams = new DiagramRepository();
        }

        public void NewProject(string title, string path)
        {
            ClearRepository();
            Title = title;
            ProjectPath = path;

            ProjectLoaded = true;
            RequiresSave = true;

            Logger.Instance.Log(String.Format("New Project ({0}) Created at {1} .", title, path));
        }

        public static void Load(string path)
        {
            PFProject temp = TextSerializer.XmlDeserializeFromString<PFProject>(File.ReadAllText(path));
            ExistingMacroHelper.AssignExistingMacros(temp);

            Instance.Options = temp.Options;
            Instance.Interfaces = temp.Interfaces;
            Instance.Macros = temp.Macros;
            Instance.Tables = temp.Tables;
            Instance.Diagrams = temp.Diagrams;
            Instance.Title = temp.Title;

            Instance.ProjectPath = path;
            Instance.ProjectLoaded = true;
            Instance.RequiresSave = false;

            Logger.Instance.Log(String.Format("Project {0} Loaded from {1}", Instance.Title, Instance.ProjectPath));
        }

        public static void Save()
        {
            string str = TextSerializer.XmlSerializeToString(Instance);
            File.WriteAllText(Instance.ProjectPath, str);

            Instance.RequiresSave = false;

            Logger.Instance.Log(String.Format("Project {0} Saved at {1}", Instance.Title, Instance.ProjectPath));
        }

        public static void Close()
        {
            WindowManager.CloseAll();
            Instance.ProjectLoaded = false;
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