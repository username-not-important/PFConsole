   M S B A M L   `   `   `  ????   	PFConsole3    -PFConsole.ChildWindows.EnterDiagramNameWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     ?Name$  Window?? ? Title$ New Diagram??$	??550??$	??235??   ArtChildWindowStyle#???    J? CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ Close??  -   $
 Save??.???  ? RowDefinitions ?? $
??64.8 ??? .+?]? $??30,0,0,0q???. .+??? $??New Diagram??$??16(?$	??Top=??? $??10,0,0,0q?$
??Auto=?.???? $??12(?$??Light"?$
??Wrap=?$)??#Enter the name for the new diagram.???? $??	0,0.7,0,0q?
???????$??1?????	#FFFAFAFA._?? $??5q? ? DataContext ??  ?? ElementName$ Window?? ?? Path$ InterfaceModel?.+??? $	??Top=?.+??  ? ColumnDefinitions ?? $	??54* ??? $
??199* ?.+??? $
??Name??$??16(??? -   	 ??Name$	 _TB_Name??$??16(?$	??245??$
??Left=?$??1?????? *Name+
 ?? UpdateSourceTrigger$
 PropertyChanged=??? -    ??Name$ _ErrorBlock??$??
110,10,0,0q?
???  ??$	??Top=?$y?	Collapsed=??? .??? $?Error:???? $? ???? -    ??Name$ 
_ErrorText????  ?? Orientation$ 
Horizontal=?$??Bottom=?$??Right=?.+??? $
??Save??$??0,0,5,0q?  
FlatButton#???   ?? 	IsDefault . $
??Save?????? $ _Window???? $??Cancel??#???   ?? IsCancel . $??Close?????? $ _Window??