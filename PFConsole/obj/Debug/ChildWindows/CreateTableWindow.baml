   M S B A M L   `   `   `  ????D  @PFConsole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:PFConsole.ControlsPFConsole.Controls  5   	   ;"clr-namespace:PFConsole.ConvertersPFConsole.Converters  5   	   .    (PFConsole.ChildWindows.CreateTableWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   5Controls clr-namespace:PFConsole.Controls     5   	   9
converters"clr-namespace:PFConsole.Converters     5   	     ? Title$  Create Table??5
   	   $	??550??5      $	??650??6      ArtChildWindowStyle#???   6    ? 	Resources 5      4   .PFConsole.Converters.BoolToVisibilityConverter  BoolToVisibilityConverter??%   &	         5   
   6/   5       J? CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$ Close??5      6)     5   
   -   5        $
 Save??5      6L     5   
   -   5        $ SaveAs??5      6N   .??5      ?  ? DataContext 6   ?? *OptionModel+ ?? ElementName$ _Window?? ? RowDefinitions 5   
   ?? 5      $
??64.8 ?6   ?? 5      .+?5   
   ]? $??30,0,0,0q?6   ??. .+?5      ?? $??Create Table??6   $??16(?6,   $	??Top=?6:   ?? 5      $??10,0,0,0q?6   $
??Auto=?6-   .??5      ?? $??12(?6   $??Light"?6*   $
??Wrap=?6=   $???9Enter a name for the new table and choose its properties.??6Q   5      5      ?? 5   
   $??	0,0.7,0,0q?6   
???????$??1??6@   ???	#FFFAFAFA._?5       ? $??5q?6    6   ?? *InterfaceModel+$ Window??.+?5!      ]? $??Stretch=?6   $??0,0,0,30q?68   .+?5"      ? $??506.2??6   $	??Top=?6)    ? ColumnDefinitions 5#      ?? 5$      $	??54* ?6/   ?? 5%      $
??158* ?6/   ?? 5&      $	??41* ?6/   .+?5(      ?? $
??Name??6$   $??16(?60   ?? 5)      -   5         ??Name$ _TB_Name??5)   "   $??16(?64   $??1??5*   L   ??6   ?? *Name+	 ?? UpdateSourceTrigger$	 PropertyChanged=?6L   5+      ?? 5-      -   5        
 ??Name$
 _ErrorBlock??5-   u   $	??Top=?6    $??	110,2,0,2q?65   
???  ??$	??Top=?6]   $y?	Collapsed=?6?   ?? 6?   .?6?   ?? $?Error:??6?   6?   ?? 6?   $? ??6?   ?? 6?   -   5         ??Name$ 
_ErrorText??5-   ?   6?   ? 5/      $??0,2,0,0q?6   $??506.2??6,   $	??Top=?6:    50      ?? 51      $	??54* ?6/   ?? 52      $
??159* ?6/   ?? 53      $	??40* ?6/   .+?55      ?? $??
Attributes??6$   $??16(?66   ?? 56      $??1??6%    ?? Orientation$ Vertical=?65   .+?57      	? -   5         	?Name$ _Radio_Attrib_None??57   z   $
??None??6*   $??16(?69   $??Center=?6G    d? 	IsChecked$
 TrueY?6i   6z   	? 58      -   5        $ _Radio_Attrib_Const??58   j   $??Const??6*   $??16(?6:   $??Center=?6H   6j   	? 59      -	   5        $ _Radio_Attrib_Persist??59   l   $??Persist??6*   $??16(?6<   $??Center=?6J   6l   5:      5;      ? 5<      $??0,10,0,0q?6   $??506.2??6-   $	??Top=?6;    5=      ?? 5>      $
??108* ?6/   ?? 5?      $
??318* ?6/   ?? 5@      $	??79* ?6/   .+?5B      ?? $??Value??6$   $??16(?61   ?? 5C      $??1??6%   .+?5D      	? $
??None??6*   $??16(?69   $
 TrueY?6G   	? 5E      -
   5        $ _Radio_File??5E   L   $??	From File??6*   $??16(?6>   6L   ? 5F      y?6#   ?? $ _Radio_File?? ?? Path$ 	IsChecked? ?? 	Converter# [ .+?5G   "   ?? -   5        $ _TB_FileName??5G   8   $??16(?6*   68   5H      	? 5I      -   5        $ _Radio_IPList??5I   J   $??IP List??6*   $??16(?6<   6J   ? 5J      $??0,2,0,0q?6?   y?6#   ?? $ _Radio_IPList??$ 	IsChecked?# [ .+?5K   "   "   PFConsole.Controls.ListInput  -   5          Name$ 
_ListInput??5K   s      
ShowMacros .  $	??300??6H      	InputType$ IP Address(es)??6X   6s   5L      5M      5N      5P      ?? 5Q      $ 
Horizontal=?6   $??Bottom=?66   $??Right=?6Q   .+?5R      ?? $??Save & Clear??6   $??0,0,5,0q?68     
FlatButton#???  6I   $??SaveAs??6n   ??6   ?? $ _Window???? 5S      $
??Save??6   $??0,0,5,0q?6,   #???  6=    ?? 	IsDefault . $
??Save??6s   ??6?   ?? $ _Window???? 5T      $??Cancel??6   #???  6.    ?? IsCancel . $??Close??6c   ??6s   ?? $ _Window??5U      5V      5W      5Y      5Z      