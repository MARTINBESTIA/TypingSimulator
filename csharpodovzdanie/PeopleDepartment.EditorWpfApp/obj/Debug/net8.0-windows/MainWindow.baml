   M S B A M L   `   `   `  ����Y  UPeopleDepartment.CommonLibrary, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullwTclr-namespace:PeopleDepartment.CommonLibrary;assembly=PeopleDepartment.CommonLibraryPeopleDepartment.CommonLibrary  5   	   ! PeopleDepartment.EditorWpfApp.   (PeopleDepartment.EditorWpfApp.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   flocalTclr-namespace:PeopleDepartment.CommonLibrary;assembly=PeopleDepartment.CommonLibrary     5   	     � Title$  People Department Editor��5   	   $	��300��6*   $	��700��67   .��5
      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   ]� $��0��6   .+�5      o� $	��Top=�6   .@�5      m� $
��File��6   .@�5      m� -   5        $	��New��5      6,   m� 5      -   5        $��Open...��5      60   m� 5      -   5        $��
Save As...��5      63   �� 5      m� 5      -   5        $��_Exit��5      6.   5      m� 5      $
��Edit��6   .@�5      m� -   5        $��Add...��5      6/   m� 5      -   5         m�Name$ dockEdit��5      $��Edit...��61    J� Opacity$	 0.5Q�6U   m� 5      -   5        $ 
dockRemove��5      $��Remove��63   $	 0.5Q�6X   5      m� 5       $
��View��6   .@�5!      m� -   5        $��View by Department...��5!      6>   5"      m� 5#      $
��Help��6   .@�5$      m� -	   5        $��About...��5$      61   5%      5&      5'      ]� 5)   
   $��1��6   .+�5*      �� -
   5        $��New...��5*      $��50��6&   $��4q�61   6<   �� 5+      -   5        $��Open...��5+      $��60��6'   $��25��62   $��4q�6>   6I   �� 5,      -   5        $��
Save As...��5,      $��70��6*   $��25��65   $��4q�6A   6L   �� 5-      -   5        $��View by department��5-      $	��120��62   $��25��6>   $��4q�6J   $��Right=�6h   5.      � 5/   
   $��2��6   $��0,0,0,5q�6    � ColumnDefinitions 50      �� 51      $��* �6#   �� 52      $
��Auto �6#    54      �� 55      $��* �6    .+�58      �� -   5         ��Name$ itemsControl��58      $��0��6-   $��4,0,60,0q�6=   ��6y   �� *
PersonList+ �� View 59      �� 5:      .P�5;      �� $��Display Name��6)    �� Width$	 150��6?    �� DisplayMemberBinding 6K   �� 	 �� Path$	 DisplayName��� 5<      $��Title Before��6)   $ 80��6?    6J   �� $	 TitleBefore��� 5=      $��
First Name��6)   $ 80��6=    6H   �� $	 	FirstName��� 5>      $��	Last Name��6)   $ 80��6<    6G   �� $	 LastName��� 5?      $��Title After��6)   $ 80��6>    6I   �� $	 
TitleAfter��� 5@      $��Email��6)   $	 150��68    6D   �� $	 Email��� 5A      $��Position��6)   $ 90��6;    6F   �� $	 Position��� 5B      $��
Department��6)   $	 150��6=    6I   �� $	 
Department�5C      5E      �� 5F      
 �� Orientation$
 Vertical=�6   $��Right=�60   .+�5G      �� -   5        $��Add...��5G      $��50��6*   $��25��65   $��4q�6A   6L   �� 5H      -   5         ��Name$ 
editButton��5H      $��Edit...��6-   $��50��6?   $��25��6J   $��4q�6V   $	 0.5Q�6a   6o   �� 5I      -   5        $ removeButton��5I      $��Remove��6/   $��50��6@   $��25��6K   $��4q�6W   $	 0.5Q�6b   6p   �� 5J      $��Count: ��6   $��4q�6+   �� 5K      -   5         ��Name$ 	CountText��5K      $��14(�6/   $
��Bold"�6=   $��0��6P   $��51��6Y   5L      5M      5O      5P      