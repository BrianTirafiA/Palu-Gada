   M S B A M L   `   `   `  ���� C  ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view      PaluGada.view.Login   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     -localclr-namespace:PaluGada.view       N� Title$  Login�� N� 
Background �#BEEBAD � 	Resources  �� 
TargetType   RoundedTextBoxStyle �� Property �� Value �� 
TargetType �� CornerRadius ��Name  RoundedPassBoxStyle	 �� Padding
 J� Effect3  -System.Windows.Media.Effects.DropShadowEffect   Color   
BlurRadius   ShadowDepth   Opacity  RoundedButtonStyle��%-  &	        &	 ~     &	 O    �� " ��.���  � �� �� " ��.R��� 
�������
�������$��1q�$ 30��._��� $ PART_ContentHost��$��0q��� " G�.���  � �� �� " G�.R��� ���#D9D9D9
�������$��1q�$ 25��$	 10,0,0,0q�
   $ Black��$ 10Q�$ 2Q�$	 0.5Q�._��� $ PART_ContentHost��$
��Left=�$��Center=��� " ��.���  � �� �� " ��.R��� #��z��#��z��$��1q�$ 10��#	 z��._��� $��Center=�$��Center=���  � ��
 �������  � ��
 �������  � ��$
 10,5q�.���  � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��._��  � RowDefinitions �� $��* ��� $��2* �.+�(� $��0��.���� -    ��Name$ 	lbl_Login��$��Login��$��20(�$
��Bold"�$��
Montserrat)����#FFFFFF(� $��1��.���� ���#FFF1DB$ 30��$��40q�._��  �� $��* ��� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� -   $ lbl_Username��$��0��$��Username��$��30(�$
��Bold"�$��
Montserrat)����#000000$��	25,15,0,0q��� -    ��Name$ box_Username��#��[  $��1��$��Center=�$��Center=�$	��600��$��
Montserrat)�$��50(�
�������$��
15,0,15,15q��� -   $ lbl_Pass��$��2��$��Password��$��30(�$
��Bold"�$��
Montserrat)����#000000$��	25,15,0,0q�G� -    G�Name$ box_Password��#��[ $��3��$��Center=�$��Center=�$	��600��$��
Montserrat)�$��50(�
�������$��
15,0,15,15q��� -    ��Name$ 	btn_Login��$��Login��$��
Montserrat)�$��30(�$
��Bold"����#FFFFFF���#88C273$��4��#��[ $	��200��$��60��$��10q��� -   $ 
lbl_Create��$��5��$��Create an Account��$��20(�$
��Bold"�$��
Montserrat)����#000000$��Center=�
   $ Black��$ 40Q�$ 2Q�$	 0.5Q��� $��1��._�(� .���� $	��100q�._��  �� $
��auto ��� $
��auto �.+��� $��0��$
��Left=�$	��Top=�$��/assets/logo_pg.png���� -   $ 
lbl_Slogan��$��1��$��Apa Lu Mau, Gua Ada��$	��100(�$
��Bold"�$��
Montserrat)����#000000$��Center=�
   $ Black��$ 40Q�$ 2Q�$	 0.5Q�