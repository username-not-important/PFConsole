   M S B A M L   `   `   `  ????O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   D @PFConsole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PFConsole.ControlsPFConsole.Controls 5   	   .   (PFConsole.ChildWindows.AssignPortsWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9system&clr-namespace:System;assembly=mscorlib     5   	   5Controls clr-namespace:PFConsole.Controls     5   	   -   5          ?Name$  Window??5   	    ? Title$ Assign Macro??5      $	??550??5      $	??600??6      ArtChildWindowStyle#???   6    ? 
ResizeMode$ CanResizeWithGrip=?6I    J? CommandBindings 5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ Close??5
      6)     5   
   -   5        $
 Save??5      6L   .??5      ?  ? DataContext 6   ?? *OptionModel+ ?? ElementName$ _Window?? ? RowDefinitions 5   
   ?? 5      $
??64.8 ?6   ?? 5      .+?5   
   ]? $??30,0,0,0q?6   ??. .+?5      ?? $??Assign Ports??6   $??16(?6,   $	??Top=?6:   ?? 5      $??10,0,0,0q?6   $
??Auto=?6-   .??5      ?? $??12(?6   $??Light"?6*   $
??Wrap=?6=   $9??3Enter Ports or choose Macros from the list and add.??6Q   5      5      ?? 5   
   $??	0,0.7,0,0q?6   
???????$??1??6@   ???	#FFFAFAFA._?5      ? $??5q?6    6   ?? *InterfaceModel+$ Window??.+?5      ]? $??Stretch=?6   $??0,0,0,30q?68   .+?5      ? $	??Top=?6   $??0,2,0,0q?60    ? ColumnDefinitions 5      ?? 5      $
??108* ?6/   ?? 5      $
??318* ?6/   ?? 5       $	??79* ?6/   .+?5"      "  PFConsole.Controls.ListInput  -   5        	  Name$	 
_ListInput??5"   =   $	??300??6-   $??1??5#   5   
   	InputType
 5$      ??5%   "   Port Value(s)??6?   5'      5)      5,      ?? 5-       ?? Orientation$ 
Horizontal=?6   $??Bottom=?66   $??Right=?6Q   .+?5.      ?? $
??Save??6   $??0,0,5,0q?6,     
FlatButton#???  6=    ?? 	IsDefault . $
??Save??6s   ??6?   ?? $ _Window??5/      50      51      53      54      