   M S B A M L   `   `   `  ����D  @cvicenie5, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:cvicenie5	cvicenie5  5   	       cvicenie5.PersonWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:cvicenie5     5   	     � Title$  PersonWindow��5   	   $	��450��6   $	��800��6+   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $
��Auto �6   �� 5      $��* �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   $��34��6*   �� 5      $
��Auto �6   $��34��6*   �� 5      $
��Auto �6   $��34��6*   �� 5      $��* �6   .+�5   
   �� $��0��6   $��0��6!   $��First Name:��61   $��5q�6D   $��Center=�6O   �� 5   
   -   5        $��FirstNameTextBox��5      $��0��6*   $��1��67   $��5q�6G   �� 5   
   $��1��6   $��0��6!   $��
Last Name:��61   $��5q�6C   $��Center=�6N   �� 5   
   -   5        $��LastNameTextBox��5      $��1��6)   $��1��66   $��5q�6F   �� 5   
   $��2��6   $��0��6!   $��
Birthdate:��61   $��5q�6C   $��Center=�6N   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��BirthdateDatePicker��5      $��2��60   $��1��6=   $��5q�6M   �� 5   
   $��3��6   $��0��6"   $��2��62    �� Orientation$ 
Horizontal=�6F   $��Right=�5      $��Bottom=�6   .+�5      �� -   5        $��OK��5      $��25��6"   $��80��6.   $��5,5,0,5q�6<   6M   �� 5      -   5        $��Cancel��5      $��25��6&   $��80��62   $��5q�6@    �� IsCancel$
 True��6K   6[   5      5      5       