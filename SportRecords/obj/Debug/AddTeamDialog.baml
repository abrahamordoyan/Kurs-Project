   M S B A M L   `   `   `  ����G  CSportRecords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SportRecordsSportRecords  5   	        SportRecords.AddTeamDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SportRecords     5   	     � Title$@  :Добавить/Редактировать команду��5      $	��400��6/   $	��500��6<   ���#F5F5DC.��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� $��80��6   $��Center=�6$   $��Stretch=�6?   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5      �  � Color$ #BBDEFB��6'    � Offset$	 0.0Q�67   � 5      $ #4CAF50��6'   $	 1.0Q�67   5      5      �� 5      $��Resources/Logo.png��6   $��65��60   $��65��6;   $��
15,10,0,10q�6G   $
��Left=�6[   $��Center=�6v   �� 5      -   5         ��Name$ 
TitleLabel��5      $��Операция��6(   
���   �$��30(�6N   $��Century Gothic)�6\   $��Center=�6x   $��Center=�6�   5      �� 5!   
   $��1��6   $&�� Название команды:��6   $��Center=�69   �� 5"   
   -   5         ��Name$ NameTextBox��5"      $��1��6   $��	120,5,0,5q�64   $	��300��6G   $��30��6S   �� 5$   
   $��2��6   $��Вид спорта:��6   $��Center=�63   �� 5%   
   -   5        $ SportNameTextBox��5%      $��2��6   $��	120,5,0,5q�69   $	��300��6L   $��30��6X   �� 5(   
   -   5        $��3��5(      $��Сохранить��6   $��18(�62   $��Century Gothic)�6@   $	��120��6\   $��40��6h   $��Right=�6t   $��0,20,0,0q�6�   6�   5)      5*      