   M S B A M L   `   `   `  ����F  BNetflixPart, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:NetflixPartNetflixPart  5   	   !    NetflixPart.MovieDataWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:NetflixPart     5   	     � Title$  Movie's Data��5   	   $	��550��6   $	��900��6+    � 	Resources 5	      (   "NetflixPart.LengthFormateConverter   
LengthConv   NetflixPart.UriConverter  UriConv��%:   &	        &	        5
   
   6'     5   
   6   5      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��1.5* �6   �� 5      $��2* �6   .+�5   
   �� $��1��6   $��Uniform=�6e   $��4q�6w   ��6    �� *Actual.Title+ �� 	Converter# [ 6w   �� 5   
   -   5         ��Name$ stack��5      $��0��6$   .+�5      �� $��Title:��6   $��10q�6%   $
��Bold"�62   $��Times New Roman)�6D   $��16(�6a   
�������6o   �� 5      $��10q�65   $��Times New Roman)�6B   $��16(�6_   ��6   �� *Actual.Title+6_   �� 5      $��Directed by:��6   $��10q�6+   $
��Bold"�68   $��Times New Roman)�6J   $��16(�6g   
�������6u   �� 5      $��10q�68   $��Times New Roman)�6E   $��16(�6b   ��6   �� *Actual.Director+6b   �� 5      $��Length:��6   $��10q�6&   $
��Bold"�63   $��Times New Roman)�6E   $��16(�6b   
�������6p   �� 5      $��10q�6]   $��Times New Roman)�6j   $��16(�6�   ��6   �� *Actual.Length+# [  6�   �� 5      $��Number of plays:��6   $��10q�6/   $
��Bold"�6<   $��Times New Roman)�6N   $��16(�6k   
�������6y   �� 5      $��10q�6<   $��Times New Roman)�6I   $��16(�6f   ��6   �� *Actual.NumberOfPlay+6f   �� 5      $
��Rate��6   $��10q�6#   $
��Bold"�60   $��Times New Roman)�6B   $��16(�6_   
�������6m   �� 5      $��10q�64   $��Times New Roman)�6A   $��16(�6^   ��6   �� *Actual.Rate+6^   5      5      5       