   M S B A M L   `   `   `  ����c  _GMap.NET.WindowsPresentation, Version=2.1.7.0, Culture=neutral, PublicKeyToken=b85b9027b614afefqPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentationGMap.NET.WindowsPresentation  5   	   C ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view 5   	   "   PaluGada.view.EditItemWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   `wpfPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentation     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   -localclr-namespace:PaluGada.view     5   	   ���#FFF1DB  � Title$  	Edit Item��5
   	   $
��1080��6   $
��1414��6)   .��5      � .+�5   
   �� $
��Auto=�6   .��5      �� $��Center=�6   $
��1414��66   .+�5      �� ._�5      �� $��	Edit Item��6   $��50(�60   $
��Bold"�6>   $��
Montserrat)�6P   $��0,10,0,0q�6h   $��Center=�6z    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6+      
BlurRadius$ 40Q�69      ShadowDepth$ 2Q�6I      Opacity$	 0.5Q�6Y   5      �� 5      $��	Item Name��6   $��30(�6,   $
��Left=�6:   $��
Montserrat)�6U   $��30,0,0,0q�6m   �� 5      -   5         ��Name$ box_ItemName��5   ]   $
��1318��6   $��
Montserrat)�6'   $��87��6?   $��30,0,0,0q�6K   $
��Left=�6s   $��20(�6�   .��6�   ��5      �� 5       �� 
TargetType" ��6    .�5      ��  �� Property � ��	 �� Value	 5   "   �� 5   &   
 �� 
TargetType"
 ��66   .R�5   *   �� 
�������
�������$��1q�6W    �� CornerRadius$ 25��6k    �� Padding$ 10,0,0,0q�6}    5   .     5   2   $ Black��6C   $ 10Q�6Q   $ 2Q�6a   $	 0.5Q�6q   ._�5    .   ��  ��Name$ PART_ContentHost��6;   $
��Left=�6U   $��Center=�6p   5!   +   5"   '   5$      5%      .��5&   %   5'      �� 5*      $��Description��6   $��30(�6.   $
��Left=�6<   $��
Montserrat)�6W   $��	30,20,0,0q�6o   �� 5+      -   5        $ box_Description��5+   ^   $
��1318��6   $��
Montserrat)�6'   $	��203��6?   $��30,0,0,0q�6L   $
��Left=�6w    �� AcceptsReturn$
 True��5,      " �� VerticalScrollBarVisibility$
 Auto=�6/   $��20(�6R    �� TextWrapping$
 Wrap=�6`   $	��Top=�6t   .��6�   ��5-      �� 5.      " ��6    .�5/      ��  � ��	 50   "   �� 51   &   "
 ��66   .R�52   *   �� 
�������
�������$��1q�6W   $ 25��6k   $ 	10,0,10,0q�6}    53   .     54   2   $ Black��6C   $ 10Q�6Q   $ 2Q�6a   $	 0.5Q�6q   ._�56   .   �� $ PART_ContentHost��6;   $
��Left=�6U   $��Center=�6p   $
��Auto=�6�   57   +   58   '   5:      5;      .��5<   %   5=      �� 5@      $��Photo��6   $��30(�6(   $
��Left=�66   $��
Montserrat)�6Q   $��	30,20,0,0q�6i   �� 5A      -   5         ��Name$ UploadButton��5A      $	��392��6/   $	��149��6;   $��30,0,0,0q�6H   $
��Left=�6Z   ��5B      �� 5C      "
 ��6*   .R�5D      �� 
����������#D9D9D9$��3q�6N   $ 25��6b   $ 10,0,0,0q�6t   ._�5E   "   �� $��Center=�63   $��Center=�6P    5F   "     5G   &   $ Black��67   $ 10Q�6E   $ 2Q�6U   $	 0.5Q�6e   5I      5J      .��5L      �� -   5         ��Name$ ButtonContent��5L   %   $��Upload Image��6<   $��Center=�6S   $��Center=�6p   5M      �� 5O      -   5         ��Name$ 	ItemImage��5O      $	��392��6+   $	��392��67   $��Uniform=�6D   $��	30,10,0,0q�6V   $
��Left=�6i   �� 5R      $��Location��6   $��30(�6+   $
��Left=�69   $	��164��6T   $��	30,20,0,0q�6`   �� 5S      -   5        $ box_Location��5S      $	��722��60   $��50��6<   $��30,0,0,0q�6H   $
��Left=�6Z   $��20(�6u   .��5T   9   ��5U      �� 5V      " ��6    .�5W      ��  � ��	 5X   "   �� 5Y   &   "
 ��66   .R�5Z   *   �� 
�������
�������$��1q�6W   $ 25��6k   $ 10,0,0,0q�6}    5[   .     5\   2   $ Black��6C   $ 10Q�6Q   $ 2Q�6a   $	 0.5Q�6q   ._�5^   .   �� $ PART_ContentHost��6;   $
��Left=�6U   $��Center=�6p   $
��Auto=�6�   5_   +   5`   '   5b      5c      .��5d   %   5e      .   (GMap.NET.WindowsPresentation.GMapControl  5f      -   5          Name$ 
mapControl��5f   "   $
��1318��66   $	��400��6C   $��	30,30,0,0q�6P   $
��Left=�5g   "   5i   "   �� 5l      -   5        $
��SAVE��5l      $��20(�6(   $
��Bold"�66   $��
Montserrat)�6H   
����������#88C273$	��200��5m   A   $��50��6M   $��0,10,0,0q�5n      $��Center=�6+   $	��Top=�6H   ��5o      �� 5p      "
 ��6*   .R�5q      �� #��z��6%   ���#D9D9D9$��3q�6e   $ 25��6y   ._�5r   "   �� $��Center=�63   $��Center=�6P   5s      5t      5v      5w      5x      5y      5z      