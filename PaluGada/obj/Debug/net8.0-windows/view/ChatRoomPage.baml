   M S B A M L   `   `   `  ����  PaluGada     PaluGada.view.ChatRoomPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        N� Title$  ChatRoomPage��5      $
��1080��6   $
��1060��6*   .��5      � .+�5	   
   �� $
��1080��6   $
��1060��6#   .+�5
      � $
��1080��6   $
��1060��6!    � RowDefinitions 5      �� 5      $	��15* �6$   �� 5      $��* �6$   .+�5      �� $
��Auto=�6   $��0��6B   .��5      �� -   5         ��Name$ MessageList��5   #   ��5      �� 5      .R�5   "   ��  �� CornerRadius$ 10��6)    �� Padding$ 10q�6;   $��5q�6H   $
��Left=�5   {   ��6%   �� *IsUserMessage+   BubbleColorConverter �� 	Converter# [  ._�5   &   �  � ColumnDefinitions 5   *   �� 5   .   $��* �6?   �� 5   .   $��* �6?   .+�5   *   �� $��0��64   $��
Montserrat)�6]   $��30(�6u   $
��Wrap=�6�   ��6D   �� *	Content+6�   �� 5   *   $��1��64   $��
Montserrat)�6�   $��Italic$�6�   
�������$��5,0,0,0q�6�   ��6D   �� *TimestampWithOffset+ �� StringFormat$ 	{0:HH:mm}��6�   5   '   5   #   5      5       5!      �� 5$      $��1��6    �� Orientation$ 
Horizontal=�6*   $��10q�6C   .+�5%      �� -   5        	 ��Name$	 MessageText��5%      $��
Montserrat)�63   $	��900��6K   $��30(�6W   $��45��6e   �� 5&      -   5        $
��Send��5&      $��
Montserrat)�6,   $��45��6D   $	��120��6P   $��10,0,0,0q�6u   5'      5(      5)      5*      5+      