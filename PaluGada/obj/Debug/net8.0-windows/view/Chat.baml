   M S B A M L   `   `   `  ����C  ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view  5          PaluGada.view.Chat   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PaluGada.view     5        N� 
Background
  ����� N� Title$ mainmenu��5	      $
��1080��6   $
��1414��6&   .��5
      �  � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��3* �6   .+�5   
   �� $��0��6    �� Orientation$ Vertical=�6%   .+�5      �� ._�5      �� $��ChatRoom��6   $��50(�6+   $
��Bold"�69   $��
Montserrat)�6K   $
��Left=�6c    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6'      
BlurRadius$ 40Q�65      ShadowDepth$ 2Q�6E      Opacity$	 0.5Q�6U   5      �� 5      -   5        	 ��Name$	 ChatroomList��5      ��5      �� 5      .R�5      �� $��1q�6!   
�������
 �� CornerRadius$
 10��6H    �� Padding$ 10q�6Z   $��5q�6g   $	��300��6r   ._�5      �� $ 
Horizontal=�6)   .+�5   "   �� $��16(�6I   $��
Montserrat)�6W   $��Center=�6o   ��6,   �� *PartnerName+6o   �� 5!   "   $��14(�6I   $��
Montserrat)�6W   $��Center=�6o   $��10,0,0,0q�6�   
���������6,   �� *LastMessage+6�   5"      5#      5$      5&      5'      �� 5(   
   $��1��6   $��1q�6!   
�������._�5)      (� .��5*       � -   5          �Name$ 	ChatFrame��5*      $��1��6+     � NavigationUIVisibility$ Hidden=�6;   5+      5,      5-      5.      