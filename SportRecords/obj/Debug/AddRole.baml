   M S B A M L   `   `   `  ����G  CSportRecords, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:SportRecordsSportRecords  5   	       SportRecords.AddRole   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:SportRecords     5   	     � Title$   Администратор��5      $	��592��6.   $	��900��6;   ���#F5F5DC.��5
      � $	��NaN��6    � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $	��370 �6   �� 5      �� 5      $��80 �6    � ColumnDefinitions 5   
   �� 5      $	��900 �6   .+�5   
   �� $��80��6   $��Center=�6    $��1��6;   $��3��6K   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��5      �  � Color$ #BBDEFB��6#    � Offset$	 0.0Q�63   � 5      $ #4CAF50��6#   $	 1.0Q�63   5      5      �� 5   
   $��Resources/Logo.png��6   $��65��6,   $��65��67   $��
15,10,0,10q�6C   $��1��6W   $��0��6g   $
��Left=�6t   6�   �� 5   
   $��Роли��6   
���   �$��30(�62   $��Century Gothic)�6@   $��2��6\   $��Center=�6l   $��Center=�6�   �� 5    
   -   5         ��Name$ 
EditButton��5       $��0��6>   $��3��6N   $ ��Редактировать��6[   $��Center=�5!      $��Center=�63   $��24(�5"      $��Century Gothic)�6   $��	700,0,0,0q�6;   $	��180��5#      $��50��6   $
��Left=�6)   $��Center=�6D   �� 5%   
   -   5        $ 
BackButton��5%      $��0��6>   $��3��6N   $��
Назад��6[   $��Center=�5&      $��Center=�63   $��24(�5'      $��Century Gothic)�6   $��20,0,0,0q�6;   $	��180��5(      $��50��6   $
��Left=�6)   $��Center=�6D   �� 5*   
   -   5        $ 	AddButton��5*      $��0��6<   $��3��6L   $��Добавить��6Y   $��Center=�5+      $��Center=�63   $��24(�5,      $��Century Gothic)�6   $��	280,0,0,0q�6;   $	��180��5-      $��50��6   $
��Left=�6)   $��Center=�6D   �� 5/   
   -   5        $ DeleteButton��5/      $��0��6B   $��3��6R   $��Удалить��6_   $��Center=�50      $��Center=�63   $��24(�51      $��Century Gothic)�6   $��	490,0,0,0q�6;   $	��180��52      $��50��6   $
��Left=�6)   $��Center=�6D   &   System.Windows.Controls.DataGrid  54   
   -   5          Name$ RoleDataGrid��55      $��1��56      $��Center=�57      $��Center=�58      
�������
�������$��1q�5;      $	��300��5<      $	��500��5=      	   AutoGenerateColumns	 .  
   ColumnHeaderHeight$
 40Q�5?         GridLinesVisibility$
 None=�5@         CanUserResizeColumns .     CanUserResizeRows .     HeadersVisibility$ Column=�5C         ColumnHeaderStyle 5F      �� 5G       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6   .�5H      ��  �� Property � �� �� Value �#51bec963   �� 5I       � ��
 �����63   �� 5J       � ��$
 Bold"�63   �� 5K       � ��$ Center=�6C   �� 5L       � ��$ 14(�61   �� 5M       � ��$ 5,3,5,3q�60   �� 5N       � ��
 �����64   �� 5O       � ��$ 0,0,1,1q�68   5P         RowStyle 5T      �� 5U      )  #System.Windows.Controls.DataGridRow"  6   .�5V      ��  � ��$ 13(�61   �� 5W       � ��
 �����63   �� 5X       � ��
 �����64   �� 5Y       � ��$ 0,0,0,1q�68   �� 5Z       � ��$
 Left=�6C   �� 5[       � ��$	 Top=�6:   �� 5\       � ��$ 0,0,0,2q�6/   5]         	CellStyle 5a      �� 5b      *  $System.Windows.Controls.DataGridCell"  6   .�5c      ��  � ��$ 5q�60   �� 5d       � ��
 �����64   �� 5e       � ��$ 1q�68   5f         Columns 5j      0  *System.Windows.Controls.DataGridTextColumn  5l      ,  &System.Windows.Controls.DataGridColumn   Header$ ID��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 117 61   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6=   �� *id+  5o      $ Название роли��6%   $	 380 6<    6H   �� *name+5r      5s      5t      