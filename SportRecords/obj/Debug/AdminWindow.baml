   M S B A M L   `   `   `  ����G  CSportRecords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SportRecordsSportRecords  5   	       SportRecords.AdminWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SportRecords     5   	     � Title$   Администратор��5      $	��600��6&   $	��800��63   ���#F5F5DC � Icon$ 
/admin.png��6T   .��5
      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��71* �6   �� 5      $	��77* �6   �� 5      $��60 �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��2��6   
�������.+�5      �� $��80��6   $��Center=�6$   $��1��6?   $��3��6O   ��5      �� 5       �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5      �  � Color$ #BBDEFB��6'    � Offset$	 0.0Q�67   � 5       $ #4CAF50��6'   $	 1.0Q�67   5!      5#      �� 5$      $��Resources/Logo.png��6   $��60��60   $��60��6;   $��
20,10,0,10q�6G   $��1��6[   $��0��6k   $
��Left=�6x   �� 5%      $ ��Администратор��6   
���   �$��30(�6?   $��Century Gothic)�6M   $��2��6i   $��Center=�6y   $��Center=�6�   �� 5&      -   5         ��Name$ FILabel��5&      $��Имя фамилия��6%   
���   �$��20(�6N   $��Century Gothic)�6\   $��Right=�6x   $��0,0,20,0q�6�   $��Center=�6�   5'      � 5*   
   $��1��6   $��2��6   $��2��60    5+      �� 5,      $��* �6    �� 5-      $��* �6    �� 5.      $��* �6    �� 5/      $��* �6     52      �� 53      $��* �6#   �� 54      $��* �6#   .+�57      �� -   5        	 ��Name$	 
UserButton��57      $��0��6)   $��0��66   $��Пользователь��6F   $��24(�6]   $��Century Gothic)�6k   $��Center=�58      $��Center=�67   $
��50px��6[   $��270px��6i   6w   �� 5:      -   5        $��0��5:      $��1��6"   $��Команда��62   $��24(�6D   $��Century Gothic)�6R   $��Center=�5;      $��Center=�67   $
��50px��6[   $��270px��6i   6w   �� 5=      -   5        $	 AchievementButton��5=      $��1��6P   $��0��6]   $��Достижение��6m   $��24(�6�   $��Century Gothic)�6�   $��Center=�5>      $��Center=�67   $
��50px��6[   $��270px��6i   �� 5@      -   5        $��1��5@      $��1��6"   $��Турнир��62   $��24(�6C   $��Century Gothic)�6Q   $��Center=�5A      $��Center=�67   $
��50px��6[   $��270px��6i   6w   �� 5C      -   5        $��2��5C      $��0��6"   $!��Тип достижения��62   $��24(�6K   $��Century Gothic)�6Y   $��Center=�5D      $��Center=�67   $
��50px��6[   $��270px��6i   6w   �� 5F      -   5        $��2��5F      $��1��6"   $��Вид спорта��62   $��24(�6G   $��Century Gothic)�6U   $��Center=�5G      $��Center=�67   $
��50px��6[   $��270px��6i   6w   �� 5I      -   5        $��3��5I      $��0��6"   $+��%Название достижения��62   $��24(�6P   $��Century Gothic)�6^   $��Center=�5J      $��Center=�67   $
��50px��6[   $��270px��6i   6w   �� 5L      -	   5        $��3��5L      $��1��6"   $��Роль��62   $��24(�6A   $��Century Gothic)�6O   $��Center=�5M      $��Center=�67   $
��50px��6[   $��270px��6i   6w   5N      �� 5Q   
   -
   5        $	 
BackButton��5Q      $��3��6%   $��2��62   $��
Назад��6F   $��24(�6V   $��Century Gothic)�6d   $��Center=�5R      $��Center=�63   $
��50px��6W   $��200px��6e   $��Right=�5S      $��0,0,20,0q�6-   6?   5T      5U      