   M S B A M L   `   `   `  ����H  DHamburgerMenu, Version=0.1.0.0, Culture=neutral, PublicKeyToken=nullD2clr-namespace:HamburgerMenu;assembly=HamburgerMenuHamburgerMenu  5   	   F BSmartSchool, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:SmartSchoolSmartSchool 5   	      SmartSchool.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   LHamburgerMenu2clr-namespace:HamburgerMenu;assembly=HamburgerMenu     5   	   +localclr-namespace:SmartSchool     5   	     � Title$  
MainWindow��5	   	   $	��450��6   $	��800��6)   .��5
      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      .+�5   
   !   HamburgerMenu.HamburgerMenu  -   5          Name$ MyMenu��5   &      MenuIconColor
 �����   SelectionIndicatorColor
 �����   MenuItemForeground
 �   �$
��Left=�6�   $��0��6�   $	��120��6�   ��5      �� 5       �� ImageSource$ Assets\mountain.jpeg��6    j� Stretch$
 None=�6@      Content 5      %   HamburgerMenu.HamburgerMenuItem  -   5        	  Name$	 Dummy��5   2   
   Text$
 Dummy��6A   $y�	Collapsed=�6O     5      -   5           Icon$ Assets/home.png��5   2   $

 Home��6I      SelectionCommand 6U   ��  �� ElementName$ this_��6�     5      -   5        $ Assets/search.png��5   2   $
 Page1��6M    6Z   �� $ this_��6�     5      -   5        $ Assets/favorite.png��5   2   $
 Page2��6M    6Z   �� $ this_��6�     5      -   5        $	 Backward��5   3   $ Assets/Left.png��6E   $
 Backward��6]    � ToolTip$ Backward��6m    6�   �� $ this_��  5      -   5        $	 Forward��5   3   $ Assets/Right.png��6D   $
 Forward��6]   $ Forward��6l    6�   �� $ this_��5       � 5    
   -   5          �Name$ myFrame��5       $��1��6!     � Source$ HomePage.xaml?�61   5"      5#      