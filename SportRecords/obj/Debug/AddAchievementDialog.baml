   M S B A M L   `   `   `  ����G  CSportRecords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SportRecordsSportRecords  5   	   '    !SportRecords.AddAchievementDialog   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SportRecords     5   	     � Title$F  @Добавить/Редактировать достижение��5   	   $	��500��63   $	��500��6@   ���#F5F5DC.��5
      � $��10q�6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� $��80��6   $��Center=�6$   $��Stretch=�6?   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5      �  � Color$ #BBDEFB��6'    � Offset$	 0.0Q�67   � 5      $ #4CAF50��6'   $	 1.0Q�67   5      5!      �� 5"      $��Resources/Logo.png��6   $��65��60   $��65��6;   $��
15,10,0,10q�6G   $
��Left=�6[   $��Center=�6v   �� 5#      -   5         ��Name$ 
TitleLabel��5#      $��Операция��6(   
���   �$��30(�6N   $��Century Gothic)�6\   $��Center=�6x   $��Center=�6�   5$      �� 5'   
   $��1��6   $$��Дата достижения:��6   $��Center=�68   (  "System.Windows.Controls.DatePicker  5(   
   -   5          Name$ AchievementDatePicker��5(   "   $��1��6   $��	150,5,0,5q�6A   $	��300��6T   �� 5*   
   $��2��6   $��Событие:��6   $��Center=�60   �� 5+   
   -   5         ��Name$ EventTextBox��5+      $��2��6   $��	150,5,0,5q�65   $	��300��6H   $��30��6T   �� 5-   
   $��3��6   $��Спортсмен:��6   $��Center=�62   �� 5.   
   -   5        	 ��Name$	 AthleteComboBox��5.       $��3��6   $��	150,5,0,5q�69   $	��300��6L   �� 50   
   $��4��6   $��Турнир:��6   $��Center=�6/   �� 51   
   -   5        $	 TournamentComboBox��51       $��4��6   $��	150,5,0,5q�6<   $	��300��6O   �� 53   
   $��5��6   $,��&Название достижения:��6   $��Center=�6<   �� 54   
   -   5        $	 AchievementNameComboBox��54       $��5��6   $��	150,5,0,5q�6A   $	��300��6T   �� 56   
   $��6��6   $"��Тип достижения:��6   $��Center=�67   �� 57   
   -   5        $	 AchievementTypeComboBox��57       $��6��6   $��	150,5,0,5q�6A   $	��300��6T   �� 59   
   $��7��6   $��Вид спорта:��6   $��Center=�63   �� 5:   
   -   5        $	 SportComboBox��5:       $��7��6   $��	150,5,0,5q�67   $	��300��6J   �� 5=   
   -	   5        $��9��5=      $��Сохранить��6   $��18(�62   $��Century Gothic)�6@   $	��120��6\   $��40��6h   $��Right=�6t   $��0,20,0,0q�6�   6�   5>      5?      