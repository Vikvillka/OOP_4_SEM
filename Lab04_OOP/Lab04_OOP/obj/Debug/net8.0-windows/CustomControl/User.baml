   M S B A M L   `   `   `  ����D  @Lab04_OOP, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Lab04_OOP.CustomControlLab04_OOP.CustomControl  5      7 clr-namespace:Lab04_OOP.CommandsLab04_OOP.Commands  5      "    Lab04_OOP.CustomControl.User   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:Lab04_OOP.CustomControl     5      5commands clr-namespace:Lab04_OOP.Commands     5        J� CommandBindings  5
      )  #System.Windows.Input.CommandBinding  5   
   -   5           Command$4 .commands:AplicationCommand.RestoreStateCommand��5      6R   .��5      �  � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5   
   �� -   5         ��Name$ userBut��5   J   $4��.commands:AplicationCommand.RestoreStateCommand��6   
�������
���   �.��6�   Undo6�   �� 5   
   -   5        $ userButR��5      
�������
���   �$��1��6I   .��6Y   Redo6_   5      5      