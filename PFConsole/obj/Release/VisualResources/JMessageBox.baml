   M S B A M L   `   `   `  ????   	PFConsole+    %PFConsole.VisualResources.JMessageBox   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       ? Topmost  .  ? Title$ Message??$	??150??$	??200??   ArtParentWindowStyle#???    ? SizeToContent$ WidthAndHeight=? ? WindowStartupLocation$ CenterScreen=?.??? -   $??
LayoutRoot??'  !System.Windows.VisualStateManager   VisualStateGroups %  System.Windows.VisualStateGroup  -   ButtonStates??   States.    System.Windows.VisualState  -   OK??  -   OKCancel??   
Storyboard. ?? .??T?  ?? TargetProperty$ (UIElement.Visibility)? ?? 
TargetName$ button??..?i? 	 R? KeyTime$	 0??  System.Windows.Visibility
   Visible R? Value# Z
   -   	YesNo??. ?? .??T? $ (UIElement.Visibility)?$ button1??..?i? $	 0??   	Collapsed# Z T? $ (UIElement.Visibility)?$ button2??..?i? $	 0??# Z
 T? $ (UIElement.Visibility)?$ button3??..?i? $	 0??# Z
   -   YesNoCancel??. ?? .??T? $ (UIElement.Visibility)?$ button1??..?i? $	 0??# Z T? $ (UIElement.Visibility)?$ button2??..?i? $	 0??# Z
 T? $ (UIElement.Visibility)?$ button3??..?i? $	 0??# Z
 T? $ (UIElement.Visibility)?$ button??..?i? $	 0??# Z
 .+??? .+?]? $??5q???. .+??? -    ??Name$ _imageblock??$
??Left=?$	??Top=?$??10q?$
??Left=??? -    ??Name$ 
_textblock??$	??Top=?$??14(?$??Segoe UI Semilight)??? $??5,20,5,5q?$??Center=? ?? Orientation$ 
Horizontal=?.+??? -	    ??Name$ button1??  
FlatButton#???  $??0,0,5,0q?$??OK??
 ? Tag %  System.Windows.MessageBoxResult OK=??? -
   $ button2??#???  $??0,0,5,0q?$	??Yes??$y?	Collapsed=?  Yes=??? -   $ button3??#???  $??0,0,5,0q?$??No??$y?	Collapsed=?  No=??? -   $ button??#???  $??0,0,5,0q?$??Cancel??$y?	Collapsed=?  
Cancel=?