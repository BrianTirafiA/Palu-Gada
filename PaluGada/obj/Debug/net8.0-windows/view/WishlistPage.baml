   M S B A M L   `   `   `  ����C  ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view  5      7 clr-namespace:PaluGada.viewModelPaluGada.viewModel  5           PaluGada.view.WishlistPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PaluGada.view     5      3local1 clr-namespace:PaluGada.viewModel     5        N� 
Background
  ����� N� Title$ Wishlist Page��5
      $
��1080��5      $
��1414��6    � 	Resources 5       �� 
TargetType   RoundedButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%�  &	        �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $��1q�5      $ 10��5      # z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$
 10,5q�6(   5      5       .��5"      �� 
�������.+�5#   
   �� ._�5$      �� $��Wishlist��6   $��50(�6'   $
��Bold"�65   $��
Montserrat)�6G   $��10q�6_   $��Center=�6k   	 J� Effect	 5%      3  -System.Windows.Media.Effects.DropShadowEffect  5&      
   Color$
 Black��6#      
BlurRadius$ 40Q�61      ShadowDepth$ 2Q�6A      Opacity$	 0.5Q�6Q   5(      �� 5*   
   $��10q�6@   ��6   �� *ItemListWishlist+��5+      �� 5,      .R�5-      �� 
�������$ 10��64   $	��150��6F   $	��0,5q�6T   ._�5/      � $��10q�6    � ColumnDefinitions 50      �� 51   "   $��* �63   �� 52   "   $��5* �63   �� 53   "   $��* �63   .+�55      �� $��0��6$   ��64   �� *	ImagePath+� 57      $��1��6#   $��10,0,0,0q�63    � RowDefinitions 58   "   �� 59   &   $��* �64   �� 5:   &   $
��1.5* �64   .+�5<   "   �� $��0��6,   $��40(�6P   $��
Montserrat)�6^   $
��Bold"�6v   
���   ���69   �� *Title+6�   �� 5=   "   $��1��6,   $��30(�6V   $��
Montserrat)�6d   $
��Wrap=�6|   
���   ���69   �� *Description+6�   5>      � 5@      $��2��6#    5A   "   �� 5B   &   $��* �64   �� 5C   &   $��* �64   .+�5E   "   �� -   5        $��
See Detail��5E   )   $��0��5F   )   
����� �#��[  5H   )   
�������$
��Bold"�5J   )   
 � Tag 5K   )   �� *ItemId+5L   )   �� 5M   "   -   5        $��Remove��5M   )   $��1��5N   )   
���  ��#��[  5P   )   
�������$
��Bold"�5R   )    5S   )   �� *ItemId+5T   )   5U      5V      5W      5X      5Z      5[      5\      