   M S B A M L   `   `   `  ����J  FTypingSimulator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:TypingSimulator.ViewsTypingSimulator.Views  5      %    TypingSimulator.Views.LoginView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:TypingSimulator.Views     5      .��5	      � $��Center=�6   $��Center=�6&     � ColumnDefinitions  5
   
   �� 5      $
��131* �6   �� 5      $
��369* �6    � RowDefinitions 5   
   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   �� 5      $��60 �6   .+�5   
   �� -   5         ��Name$ 	MainLabel��5       J� Opacity$ 1Q�6#   $	��500��60   $��0��6<   $��Typing Simulator��6I   $��Regular"�6d   $��50(�6z   $��Center=�6�   $��	0,-50,0,0q�6�   $��2��6�   �� 5   
   -   5        $ 
LoginLabel��5      $ 1Q�6$   $	��250��61   $��1��6=   $��Log in��6J   $��SemiBold"�6[   $��38(�6r   $��2��6�   $��125,0,125,0q�6�   �� 5   
   -   5         ��Name$ UserNameBox��5      $
{�True��6'   $��20(�68    �� 
IsReadOnly$ False��6F   $ 1Q�6Y   $	��250��6e   $��40��6q   $��2��6}   $��2��6�   $��125,10,125,10q�6�   6�   �� 5   
   -   5        $ UserNameWaterMark��5       J� IsHitTestVisible$ False��6+   $	 0.5Q�6D   $	��250��6S   $��40��6_   $��2��6k   $��Username��6x   $��Medium"�6�   $��12(�6�   $��125,14,125,6q�6�   $��2��6�   
������ 6�   G� 5   
   -   5         G�Name$ PasswordBox��5      $
{�True��6+   $��20(�6<   $ 1Q�6J   $	��250��6V   $��40��6b   $��3��6n   $��2��6{   $��125,10,125,10q�6�   6�   �� 5   
   -   5        $ PasswordWaterMark��5      $ False��6+   $	 0.5Q�6D   $	��250��6R   $��40��6^   $��3��6j   $��Password��6w   $��Medium"�6�   $��12(�6�   $��125,14,125,6q�6�   $��2��6�   
������ 6�   �� 5   
   -   5         ��Name$ LoginButton��5      $��4��6&   $	��250��63   $��40��6?   $��125,10,125,10q�6K   $��Login��6b   $��18(�6r   $��Medium"�6�   
�������
����� �$��2��6�   �� 5   
   -   5        $ RegisterButton��5      $��5��6)   $	��250��66   $��40��6B   $��125,10,125,10q�6N   $��Register��6e   $��13(�6x   $��Medium"�6�   
������ $��1q�6�   
����� �$��2��6�   5!      5"      