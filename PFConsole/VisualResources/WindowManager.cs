using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Infragistics.Windows.DockManager;
using Infragistics.Windows.DockManager.Events;
using PFConsole.ContentPages;

namespace PFConsole.VisualResources
{
    public class WindowManager
    {
        public ObservableCollection<ContentPane> OpenDocuments { get; private set; }
        public ObservableCollection<Window> OpenWindows { get; private set; }

        public TabGroupPane DocumentsPane { get; set; }

        private List<Tuple<Type, object>> _locks;

        private WindowManager()
        {
            _locks = new List<Tuple<Type, object>>();

            OpenDocuments = new ObservableCollection<ContentPane>();
            OpenWindows = new ObservableCollection<Window>();
        }

        #region Singleton

        private static WindowManager _instance;
        private static object _lock = true;

        public static WindowManager Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                        _instance = new WindowManager();

                    return _instance;
                }
            }
        }

        #endregion

        public static bool CreateDocument<T>(bool locks, object arg) where T : Page
        {
            var win = Instance._locks.Find(ow => ow.Item1 == typeof(T) && ow.Item2 == (arg));

            if (win != null)
            {
                //already open
                Instance.DocumentsPane.SelectedItem = Instance.OpenDocuments.First(d => (string) d.Tag == win.Item1.Name + ":" + arg);
                return false;
            }

            var instance = Instance.CreateDocument<T>(arg);
            instance.Closed += (sender, args) =>
            {
                Instance.OpenDocuments.Remove(sender as ContentPane);

                var find = Instance._locks.Find(ow => (string) (sender as ContentPane).Tag == ow.Item1.Name + ":" + ow.Item2);
                if (find != null)
                    Instance._locks.Remove(find);
            };

            instance.Closing += PromptDiagramClose;

            if (locks)
                Instance._locks.Add(new Tuple<Type, object>(typeof(T), arg));

            Instance.OpenDocuments.Add(instance);

            Instance.DocumentsPane.Items.Add(instance);
            Instance.DocumentsPane.SelectedItem = instance;

            return true;
        }

        private static void PromptDiagramClose(object sender, PaneClosingEventArgs args)
        {
            var pane = sender as ContentPane;
            if (pane.Tag.ToString().Contains("Diagram"))
            {
                var response = JMessageBox.Show("Do you want to save diagram " + pane.TabHeader.ToString().Replace(" (diagram)", "") + " before closing it?", "Close Diagram", MessageBoxButton.YesNo);
                if (response == MessageBoxResult.No) return;

                ((pane.Content as Frame).Content as PFDiagramPage).SaveDiagram();
            }
        }

        public static void CreateWindow<T>(bool locks, object arg) where T : Window
        {
            var win = Instance._locks.Find(ow => ow.Item1 == typeof(T) && (arg == null || ow.Item2.Equals(arg)));

            if (win != null)
            {
                //already open
                Instance.OpenWindows.First(w => (string) w.Tag == win.Item1.Name + ":" + arg).Activate();
                return;
            }

            var instance = Instance.CreateNew<T>(arg);
            instance.Tag = instance.GetType().Name + ":" + arg;

            instance.Closed += (sender, args) =>
            {
                Instance.OpenWindows.Remove(sender as Window);

                var find = Instance._locks.Find(ow => (sender as Window).Tag.ToString().StartsWith(ow.Item1.Name));
                if (find != null)
                    Instance._locks.Remove(find);
            };

            if (locks)
                Instance._locks.Add(new Tuple<Type, object>(typeof(T), arg));

            Instance.OpenWindows.Add(instance);

            instance.Show();
        }

        public static bool GetPermission<T>(object arg) where T : Window
        {
            var win = Instance._locks.Find(ow => ow.Item1 == typeof(T) && ow.Item2.Equals(arg));

            return win == null;
        }

        public static void CloseAll()
        {
            while (Instance.OpenWindows.Count != 0)
                Instance.OpenWindows[0].Close();

            Instance._locks.Clear();

            List<ContentPane> removeCandidates = new List<ContentPane>();
            foreach (object t in Instance.DocumentsPane.Items)
                if ((string) (t as ContentPane).TabHeader != "Dashboard")
                    removeCandidates.Add(t as ContentPane);

            foreach (var pane in removeCandidates)
            {
                PromptDiagramClose(pane, new PaneClosingEventArgs());
                Instance.DocumentsPane.Items.Remove(pane);
            }
        }

        private ContentPane CreateDocument<T>(object arg) where T : Page
        {
            ContentPane pane = new ContentPane();

            var page = CreateNew<T>(arg);
            page.Tag = pane;

            pane.Tag = page.GetType().Name + ":" + (arg != null ? arg.ToString() : "");
            pane.CloseAction = PaneCloseAction.RemovePane;

            Frame frame = new Frame();
            frame.Navigate(page);

            pane.Content = frame;
            return pane;
        }

        private T CreateNew<T>(object arg)
        {
            if (arg == null)
            {
                var cons = typeof(T).GetConstructor(new Type[0]);
                if (cons != null) return (T) cons.Invoke(new object[0]);
            }

            var constructor = typeof(T).GetConstructors().First(c => c.GetParameters().Length == 1);
            if (constructor == null)
                throw new ArgumentException("No single argument constructor can be found");
            return (T) constructor.Invoke(new[] {arg});
        }
    }
}