   M S B A M L   `   `   `  ���� C  ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view      PaluGada.view.Chat   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:PaluGada.view       N� 
Background
  ����� N� Title$ mainmenu��$
��1080��$
��1414��.���  � ColumnDefinitions �� $��* ��� $��3* �.+��� $��0�� �� Orientation$ Vertical=�.+��� ._��� $��ChatRoom��$��50(�$
��Bold"�$��
Montserrat)�$
��Left=� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     Color$ Black��   
BlurRadius$ 40Q�   ShadowDepth$ 2Q�   Opacity$	 0.5Q��� -   	 ��Name$	 ChatroomList������ .R��� $��1q�
�������
 �� CornerRadius$
 10�� �� Padding$ 10q�$��5q�$	��300��._��� $ 
Horizontal=�.+��� $��16(�$��
Montserrat)�$��Center=����� *PartnerName+�� $��14(�$��
Montserrat)�$��Center=�$��10,0,0,0q�
����������� *LastMessage+�� $��1��$��1q�
�������._�(� .�� � -     �Name$ 	ChatFrame��$��1��  � NavigationUIVisibility$ Hidden=�