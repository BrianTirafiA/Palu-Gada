   M S B A M L   `   `   `  ���� C  ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view  7 clr-namespace:PaluGada.viewModelPaluGada.viewModel       PaluGada.view.WishlistPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:PaluGada.view     3local1 clr-namespace:PaluGada.viewModel       N� 
Background
  ����� N� Title$ Wishlist Page��$
��1080��$
��1414�� � 	Resources  �� 
TargetType   RoundedButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%�   &	        �� " ��.���  � �� �� " ��.R��� #��z��#��z��$��1q�$ 10��# z��._��� $��Center=�$��Center=���  � ��
 �������  � ��
 �������  � ��$
 10,5q�.���� 
�������.+��� ._��� $��Wishlist��$��50(�$
��Bold"�$��
Montserrat)�$��10q�$��Center=�	 J� Effect	 3  -System.Windows.Media.Effects.DropShadowEffect  
   Color$
 Black��   
BlurRadius$ 40Q�   ShadowDepth$ 2Q�   Opacity$	 0.5Q��� $��10q����� *ItemListWishlist+���� .R��� 
�������$ 10��$	��150��$	��0,5q�._�� $��10q� � ColumnDefinitions �� $��* ��� $��5* ��� $��* �.+��� $��0������ *	ImagePath+� $��1��$��10,0,0,0q� � RowDefinitions �� $��* ��� $
��1.5* �.+��� $��0��$��40(�$��
Montserrat)�$
��Bold"�
���   ����� *Title+�� $��1��$��30(�$��
Montserrat)�$
��Wrap=�
���   ����� *Description+� $��2�� �� $��* ��� $��* �.+��� -   $��
See Detail��$��0��
����� �#��[  
�������$
��Bold"�
 � Tag �� *ItemId+�� -   $��Remove��$��1��
���  ��#��[  
�������$
��Bold"� �� *ItemId+