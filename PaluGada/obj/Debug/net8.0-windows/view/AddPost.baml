   M S B A M L   `   `   `  ����c  _GMap.NET.WindowsPresentation, Version=2.1.7.0, Culture=neutral, PublicKeyToken=b85b9027b614afefqPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentationGMap.NET.WindowsPresentation  5      C ?PaluGada, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PaluGada.viewPaluGada.view 5         PaluGada.view.AddPost   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      `wpfPclr-namespace:GMap.NET.WindowsPresentation;assembly=GMap.NET.WindowsPresentation     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:PaluGada.view     5        N� 
Background  �#FFF1DB N� Title$ AddPost��5
      $
��1080��6   $
��1414��6%   .��5      �  � ColumnDefinitions 5   
   �� 5      $��1* �6   .+�5   
   �� $
��Auto=�6   .��5      �� $��1��6   $��Center=�6)   $
��1414��6F   .+�5      �� ._�5      �� $��Add Post��6   $��50(�6/   $
��Bold"�6=   $��
Montserrat)�6O   $��10q�6g   $��Center=�6s    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ Black��6+      
BlurRadius$ 40Q�69      ShadowDepth$ 2Q�6I      Opacity$	 0.5Q�6Y   5      �� 5      $��	Item Name��6   $��
Montserrat)�6,   $��30(�6D   $
��Left=�6R   $��30,0,0,0q�6m   �� 5      -   5         ��Name$ box_ItemName��5   ]   $
��1318��6   $��
Montserrat)�6'   $��87��6?   $��30,0,0,0q�6K   $
��Left=�6s   $��20(�6�   .��6�   ��5      �� 5      	 �� 
TargetType"	 ��6    .�5       �� 
 �� Property
 � �� �� Value 5!   "   �� 5"   &    �� 
TargetType" ��66   .R�5#   *   �� 
�������
�������$��1q�6W    �� CornerRadius$ 25��6k    �� Padding$ 10,0,0,0q�6}    5$   .     5%   2   $ Black��6C   $ 10Q�6Q   $ 2Q�6a   $	 0.5Q�6q   ._�5'   .   ��  ��Name$ PART_ContentHost��6;   $
��Left=�6U   $��Center=�6p   5(   +   5)   '   5+      5,      .��5-   %   5.      �� 51      $��Description��6   $��
Montserrat)�6.   $��30(�6F   $
��Left=�6T   $��	30,20,0,0q�6o   �� 52      -   5        $ box_Description��52   ^   $
��1318��6   $	��203��6'   $��
Montserrat)�64   $��30,0,0,0q�6L   $
��Left=�6w    �� AcceptsReturn$
 True��53      " �� VerticalScrollBarVisibility$
 Auto=�6*   $��20(�6M    �� TextWrapping$
 Wrap=�6[   $	��Top=�6o   .��6�   ��54      �� 55      "	 ��6    .�56      �� 
 � �� 57   "   �� 58   &   " ��66   .R�59   *   �� 
�������
�������$��1q�6W   $ 25��6k   $ 	10,0,10,0q�6}    5:   .     5;   2   $ Black��6C   $ 10Q�6Q   $ 2Q�6a   $	 0.5Q�6q   ._�5=   .   �� $ PART_ContentHost��6;   $
��Left=�6U   $��Center=�6p   $
��Auto=�6�   5>   +   5?   '   5A      5B      .��5C   %   5D      �� 5G      $��Photo��6   $��
Montserrat)�6(   $��30(�6@   $
��Left=�6N   $��	30,20,0,0q�6i   �� 5H      -   5         ��Name$ UploadButton��5H      $	��392��6/   $	��149��6;   $��30,0,0,0q�6H   $
��Left=�6Z   ��5I      �� 5J      " ��6*   .R�5K      �� 
����������#D9D9D9$��3q�6N   $ 25��6b   $ 10,0,0,0q�6t   ._�5L   "   �� $��Center=�63   $��Center=�6P    5M   "     5N   &   $ Black��67   $ 10Q�6E   $ 2Q�6U   $	 0.5Q�6e   5P      5Q      .��5S      �� -   5         ��Name$ ButtonContent��5S   %   $��Upload Image��6<   $��Center=�6S   $��Center=�6p   5T      �� 5V      -   5         ��Name$ PreviewImage��5V      $	��392��6.   $	��392��6:   $��UniformToFill=�6G   $��	30,10,0,0q�6_   $
��Left=�6r   �� 5Z      $��Location��6   $��30(�6+   $��
Montserrat)�69   $
��Left=�6Q   $��	30,20,0,0q�6l   �� 5[      -   5        $ box_Location��5[      $	��722��60   $��50��6<   $��
Montserrat)�6H   $��30,0,0,0q�6`   $
��Left=�6r   $��20(�6�   .��5\   9   ��5]      �� 5^      "	 ��6    .�5_      �� 
 � �� 5`   "   �� 5a   &   " ��66   .R�5b   *   �� 
�������
�������$��1q�6W   $ 25��6k   $ 10,0,0,0q�6}    5c   .     5d   2   $ Black��6C   $ 10Q�6Q   $ 2Q�6a   $	 0.5Q�6q   ._�5f   .   �� $ PART_ContentHost��6;   $
��Left=�6U   $��Center=�6p   $
��Auto=�6�   5g   +   5h   '   5j      5k      .��5l   %   5m      .   (GMap.NET.WindowsPresentation.GMapControl  5n      -   5          Name$ 
mapControl��5n   "   $
��1318��66   $	��400��6C   $��	30,30,0,0q�6P   $
��Left=�6c   5o   S   �� 5r      -   5        $
��POST��5r      $��20(�6(   $
��Bold"�66   $��
Montserrat)�6H   
����������#88C273$	��200��5s   =   $��50��6I   $��0,10,0,0q�5t      $��Center=�6'   $	��Top=�6D   ��5u      �� 5v      " ��6*   .R�5w      �� #��z��6%   ���#D9D9D9$��3q�6e   $ 25��6y   ._�5x   "   �� $��Center=�63   $��Center=�6P   5y      5z      5|      5}      5~      5      5�      