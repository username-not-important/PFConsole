using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using Infragistics.Controls.Charts;
using Infragistics.Documents;
using Infragistics.Documents.Parsing;
using Infragistics.Themes;
using Infragistics.Windows.Ribbon;
using Infragistics.Windows.Ribbon.Events;
using Microsoft.Win32;
using PFConsole.Annotations;
using PFConsole.ChildWindows;
using PFConsole.ContentPages;
using PFConsole.Logs;
using PFConsole.Project;
using PFConsole.Project.Compiler;
using PFConsole.Properties;
using PFConsole.Util;
using PFConsole.Util.Language;
using PFConsole.VisualResources;
using PFModels.Data;
using ThemeManager = Infragistics.Themes.ThemeManager;

namespace PFConsole
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : INotifyPropertyChanged
    {
        public MainWindow()
        {
            Logger.Instance.Log("Main Window Started.");
            try
            {
                InitializeComponent();
            }
            catch (Exception e)
            {
                Logger.Instance.Log("Main Window Initialization Failed.\n" + e.ToString());
                Environment.Exit(99);
            }

            var lang = PFConfLanguage.Instance;
            App.splashScreen.AddMessage("Compiler Engine is Ready...");

            Logger.Instance.Log("Compiler Startup Complete.");

            WindowManager.Instance.DocumentsPane = _MainContentPane;

            PFDiagramPage.ActiveInstanceChanged += (sender, args) =>
            {
                if (_DiagramContextualGroup.IsVisible)
                {
                    _Ribbon.SelectedTab = _DiagramContextualGroup.Tabs[0];
                    _Pane_Toolbox.Visibility = Visibility.Visible;
                    _Pane_Properties.Visibility = Visibility.Visible;
                }
                else
                {
                    _Pane_Toolbox.Visibility = Visibility.Collapsed;
                    _Pane_Properties.Visibility = Visibility.Collapsed;
                }
            };

            DiagramManager.Instance.PropertyChanged += (sender, args) =>
            {
                if (args.PropertyName == "SelectedDiagramItem")
                    _Prop.SelectedObject = DiagramManager.Instance.SelectedDiagramItem;
            };

            Logger.Instance.LogInProgress += InstanceOnLogInProgress;
            Logger.Instance.Log("PF Console Main Window Loaded.");

            _DiagramToolbox.Categories.RemoveAt(0);
            _DiagramToolbox.Categories.RemoveAt(0);

        }


        private void _Window_ContentRendered(object sender, EventArgs e)
        {
            App.splashScreen.LoadComplete();
        }

        private void _Window_Loaded(object sender, RoutedEventArgs e)
        {
            string layoutpath = Environment.CurrentDirectory + "\\" + Settings.Default.LAYOUT_FILE;
            if (!File.Exists(layoutpath))
                return;

            string layout = File.ReadAllText(layoutpath);
            MemoryStream stream = new MemoryStream();

            try
            {
                StreamWriter sw = new StreamWriter(stream, Encoding.UTF8);
                sw.Write(layout);
                sw.Flush();
                stream.Position = 0;

                _DockManager.LoadLayout(stream);
                _Pane_Toolbox.Visibility = Visibility.Collapsed;
                _Pane_Properties.Visibility = Visibility.Collapsed;
            }
            catch (NotImplementedException)
            {}
            finally
            {
                stream.Close();
            }

            App.splashScreen.AddMessage("Layout Loaded...");

        }

        private void _Window_Closing(object sender, CancelEventArgs e)
        {
            MemoryStream stream = new MemoryStream();

            try
            {
                _DockManager.SaveLayout(stream);

                stream.Position = 0;
                StreamReader sr = new StreamReader(stream);
                string layout = sr.ReadToEnd();

                File.WriteAllText(Environment.CurrentDirectory + "\\" + Settings.Default.LAYOUT_FILE, layout, Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Logger.Instance.Log("Exception during layout Save:" + Environment.NewLine + ex.Message);
            }
            finally
            {
                stream.Close();
            }
        }

        private void InstanceOnLogInProgress(object sender, string time, string feedback)
        {
            Paragraph p = new Paragraph();
            p.Inlines.Add(new Italic(new Run(time)));
            p.Inlines.Add(new Run(feedback));

            _OutputBox.Document.Blocks.Add(p);
        }

        private bool PromptSave()
        {
            if (PFProject.Instance.RequiresSave)
            {
                var prompt = JMessageBox.Show("Save Changes to project before closing it?", "Save Changes", MessageBoxButton.YesNoCancel, MessageBoxImage.Question);
                if (prompt == MessageBoxResult.Cancel) return false;
                if (prompt == MessageBoxResult.Yes)
                {
                    WindowManager.CloseAll();
                    PFProject.Save();
                }

                return true;
            }

            return true;
        }

        #region FileCommands

        private void CloseCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (PromptSave())
            {
                PFProject.Close();
                Close();
            }
        }

        private void NewCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!PromptSave())
                return;

            PFProject.Close();
            NewProjectWindow win = new NewProjectWindow();
            win.ShowDialog();
        }

        private void SaveCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            PFProject.Save();
        }

        private void OpenCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            if (!PromptSave())
                return;

            PFProject.Close();
            OpenFileDialog dialog = new OpenFileDialog {CheckPathExists = true, Filter = "PF Project files (*.pfp)|*.pfp"};
            var dialogresult = dialog.ShowDialog();

            if (dialogresult != null && dialogresult == true)
                PFProject.Load(dialog.FileName);
        }

        #endregion

        #region Ribbon

        private void Ribbon_Options_FontSize_ItemClicked(object sender, RoutedEventArgs e)
        {
            double baseSize = Double.Parse((sender as ButtonTool).Tag.ToString());

            ViewOptionsPage.SetFontBase(baseSize);
        }

        private void Ribbon_Options_DisplayMode_ItemClicked(object sender, RoutedEventArgs e)
        {
            string mode = (sender as ButtonTool).Tag.ToString();

            ViewOptionsPage.SetDisplayMode(mode);
        }

        private void Ribbon_Options_GrouppingMode_ItemClicked(object sender, RoutedEventArgs e)
        {
            string mode = (sender as ButtonTool).Tag.ToString();

            ViewOptionsPage.SetGrouppingMode(mode);
        }

        private void _Button_ViewOptions_Clicked(object sender, RoutedEventArgs e)
        {
            WindowManager.CreateDocument<ViewOptionsPage>(true, null);
        }

        private void _ModifyOption_ItemClicked(object sender, GalleryItemEventArgs e)
        {
            WindowManager.CreateWindow<ModifyOptionWindow>(true, e.Item.Key);
        }

        #endregion

        private void _MenuItem_AddInterface_Clicked(object sender, RoutedEventArgs e)
        {
            WindowManager.CreateWindow<NewInterfaceWindow>(true, null);
        }

        private void _FirewallExplorer_Options_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            WindowManager.CreateDocument<ViewOptionsPage>(true, 0);
        }

        private void _Button_OutputClear_Click(object sender, RoutedEventArgs e)
        {
            _OutputBox.Document.Blocks.Clear();
        }

        private void _Button_CloseProject(object sender, RoutedEventArgs e)
        {
            if (PromptSave())
                PFProject.Close();
        }

        private void _Button_AssignMacro_Clicked(object sender, RoutedEventArgs e)
        {
            WindowManager.CreateWindow<AssignMacroWindow>(false, null);
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

        private void _Button_CreateTable_Clicked(object sender, RoutedEventArgs e)
        {
            WindowManager.CreateWindow<CreateTableWindow>(false, null);
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = PFProject.Instance.ProjectLoaded;
        }

        private void _Button_NewDiagram_Click(object sender, RoutedEventArgs e)
        {
            WindowManager.CreateDocument<PFDiagramPage>(true, "");
        }

        private void Ribbon_DiagramTools_ToolChanged(object sender, RoutedEventArgs e)
        {
            if (((RadioButtonTool) sender).Tag == null)
                return;

            var tool = ((RadioButtonTool) sender).Tag.ToString() == "Select" ? DiagramTool.Pointer : DiagramTool.Connector;

            foreach (var document in WindowManager.Instance.OpenDocuments)
                if (document.TabHeader.ToString().Contains("(diagram)"))
                    ((document.Content as Frame).Content as PFDiagramPage)._Diagram.Tool = tool;
        }

        private void Ribbon_DiagramTools_DragInteractionChanged(object sender, RoutedEventArgs e)
        {
            if (((RadioButtonTool) sender).Caption == null)
                return;

            DiagramDragInteraction interaction = DiagramDragInteraction.None;
            switch (((RadioButtonTool) sender).Caption)
            {
                case "Select":
                    interaction = DiagramDragInteraction.Select;
                    break;
                case "Pan":
                    interaction = DiagramDragInteraction.Pan;
                    break;
                case "Zoom":
                    interaction = DiagramDragInteraction.Zoom;
                    break;
                case "None":
                    interaction = DiagramDragInteraction.None;
                    break;
            }

            foreach (var document in WindowManager.Instance.OpenDocuments)
                if (document.TabHeader.ToString().Contains("(diagram)"))
                    ((document.Content as Frame).Content as PFDiagramPage)._Diagram.DefaultDragInteraction = interaction;
        }

        private void PropertyGrid_IPAddressList_Edit(object sender, RoutedEventArgs e)
        {
            var data = (sender as Button).Tag as ObservableCollection<MacroContent>;

            AssignIPAddressesWindow win = new AssignIPAddressesWindow(data);
            win.ShowDialog();

            var tb = (((sender as Button).Parent as Grid).Children[0] as TextBox);
            var dc = tb.DataContext;

            tb.DataContext = null;
            tb.DataContext = dc;
        }

        private void PropertyGrid_PortList_Edit(object sender, RoutedEventArgs e)
        {
            var data = (sender as Button).Tag as ObservableCollection<MacroContent>;

            AssignPortsWindow win = new AssignPortsWindow(data);
            win.ShowDialog();

            var tb = (((sender as Button).Parent as Grid).Children[0] as TextBox);
            var dc = tb.DataContext;

            tb.DataContext = null;
            tb.DataContext = dc;
        }

        private void _Button_GenPreview_Click(object sender, RoutedEventArgs e)
        {
            // Create a TextDocument and set the language to "CustomXMLLanguage"
            var td = new TextDocument();
            td.Language = PFConfLanguage.Instance;

            // Clear the document and add the content of the text box
            td.Delete();
            td.Append(PFConfCompiler.Instance.Compile(PFProject.Instance));
            td.Parse();

            // Get the snapshot from which the tree was created
            TextDocumentSnapshot snapshot = td.SyntaxTree.Snapshot;

            // Get a token enumerator which includes all tokens
            IEnumerable<Token> tokens = snapshot.GetTokens();

            // Create a flow document for the Rich Text Box
            var doc = new FlowDocument();
            var paragraph = new Paragraph();
            doc.Blocks.Add(paragraph);
            Run run;

            doc.MinPageWidth = 1000;

            // Iterate over the token produced during the parsing
            // Assign a color depending on their terminal symbol
            // Add the tokens in the Rich Text Box
            foreach (Token token in tokens)
            {
                if (token.Text.Length != 0)
                {
                    run = new Run();
                    run.Text = token.Text;
                    // Set the color for the token based on what we defined in the language.
                    Color c = PFConfLanguage.GetColor(token.TerminalSymbol);
                    run.Foreground = new SolidColorBrush(c);
                    paragraph.Inlines.Add(run);
                }
                else
                {
                    continue;
                }
            }
            this._PreviewBox.Document = doc;
        }
    }
}