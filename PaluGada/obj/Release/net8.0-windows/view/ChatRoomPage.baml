   M S B A M L   `   `   `  ����   PaluGada     PaluGada.view.ChatRoomPage   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008       N� Title$  ChatRoomPage��$
��1080��$
��1060��.��� .+��� $
��1080��$
��1060��.+�� $
��1080��$
��1060�� � RowDefinitions �� $	��15* ��� $��* �.+��� $
��Auto=�$��0��.���� -    ��Name$ MessageList������ .R���  �� CornerRadius$ 10�� �� Padding$ 10q�$��5q�$
��Left=����� *IsUserMessage+   BubbleColorConverter �� 	Converter# [  ._��  � ColumnDefinitions �� $��* ��� $��* �.+��� $��0��$��
Montserrat)�$��30(�$
��Wrap=����� *	Content+�� $��1��$��
Montserrat)�$��Italic$�
�������$��5,0,0,0q����� *TimestampWithOffset+ �� StringFormat$ 	{0:HH:mm}���� $��1�� �� Orientation$ 
Horizontal=�$��10q�.+��� -   	 ��Name$	 MessageText��$��
Montserrat)�$	��900��$��30(�$��45���� -   $
��Send��$��
Montserrat)�$��45��$	��120��$��10,0,0,0q�