   M S B A M L   `   `   `  ????   	PFConsole    PFConsole.BusyIcon   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _Microsoft.Expression.Drawing, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35=ed4http://schemas.microsoft.com/expression/2010/drawing  -     >?Name$  UserControl??$??50??$??50??
??????? ? 	Resources    MainStoryboard g? RepeatBehavior ?? TargetProperty ?? 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O? KeyTime O? Value   EasingFunction.  (System.Windows.Media.Animation.PowerEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode	   Power-  'System.Windows.Media.Animation.SineEase??%?  &	        ?? $ Forever??.??U? $ (ed:Arc.EndAngle)?$	 arc??.\?  $ 0:0:1.4??$ 0Q?   $ EaseOut=?  $ 0:0:2??$ 0Q?  $ 0:0:2.5??$ 0Q?  $ 0:0:3.7??$ 0Q?U? $ (ed:Arc.EndAngle)?$
 arc1??.\?  $ 0:0:1.4??$ 0Q?   $ EaseOut=?$	 3Q?  $ 0:0:2??$ 0Q?  $ 0:0:2.7??$ 0Q?  $ 0:0:3.7??$ 0Q?U? $ (ed:Arc.EndAngle)?$
 arc2??.\?  $ 0:0:1.4??$ 0Q?   $ EaseOut=?$	 4Q?  $ 0:0:2??$ 0Q?  $ 0:0:3??$ 0Q?  $ 0:0:3.7??$ 0Q?U? $ (ed:Arc.EndAngle)?$
 arc3??.\?  $ 0:0:1.4??$ 0Q?   $ EaseOut=?$	 5Q?  $ 0:0:2??$ 0Q?  $ 0:0:3.2??$ 0Q?  $ 0:0:3.7??$ 0Q?U? $ (ed:Arc.EndAngle)?$
 arc4??.\?  $ 0:0:1.4??$ 0Q?   $ EaseOut=?$	 6Q?  $ 0:0:2??$ 0Q?  $ 0:0:3.4??$ 0Q?  $ 0:0:3.7??$ 0Q?U? $ (ed:Arc.StartAngle)?$	 arc??.\?  $ 0:0:2??$ 0Q?  $ 0:0:2.5??$
 -360Q?   $ 	EaseInOut=?  $ 0:0:3.7??$
 -360Q?U? $ (ed:Arc.StartAngle)?$
 arc1??.\?  $ 0:0:2??$ 0Q?  $ 0:0:2.7??$
 -360Q?   $ 	EaseInOut=?  $ 0:0:3.7??$
 -360Q?U? $ (ed:Arc.StartAngle)?$
 arc2??.\?  $ 0:0:2??$ 0Q?  $ 0:0:3??$
 -360Q?   $ 	EaseInOut=?  $ 0:0:3.7??$
 -360Q?U? $ (ed:Arc.StartAngle)?$
 arc3??.\?  $ 0:0:2??$ 0Q?  $ 0:0:3.2??$
 -360Q?   $ 	EaseInOut=?  $ 0:0:3.7??$
 -360Q?U? $ (ed:Arc.StartAngle)?$
 arc4??.\?  $ 0:0:2??$ 0Q?  $ 0:0:3.4??$
 -360Q?   $ 	EaseInOut=?  $ 0:0:3.7??$
 -360Q?
 ? Triggers
 :?  :? RoutedEvent$ FrameworkElement.Loaded??.[??? #??[  .??? -    ?Name$ 
LayoutRoot??.+?%  Microsoft.Expression.Shapes.Arc  -     Name$	 arc??   ArcThicknessUnit$ Pixel=?   EndAngle$	 360Q?$??Center=?$??15?? ?? Stretch$
 None=?   
StartAngle$ 0Q?$??Center=?$??15??
???????$	??1.5??  -   $
 arc1??$ Pixel=?$	 360Q?$??Center=?$??22??$
 None=?$ 0Q?$??Center=?$??22??
???????$	??1.5??  -   $
 arc2??$ Pixel=?$	 360Q?$??Center=?$??29??$
 None=?$ 0Q?$??Center=?$??29??
???????$	??1.5??  -   $
 arc3??$ Pixel=?$	 360Q?$??Center=?$??36??$
 None=?$ 0Q?$??Center=?$??36??
???????$	??1.5??  -   $
 arc4??$ Pixel=?$	 360Q?$??Center=?$??43??$
 None=?$ 0Q?$??Center=?$??43??
???????$	??1.5??