   M S B A M L   `   `   `  ����G  CSportRecords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SportRecordsSportRecords  5   	       SportRecords.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SportRecords     5   	     � Title$  Авторизация��5   	   $	��530��6   $	��800��6*   ���#F5F5DC � Icon$ /avtoriz.png��6K   .��5      � $	��470��6   $	��NaN��6   $	��Top=�6$    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��140 �6   �� 5      $	��140 �6   �� 5      $	��83* �6    � ColumnDefinitions 5   
   �� 5      $��0* �6   �� 5      $	��200 �6   �� 5      $	��400 �6   �� 5      $	��200 �6   �� 5      $��0* �6   .+�5   
   �� $��80��6   $��Center=�6    $��1��6;   $��3��6K   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #BBDEFB��6#    � Offset$	 0.0Q�63   � 5      $ #4CAF50��6#   $	 1.0Q�63   5      5!      �� 5"   
   $��Resources/Logo.png��6   $��65��6,   $��65��67   $��
15,10,0,10q�6C   $��1��6W   $��0��6g   $
��Left=�6t   6�   �� 5#   
   $��Авторизация��6   
���   �$��30(�69   $��Century Gothic)�6G   $��2��6c   $��Center=�6s   $��Center=�6�   � 5'   
   $��1��6   $��2��6   .+�5(      �� $��
Логин��6   
���   �$��24(�67   $��Century Gothic)�6E   $��Center=�5)      $	��Top=�60   $
��10pxq�6H   �� 5*      -   5         ��Name$ LoginTextBox��5*      $
��60px��6,   $
��10pxq�6:   $��Center=�6H   $��20(�6j   $��Century Gothic)�6x   $��Bottom=�6�   5+      � 5.   
   $��2��6   $��2��6   .+�5/      �� $��Пароль��6   ���	#00000000
���   �$��24(�6O   $��Century Gothic)�6]   $��Center=�50      $	��Top=�6(   $
��10pxq�6@   G� 52      -   5        	 G�Name$	 PasswordTextBox��52      $
��60px��63   $
��10pxq�6A   $��Center=�6O   $��20(�53      $��Century Gothic)�6(   $��Bottom=�6D   6a   54      �� 55   
   -   5        
 ��Name$
 LoginButton��55      $��2��6&   $��
Войти��66   $��Center=�56      $��Center=�63   $��24(�57      $��Century Gothic)�6   $
��50px��6;   $��300px��6I   $��4��58      6   5:      5;      