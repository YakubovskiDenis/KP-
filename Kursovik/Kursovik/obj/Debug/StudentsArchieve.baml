   M S B A M L   `   `   `  ����C  ?Kursovik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null#clr-namespace:KursovikKursovik  5   	       Kursovik.StudentsArchieve   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.3.0.3, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   "localclr-namespace:Kursovik  5   	   -   5          � Title$H  BСписок студентов состоящих на учете��5	      $
��1038��6-   $
��1701��6;    � WindowStyle$ ThreeDBorderWindow=�6H   $��Arial Rounded MT Bold)�6i   $��16(�6�    � WindowStartupLocation$ CenterScreen=�6�   .��5
      � -   5         �Name$ Mainroot��5
      ���	#ffdadada$��0,0,2,0q�66   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��ArchieveGrid��5   �      
IsReadOnly . $
��Left=�6>   $	��922��6Y   $��	54,21,0,0q�6f   $	��Top=�6y   $
��1151��6�      AutoGenerateColumns . 5      �� 5   
   $	��400��6   $��1239,21,52,0q�6    
�������$	��Top=�6I    �� Padding$ 30q�6a   $	��500��6n    �� CornerRadius$ 25��6}   $	��198��6�    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5      	   
BlurRadius$	 30Q�6#   
   Color$
 	LightGray��63      ShadowDepth$ 0Q�6E   ._�5      �� $��-20,0,-20,0q�6   $��Center=�6.   .+�5      �� -   5         ��Name$ 
DropButton��5      $��Очистить арив��6-   ���#0072F5
�������$	��350��6m   ���#0072F5$
��0 12q�6�   6�   �� 5      -   5        $ UpdateStudent��5      $3��-Вернуть студента на учет��60   ���#0072F5
�������$	��350��6{   ���#0072F5$
��0 12q�6�   6�   �� 5      -   5        $ GoBackStudent��5      $��
Назад��60   ���#0072F5
����������#0072F5$��115,12,128,12q�6~   6�   5      5      5      5      