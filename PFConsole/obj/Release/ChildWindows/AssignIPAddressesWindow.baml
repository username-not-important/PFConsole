   M S B A M L   `   `   `  ???? O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  D @PFConsole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PFConsole.ControlsPFConsole.Controls 4   .PFConsole.ChildWindows.AssignIPAddressesWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     9system&clr-namespace:System;assembly=mscorlib     5Controls clr-namespace:PFConsole.Controls     -     ?Name$  Window?? ? Title$ Assign Macro??$	??550??$	??600??   ArtChildWindowStyle#???    ? 
ResizeMode$ CanResizeWithGrip=? J? CommandBindings )  #System.Windows.Input.CommandBinding  -      Command$ Close??  -   $
 Save??.???  ? DataContext ?? *OptionModel+ ?? ElementName$ _Window?? ? RowDefinitions ?? $
??64.8 ??? .+?]? $??30,0,0,0q???. .+??? $??Assign IP Addresses??$??16(?$	??Top=??? $??10,0,0,0q?$
??Auto=?.???? $??12(?$??Light"?$
??Wrap=?$@??:Enter IP Addresses or choose Macros from the list and add.???? $??	0,0.7,0,0q?
???????$??1?????	#FFFAFAFA._?? $??5q? ?? *InterfaceModel+$ Window??.+?]? $??Stretch=?$??0,0,0,30q?.+?? $	??Top=?$??0,2,0,0q? ? ColumnDefinitions ?? $
??108* ??? $
??318* ??? $	??79* ?.+?"  PFConsole.Controls.ListInput  -   	  Name$	 
_ListInput??$	??300??$??1??
   	InputType
 ??IP Address(es)????  ?? Orientation$ 
Horizontal=?$??Bottom=?$??Right=?.+??? $
??Save??$??0,0,5,0q?  
FlatButton#???   ?? 	IsDefault . $
??Save?????? $ _Window??