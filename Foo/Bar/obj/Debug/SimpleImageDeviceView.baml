   M S B A M L   `   `   `  ����>  :Bar, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:BarBar  5      /clr-namespace:Bar.ConvertersBar.Converters  5          Bar.SimpleImageDeviceView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      #localclr-namespace:Bar     5      3
convertersclr-namespace:Bar.Converters     5      .��5      �   � ColumnDefinitions  5   
   �� 5      $	��150 �6   6-   �� 5      $��1* �6   6,   �� 5      $	��100 �6   6-   .+�5   
   ]� ��. .+�5      �� $��Browse��6   $��Bottom=�6&   ��6>   �� *BrowseCommand+6b   �� 5      $��Bottom=�6   ��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value
 �   �6H   �� 5       � ��$ 2q�6<   6H   5      .��5      �� ��6   �� *#!Device.Params.ImagePathCollection+��5      �� 5      .R�5      �� ��6(   �� 6;   5      5       5!      5"      �� 5#   
   $��1��6   ��6    �� *OutputImage+1   +Bar.Converters.BitmapToImageSourceConverter   Instance �� 	Converter# Z 6�   ]� 5$   
   $��2��6   ��. .+�5%      �� -   5         ��Name$
 Grab��5%      $
��Grab��6#   $��50��6R   $	��Top=�6^   ��62   �� *GrabCommand+6u   �� 5&      $
��Wrap=�6   
�������$	��Top=�6_   ��6,   �� *Device.Message+6v   5'      5(      5)      