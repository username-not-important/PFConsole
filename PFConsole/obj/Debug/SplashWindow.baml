   M S B A M L   `   `   `  ????D  @PFConsole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:PFConsole	PFConsole  5   	       PFConsole.SplashWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   )localclr-namespace:PFConsole     5   	   -   5          ?Name$  window??5   /    ? WindowStyle$
 None=?5   	   ???#107cae ? WindowStartupLocation$ CenterScreen=?5   	    ? Title$ SplashWindow??5   	   $	??310??6   $	??550??6+    ? AllowsTransparency .  ? 
ResizeMode$ NoResize=?6Q    ? Topmost .  ? 	Resources 5         LoadStoryboard ?? TargetProperty	 ?? 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame
 O? KeyTime O? Value   EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode8  2System.Windows.Media.Animation.EasingColorKeyFrame ?? KeyTime ?? Value   EasingFunction??%g  &	        ?? 5	      .??5
      U? $ (UIElement.Opacity)?6#   $
	 grid??6S   .\?5        $
 0??6   $ 0Q?6'     5      $
 0:0:0.1??6   $ 0Q?6-     5      $
 0:0:0.6??6   $ 1Q?6-    5        5      $ EaseOut=?6   5      5      ?? 5      $0 *(Panel.Background).(SolidColorBrush.Color)?6"   $	 window??6i   .g?5        $ 0??6   $ 	#00107CAE??6&     5      $ 0:0:0.1??6   $ 	#FF107CAE??6,    5        5      $ EaseOut=?6   5      5      U? 5      $U O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)?6#   $
	 grid??6?   .\?5        $
 0??6   $ 0Q?6'     5      $
 0:0:0.1??6   $ 5Q?6-     5      $
 0:0:0.6??6   $ 0Q?6-    5        5       $ EaseOut=?6   5"      5#      5$      5%       ? Triggers 5&      :? 5'       :? RoutedEvent$ FrameworkElement.Loaded??6   .[?5(      ?? #??[  6   5)      .??5+      ? -   5         ?Name$
 grid??5+       J? RenderTransformOrigin$ 0.5,0.5&?6A   z?5,      V? 5-      .~?5.      ?? ?? 5/      ?? 50      T? 51      52      .+?54      ?? -   5         ??Name$ _LoadingText??54   x   $??Starting...??6   $??Bottom=?6!   $??7q?6<   ???#FBFBFB$??Segoe UI Light)?6\   6x   ?? 55      -   5        $ 	textBlock??55      $
??Left=?6!   $
??Wrap=?6<   $	??Top=?6P   $??7,3,7,7q?6h   $??21.333(?6y   
???????$??Italic$?6?   $??Segoe WP Semibold)?6?   $
??Bold"?6?   $??24.83??6?   ?? 6?   $	?Jey??6?   $??18.667(?6  ?? 6  $	?ART??6  $??16(?6$  65  ?? 56       ?? Orientation$ 
Horizontal=?6   $??Center=?6(   $??Center=?6C   .+?57      ?? -   5        $ 
textBlock1??57      $??Center=?6#   $
??Wrap=?6@   $??Center=?6T   $??48(?6o   $??Segoe UI Light)?6}   
???????$??0q?6?   ?? 6?   $
?PF C??6?   ?? 6?   .F?58         PFConsole.BusyIcon  -   5          Name$ busyIcon??58      $
??Left=?6'   $??Center=?6B   $ 0.5,0.5&?6]   z?59      V? 5:      .~?5;   	   ??  ?? ScaleX$	 0.6Q?6    ?? ScaleY$	 0.6Q?6%   ?? 5<   	   ?? 5=   	   T? 5>   	    T? Y$ 13Q?6   5?   	   5A      5B      ?? 6   $?nsole??6   6-   5C      ?? 5D      -   5         ??Name$ 
stackPanel??5D      $ Vertical=?6#   $??Right=?6:   $	??Top=?6V   $??7q?6n   .+?5E      ?? -   5         ??Name$ _CloseButton??5E      $?? ??6"   $
??Left=?6-   $	??Top=?6H   $??24??6`   $??24??6k     
FlatButton#???  6w     CloseButtonTemplate#???  6?   
??????????	#FFEFEFEF6?   5F      5G      5H      