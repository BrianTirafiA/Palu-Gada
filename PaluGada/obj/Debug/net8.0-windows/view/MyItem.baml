   M S B A M L   `   `   `  ����C  ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view  5          PaluGada.view.MyItem   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PaluGada.view     5        N� 
Background
  ����� N� Title$ mainmenu��5	      $
��1080��6   $
��1414��6&    � 	Resources 5       �� 
TargetType   RoundedButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%�  &	        �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $��1q�5      $ 10��5      # z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$
 10,5q�6(   5      5      .��5       �� .+�5!   
   �� ._�5"      �� $��My Item��6   $��50(�6&   $
��Bold"�64   $��
Montserrat)�6F   $��10q�6^   $��Center=�6j   	 J� Effect	 5#      3  -System.Windows.Media.Effects.DropShadowEffect  5$      
   Color$
 Black��6#      
BlurRadius$ 40Q�61      ShadowDepth$ 2Q�6A      Opacity$	 0.5Q�6Q   5&      �� 5(      $��10q�6B   ��6   �� *ItemListMyItem+��5)      �� 5*      .R�5+      �� 
�������$ 10��68   $	��150��6J   $	��0,5q�6X   ._�5,      � $��10q�6    � ColumnDefinitions 5-      �� 5.   "   $��* �63   �� 5/   "   $��5* �63   �� 50   "   $��* �63   .+�52      �� $��0��6$   ��64   �� *	ImagePath+� 54      $��1��6#   $��10,0,0,0q�63    � RowDefinitions 55   "   �� 56   &   $��* �64   �� 57   &   $
��1.5* �64   .+�59   "   �� $��0��6,   $��40(�6P   $��
Montserrat)�6^   $
��Bold"�6v   
���   ���69   �� *Title+6�   �� 5:   "   $��1��6,   $��30(�6V   $��
Montserrat)�6d   $
��Wrap=�6|   
���   ���69   �� *Description+6�   5;      � 5=      $��2��6#    5>   "   �� 5?   &   $��* �64   �� 5@   &   $��* �64   .+�5B   &   �� -   5        $��Remove��5B   -   $��1��5C   -   #��[  5D   -   
���  ��
�������$��0,0,0,5q�5G   -   $��80��5H   -   $
��Bold"�5I   -   
 � Tag 5J   -   �� *ItemId+5K   -   �� 5L   &   -   5        $��	Edit Item��5L   -   $��0��5M   -   #��[  5N   -   
��� ���
���   �$��80��5Q   -   $
��Bold"�5R   -    5S   -   �� *ItemId+5T   -   5U      5V      5X      5Y      5[      5\      5]      