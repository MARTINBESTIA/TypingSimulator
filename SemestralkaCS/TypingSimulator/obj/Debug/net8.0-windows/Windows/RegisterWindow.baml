   M S B A M L   `   `   `  ����J  FTypingSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:TypingSimulator.WindowsTypingSimulator.Windows  5   	   ,    &TypingSimulator.Windows.RegisterWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:TypingSimulator.Windows     5   	     � Title$  RegisterWindow��5   	   $	��230��6    $	��420��6-    � 
ResizeMode$ NoResize=�69    � WindowStartupLocation$ CenterScreen=�6O   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $	��100 �6   �� 5      $	��300 �6    � RowDefinitions 5   
   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��50 �6   .+�5   
   �� $��
Username: ��6   $��0��6%   $��0��65   $��10(�6B   $��Center=�6P   �� 5   
   $��
Password: ��6   $��0��6%   $��1��65   $��10(�6B   $��Center=�6P   �� 5   
   $��Confirm Password: ��6   $��0��6-   $��2��6=   $��10(�6J   $��Center=�6X   �� 5   
   -   5         ��Name$ UsernameBox��5      $��0��6'   $��1��64   $	��280��6D   $��30��6P   G� 5   
   -   5         G�Name$ RWPasswordBox��5      $��1��6-   $��1��6:   $	��280��6J   $��30��6V   G� 5   
   -   5        $ RWConfirmpasswordBox��5      $��2��64   $��1��6A   $	��280��6Q   $��30��6]   �� 5   
   -   5         ��Name$ 
RWOKbutton��5      $��1��6%   $��3��65   $��80��6B   $��20��6M   $��210,5,10,25q�6Y   $��Register��6n   6�   5      5      