   M S B A M L   `   `   `  ????C  ?PFModels, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?-clr-namespace:PFModels.Data;assembly=PFModelsPFModels.Data  5   	   D @PFConsole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null;"clr-namespace:PFConsole.ConvertersPFConsole.Converters 5   	   7 clr-namespace:PFConsole.ControlsPFConsole.Controls 5   	   Q-clr-namespace:PFConsole.Controls.QueueContentPFConsole.Controls.QueueContent 5	   	   ,   &PFConsole.ChildWindows.EditQueueWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   m iInfragisticsWPF4.Editors.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb-editorshttp://infragistics.com/Editors  5   	   8data-clr-namespace:PFModels.Data;assembly=PFModels  5   	   n jInfragisticsWPF4.DragDrop.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? |InfragisticsWPF4.Controls.Editors.XamSlider.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb?	 ~InfragisticsWPF4.Controls.Editors.XamCalendar.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb?
 ?InfragisticsWPF4.Controls.Editors.XamDateTimeInput.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? ?InfragisticsWPF4.Controls.Editors.XamPropertyGrid.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbe aInfragisticsWPF4.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb| xInfragisticsWPF4.Documents.TextDocument.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbj fInfragisticsWPF4.Undo.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? ?InfragisticsWPF4.Controls.Editors.XamMaskedInput.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbw sInfragisticsWPF4.DataVisualization.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? |InfragisticsWPF4.Controls.Charts.XamDiagram.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbw sInfragisticsWPF4.Themes.Office2013.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cb? ?InfragisticsWPF4.Controls.Editors.XamColorPicker.v15.2, Version=15.2.20152.1000, Culture=neutral, PublicKeyToken=7dd5c3163f2cd0cbEig$http://schemas.infragistics.com/xaml   	 
          5   	   K
converters"clr-namespace:PFConsole.Converters   	 
          5   	   Gcontrols clr-namespace:PFConsole.Controls   	 
          5   	   XqueueContent-clr-namespace:PFConsole.Controls.QueueContent   	 
          5	   	   -   5          ?Name$  Window??5
   	    ? Title$ 	New Queue??5       ? SizeToContent$ Height=?6   $	??550??5         ArtChildWindowStyle#???   6    J? CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$
 Save??5      6L    ? 	Resources 5      ??%    5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??64.8 ?6   ?? 5      .+?5   
   ]? $??30,0,0,0q?6   ??. .+?5      ?? $??
Edit Queue??6   $??16(?6*   $	??Top=?68   ?? 5      $??10,0,0,0q?6   $
??Auto=?6-   .??5      ?? $??12(?6   $??Light"?6*   $
??Wrap=?6=   $J??DChoose a unique name and a type, Then enter the required parameters.??6Q   5      5      ?? 5   
   $??	0,0.7,0,0q?6   
???????$??1??6@   ???	#FFFAFAFA._?5      ? $??5q?6    ? DataContext 6   ??  ?? ElementName$ Window??	 ?? Path$	 
QueueModel?.+?5      ?? $	??Top=?6   .+?5       ? 
 ? ColumnDefinitions
 5!      ?? 5"      $	??54* ?6/   ?? 5#      $
??199* ?6/   .+?5%      ?? $
??Name??6$   $??16(?60   ?? 5&      -   5         ??Name$ _TB_Name??5&   "   $??16(?64   $	??245??6B   $
??Left=?6N   $??1??5'   d   ??6)   ?? *Name+ ?? UpdateSourceTrigger$ PropertyChanged=?6d   5(      ? 5)      $??0,2,0,0q?6   
 5*      ?? 5+      $	??54* ?6/   ?? 5,      $
??199* ?6/   .+?5.      ?? $??	Scheduler??6$   $??16(?65   1  +Infragistics.Windows.Editors.XamComboEditor  5/      -   5          Name$ _CB_Type??5/   1   $??16(?6C   $	??245??6Q   $
??Left=?6]   $??1??50   P   .  (Infragistics.Windows.Editors.ValueEditor   ThemeD  >Infragistics.Windows.Themes.Internal.EditorsThemeTypeConverter$ 
Office2013 6`      SelectedItem 6)   ?? *SchedulerType+   ItemsProvider 51      8  2Infragistics.Windows.Editors.ComboBoxItemsProvider  52   "      Items 53   &   !   PFModels.Data.SchedulerType 54   *   HFSC=?6C    55   *   CBQ=?6B    56   *   PriQ=?6C   58   #   5:      5;      ? 5=      $??	0,20,0,30q?6   .+?5>      <  6PFConsole.Controls.QueueContent.QueueContentProperties  $??16(?6?      SchedulerType 6>   ?? $ Window??$	 QueueModel.SchedulerType? 6?   ?? $ Window??$	 QueueModel.Content?6?   5?      ?? 5A      -   5         ??Name$ _ErrorBlock??5A   a   $??
110,10,0,0q?6    
???  ??$	??Top=?6I   $y?	Collapsed=?6v   ?? 6?   .?6?   ?? $?Error:??6?   6?   ?? 6?   $? ??6?   ?? 6?   -   5         ??Name$ 
_ErrorText??5A   ?   6?   5C      ?? 5D       ?? Orientation$ 
Horizontal=?6   $??Bottom=?66   $??Right=?6Q   .+?5E      ?? $
??Save??6   $??0,0,5,0q?6,     
FlatButton#???  6=    ?? 	IsDefault . $
??Save??6s   ??6?   ?? $ _Window??5F      5G      5H      5J      5K      