   M S B A M L   `   `   `  ???? D  @PFConsole, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PFConsole.ViewsPFConsole.Views  )    #PFConsole.Views.Nodes.MacroNodeView   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /viewsclr-namespace:PFConsole.Views     -   $??_Control??  ? 	Resources     ToVisConverter . *TreeViewItem.TreeArrow.Static.Checked.Fill ?? Color 0 ,TreeViewItem.TreeArrow.Static.Checked.Stroke + 'TreeViewItem.TreeArrow.MouseOver.Stroke ) %TreeViewItem.TreeArrow.MouseOver.Fill 3 /TreeViewItem.TreeArrow.MouseOver.Checked.Stroke 1 -TreeViewItem.TreeArrow.MouseOver.Checked.Fill  	TreeArrow & "TreeViewItem.TreeArrow.Static.Fill (	 $TreeViewItem.TreeArrow.Static.Stroke 
 ExpandCollapseToggleStyle ?? 
TargetType ?? Property ?? Value ?? 
TargetType ?? Padding F?Name ?? Angle	 ?? CenterY
 ?? CenterX ?? Triggers P? Property P? Value ?? 
TargetName ]? 
Conditions ?? Property ?? Value??%?  &	        &	      &	      &	 /     &	 D     &	 [     &	 p     &	 ?     &	 ?     &		 ?     &	
 ?     7  7  7 	 7  7  7  7  7  7  ?? ?? $ 	#FF595959???? $ 	#FF262626???? $ 	#FF1BBBFA???? $ Transparent???? $ 	#FF262626???? $ 	#FF595959??B? $??M0,0 L0,6 L6,0 zC??? $ Transparent???? $ 	#FF989898???? " d?.???  ? |? .  ??  ? ??$ 16????  ? ??$ 16????  ? ?? ?? " d?.R??? 
?????? $??16??$ 5,5,5,5q?$??16??._?F? $ 
ExpandPath??8??  8?? 8?? z??? $	 135Q?$	 3Q?$
 3Q? P?  ?@d?	IsChecked$
 TrueY?. ??? $ 
ExpandPath?? ? z? ?? $	 180Q?$	 3Q?$
 3Q??? $ 
ExpandPath??8   ? ???? $ 
ExpandPath??8   ? ??P?  ?@J?IsMouseOver . . ??? $ 
ExpandPath??8   ? ???? $ 
ExpandPath??8   ? ??]?  ??  ?@J?IsMouseOver . ??  ?@d?	IsChecked$
 TrueY?./??? $ 
ExpandPath??8   ? ???? $ 
ExpandPath??8   ? ??.???? $	??150??.+??? $??21?? ?? Orientation$ 
Horizontal=?.+?d? -    d?Name$ Expander?? ?? 	ClickMode$ Press=?#??[
 ?? $ 
Horizontal=?$??4,0,0,0q?.+?F?  ?? Stretch$
 Fill=?$??16?????	#FF424242?????4?_ ?Q ???TN?F lF@?@ t?6@?@ ???T@?@ ?`?4@?@ ??z?Z ???_{f @Q ??5^?I?P@Ӏ?І	е(d???>l?'?d?S??0?`m?y+x?}t!??ED?S?(?LӠ?&|'?,$?6?,? I>?,h?E??*??L??'?l?S??$?7Zԉ  ?_L?4?j0??p܂??p<??Ԩp??z ??p??k  ?j??\ 4?_ ?Q ?@[Hd??@[H????F`F?4C??????A?E ܐ????a=?{Ӱ?6l:?/???*?H.?!?P@?@?S??(ӰP??$??J?"?E?"???@?"?e;??$d{7??(Q Ra?H.?!?P@ӴR\$??jT<)N?{S?iG'?????P@(?B???H?P@?Cd?Q?B?_{f @??B?q ??JLi ??TLi ?t?6Li ? [;Li ???Z?j 09C?Sn ?4?F`?q heH?"v T`H?_{f @?@[Hd?$??10???? $??Center=?$??6,0,0,0q??? $?$???? $? ???? $??SemiBold"?.??? ??? *Name+&    PFConsole.Views.MacroContentView  -     Name$ _ContentView?????	#05424242$??Center=?$??40,2,0,0q?y???  ?? ElementName$ Expander?? ?? Path$ 	IsChecked? ?? 	Converter# [     MacroContentModel ?? *	Content+