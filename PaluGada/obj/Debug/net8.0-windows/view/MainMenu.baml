   M S B A M L   `   `   `  ����C  ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view  5   	       PaluGada.view.MainMenu   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:PaluGada.view     5   	     � Title$  PaluGada��5   	   $
��1080��6   $
��1920��6(    � WindowState$ 	Maximized=�5	   	    � 	Resources 5
         SidebarButtonStyle �� 
TargetType �� Property �� Value �� Triggers �� Binding �� Value��%�  &	        �� 5   
   " ��6+   .�5      ��  � �� �#BEEBAD6+   �� 5       � ��
 �����6+   �� 5       � ��$ 40(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$	 111��6'   �� 5       � ��$ 0,10,0,0q�6'   �� 5       � ��$ 
Montserrat)�6+    5      �� 5       6   �� *
IsActive+ True6;   .a�5      ��  � �� �#378C8763   5      5      5      .��5      � 	 � ColumnDefinitions	 5   
   �� 5       $��1* �6   �� 5!      $��3* �6   .+�5%   
   �� $��0��6   ���#BEEBAD._�5&      (� .��5'      �� .+�5(      �� $��PALU GADA APP��6   $��
Montserrat)�64   $��Center=�6L   $��40(�6i   $��0,0,0,0q�6w   $
��Bold"�6�   �� 5)      -   5        
 ��Name$
 
HomeButton��5)      $
��Home��61   #��[  6@   $��0q�6�   �� 5*      -   5        $��Add Post��5*      #��[  60   $��0q�6x   �� 5+      -   5        $��My Item��5+      #��[  6/   $��0q�6v   �� 5,      -   5        $��Wishlist��5,      #��[  60   $��0q�6y   �� 5-      -   5        $
��Chat��5-      #��[  6,   $��0q�6q   �� 5.      -   5        $��Account��5.      #��[  6/   $��0q�6w   5/      50      51      �� 54   
   $��1��6   ._�55      (� .��56       � -   5          �Name$ MainMenuFrame��56      $��1��6/     � NavigationUIVisibility$ Hidden=�6?   57      58      59      5:      