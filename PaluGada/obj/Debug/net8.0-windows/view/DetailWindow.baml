   M S B A M L   `   `   `  ����  PaluGada     PaluGada.view.DetailWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   ���#FFF1DB  � Title$  Item Detail��5   	   $	��450��6   $	��600��6*    � 	Resources 5       �� 
TargetType   RoundedButtonStyle �� Property �� Value �� 
TargetType �� CornerRadius �� Padding��%�  &	        �� 5   
   " ��6   .�5	      ��  � �� 5
      �� 5      " ��6&   .R�5      �� #��z��6!   #��z��5      $��1q�5      $ 10��5      # z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5      �� 5       � ��
 �����6+   �� 5       � ��
 �����6,   �� 5       � ��$
 10,5q�6(   5      5      .��5      � $��10q�6    � ColumnDefinitions 5   
   �� 5      $	��66* �6   �� 5       $	��79* �6   .+�5"   
    � -   5        	  �Name$	 	MainFrame��5"      
  � NavigationUIVisibility$
 Hidden=�6#   $��2��6C   �� 5$   
   $
��Auto=�6   $��Disabled=�6:   $��2��6c   .��5%      �� $��0,5,0,0q�6   .+�5&      �� ._�5'      �� -   5         ��Name$ ItemName��5'       $��
Montserrat)�62   $��20(�6J   $
��Bold"�6X   $��0,0,0,10q�6j    J� Effect 5(      3  -System.Windows.Media.Effects.DropShadowEffect  5)         Color$ Black��6+      
BlurRadius$ 40Q�69      ShadowDepth$ 2Q�6I      Opacity$	 0.5Q�6Y   5+      �� 5.      -   5         ��Name$ 	ItemImage��5.      $	��200��6+   $��0,0,0,10q�68   �� 51      -   5        $ ItemDescription��51      $��
Montserrat)�65   $
��Wrap=�6M   $��16(�6a   $��0,0,0,10q�6o   �� 54      -   5        $��Chat Seller��54      #��[  6/   $��
Montserrat)�6[   
����� �$	��150��6�   $��30��6�   $��Center=�6�   $��0,10,0,0q�6�   6�   �� 55      -   5        $��Add to Wishlist��55      #��[  63   
��� ���$��
Montserrat)�6r   $	��150��6�   $��30��6�   $��Center=�6�   $��0,10,0,0q�6�   �� 56      -   5        $��Close��56      #��[  6)   
���  ��$��
Montserrat)�6g   $	��150��6   $��30��6�   $��Center=�6�   $��0,10,0,0q�6�   57      58      59      5:      