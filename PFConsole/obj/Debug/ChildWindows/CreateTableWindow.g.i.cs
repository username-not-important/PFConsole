#pragma checksum "..\..\..\ChildWindows\CreateTableWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "722F032BFB0BDB6BA2DB30AA69CF7E76"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using PFConsole.Controls;
using PFConsole.Converters;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace PFConsole.ChildWindows {
    
    
    /// <summary>
    /// CreateTableWindow
    /// </summary>
    public partial class CreateTableWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _TB_Name;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock _ErrorBlock;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Documents.Run _ErrorText;
        
        #line default
        #line hidden
        
        
        #line 55 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton _Radio_Attrib_None;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton _Radio_Attrib_Const;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton _Radio_Attrib_Persist;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton _Radio_File;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox _TB_FileName;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton _Radio_IPList;
        
        #line default
        #line hidden
        
        
        #line 75 "..\..\..\ChildWindows\CreateTableWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal PFConsole.Controls.ListInput _ListInput;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/PFConsole;component/childwindows/createtablewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\ChildWindows\CreateTableWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 16 "..\..\..\ChildWindows\CreateTableWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.CloseCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 17 "..\..\..\ChildWindows\CreateTableWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.SaveCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 17 "..\..\..\ChildWindows\CreateTableWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 3:
            
            #line 18 "..\..\..\ChildWindows\CreateTableWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).CanExecute += new System.Windows.Input.CanExecuteRoutedEventHandler(this.SaveCommand_CanExecute);
            
            #line default
            #line hidden
            
            #line 18 "..\..\..\ChildWindows\CreateTableWindow.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.SaveAsCommand_Executed);
            
            #line default
            #line hidden
            return;
            case 4:
            this._TB_Name = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this._ErrorBlock = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this._ErrorText = ((System.Windows.Documents.Run)(target));
            return;
            case 7:
            this._Radio_Attrib_None = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 8:
            this._Radio_Attrib_Const = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 9:
            this._Radio_Attrib_Persist = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 10:
            this._Radio_File = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 11:
            this._TB_FileName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 12:
            this._Radio_IPList = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 13:
            this._ListInput = ((PFConsole.Controls.ListInput)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

