   M S B A M L   `   `   `  ???? C  ?PFModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?-clr-namespace:PFModels.Data;assembly=PFModelsPFModels.Data  D @PFConsole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PFConsole.ConvertersPFConsole.Converters 7 clr-namespace:PFConsole.ControlsPFConsole.Controls Q-clr-namespace:PFConsole.Controls.QueueContentPFConsole.Controls.QueueContent ,   &PFConsole.ChildWindows.EditQueueWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     m iInfragisticsWPF4.Editors.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb-editorshttp://infragistics.com/Editors  8data-clr-namespace:PFModels.Data;assembly=PFModels  n jInfragisticsWPF4.DragDrop.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? |InfragisticsWPF4.Controls.Editors.XamSlider.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb?	 ~InfragisticsWPF4.Controls.Editors.XamCalendar.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb?
 ?InfragisticsWPF4.Controls.Editors.XamDateTimeInput.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? ?InfragisticsWPF4.Controls.Editors.XamPropertyGrid.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbe aInfragisticsWPF4.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbj fInfragisticsWPF4.Undo.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? ?InfragisticsWPF4.Controls.Editors.XamMaskedInput.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbw sInfragisticsWPF4.DataVisualization.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? |InfragisticsWPF4.Controls.Charts.XamDiagram.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbw sInfragisticsWPF4.Themes.Office2013.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? ?InfragisticsWPF4.Controls.Editors.XamColorPicker.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbCig$http://schemas.infragistics.com/xaml   	 
         I
converters"clr-namespace:PFConsole.Converters   	 
         Econtrols clr-namespace:PFConsole.Controls   	 
         VqueueContent-clr-namespace:PFConsole.Controls.QueueContent   	 
         -     ?Name$  Window?? ? Title$ 	New Queue?? ? SizeToContent$ Height=?$	??550??   ArtChildWindowStyle#???    J? CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$
 Save?? ? 	Resources ??%    .???  ? RowDefinitions ?? $
??64.8 ??? .+?]? $??30,0,0,0q???. .+??? $??
Edit Queue??$??16(?$	??Top=??? $??10,0,0,0q?$
??Auto=?.???? $??12(?$??Light"?$
??Wrap=?$J??DChoose a unique name and a type, Then enter the required parameters.???? $??	0,0.7,0,0q?
???????$??1?????	#FFFAFAFA._?? $??5q? ? DataContext ??  ?? ElementName$ Window??	 ?? Path$	 
QueueModel?.+??? $	??Top=?.+?? 
 ? ColumnDefinitions
 ?? $	??54* ??? $
??199* ?.+??? $
??Name??$??16(??? -    ??Name$ _TB_Name??$??16(?$	??245??$
??Left=?$??1?????? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?? $??0,2,0,0q?
 ?? $	??54* ??? $
??199* ?.+??? $??	Scheduler??$??16(?1  +Infragistics.Windows.Editors.XamComboEditor  -     Name$ _CB_Type??$??16(?$	??245??$
??Left=?$??1??.  (Infragistics.Windows.Editors.ValueEditor   ThemeD  >Infragistics.Windows.Themes.Internal.EditorsThemeTypeConverter$ 
Office2013    SelectedItem ?? *SchedulerType+   ItemsProvider 8  2Infragistics.Windows.Editors.ComboBoxItemsProvider     Items !   PFModels.Data.SchedulerType HFSC=? CBQ=? PriQ=?? $??	0,20,0,30q?.+?<  6PFConsole.Controls.QueueContent.QueueContentProperties  $??16(?   SchedulerType ?? $ Window??$	 QueueModel.SchedulerType? ?? $ Window??$	 QueueModel.Content??? -    ??Name$ _ErrorBlock??$??
110,10,0,0q?
???  ??$	??Top=?$y?	Collapsed=??? .??? $?Error:???? $? ???? -    ??Name$ 
_ErrorText????  ?? Orientation$ 
Horizontal=?$??Bottom=?$??Right=?.+??? $
??Save??$??0,0,5,0q?  
FlatButton#???   ?? 	IsDefault . $
??Save?????? $ _Window??