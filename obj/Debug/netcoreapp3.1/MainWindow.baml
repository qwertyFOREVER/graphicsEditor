   M S B A M L   `   `   `  ����P  LVectorGraphicRedactor, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:VectorGraphicRedactorVectorGraphicRedactor  5   	   &     VectorGraphicRedactor.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   X TXceed.Wpf.Toolkit, Version=3.8.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5   	   /local#clr-namespace:VectorGraphicRedactor  5   	   -   5          � Title$  SimplePaint��5
   	   $	��700��6   $
��1000��6-   .��5      � 
������� � ColumnDefinitions 5   
   �� 5      $	��150 �6   6-   �� 5      6!    � RowDefinitions 5   
   �� 5      $��0.05* �6   6-   �� 5      6   �� 5      $��0.05* �6   6-   .+�5   
   o� $��0��6   $��2��6   .@�5      m� $
��File��6   .@�5      �� -   5         ��Name$
 Save��5      $��	Save File��6'   6;   �� 5      -   5        $
 Open��5      $��	Open File��6'   6;   �� 5      -   5        $
 Exit��5      $
��Exit��6'   66   5      m� 5      -   5        $
��Info��5      6@   5      �� 5   
   -   5         ��Name$ Picture��5      $��1��6(   $��1��68   $��Visible=�6E   $��Visible=�6m   $��Stretch=�5      $��Stretch=�63   .��5"      )   #VectorGraphicRedactor.DrawingObject  -   5          Name$ DrawingObject��5"   "   6;   5#      � 5%   
   $��0��6   $��1��6    5&      �� 5'      $
��0.4* �6    �� 5(      .+�5*      � -   5         �Name$ 	ToolPanel��5*       � Orientation$ 
Horizontal=�6+   $��0��6D   
�������6Q   � 5+      -	   5        $ ConfigPanel��5+      $ Vertical=�6-   $��1��6D   $��4��6Q   
�������6e   5,      5-      5.      