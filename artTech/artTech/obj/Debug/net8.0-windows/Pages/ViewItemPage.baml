   M S B A M L   `   `   `  ����B  >artTech, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:artTech.PagesartTech.Pages  5      7 clr-namespace:artTech.ComponentsartTech.Components  61        artTech.Pages.ViewItemPage   5      _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:artTech.Pages     5      7
components clr-namespace:artTech.Components     61     N� Title$  ViewItemPage��5
      .��5      � 
�������$��0 40 0 0q�6    � ColumnDefinitions 5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� -   5         ��Name$ ImageSrc��5      $��0��5      $	��350��5      $	��Top=�5      $��/Resources/Image/ssd1.jpg��5      �� 5   
   $��1��5      $��Hidden=�5      .��5      � .+�5      �� -   5         ��Name$ Title��5      $��1��5      $��32(�5       $	��Top=�5!      $
��Left=�5"       "  TextBlock_StyleFonts_BlackBold#���   5#      5%      �� 5'      -   5        $ Price��5(      $��1��5)      $��2323.00$��5*      $��26(�5+      $	��Top=�5,      $
��Left=�5-      $��0 60 0 0q�5.      #���   5/      �� 51      $��1��52      $��Specification:��53      $��26(�54      $	��Top=�55      $
��Left=�56      $��	0 150 0 0q�57      #���   58      � 5:      $��	0 200 0 0q�5;      $��1��5<       � RowDefinitions 5>      �� 5?      $
��auto �6(   �� 5@      $
��auto �6(   .+�5C      �� $��0��5D      $
��Left=�5F      $	��Top=�5G      ��5E      �� *Specifications+��5H      �� 5I      .R�5J   "   /   )artTech.Components.SpecificationComponent  5K      ��5M      �� 5N      .R�5O   "   � 5P      5R      � 5T      $��1��5U      $��0 10 0 0q�5V      .+�5X      �� $��1��5Y      $��0 25 0 0q�5Z      $��	Comment: ��5[      $��26(�5\      $	��Top=�5]      $
��Left=�5^      #���   5_      �� 5a      -   5         ��Name$ CommentText��5b      $��22(�5c      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Write Comment��5d      $	��165��5e      $��	150 0 0 0q�5f      $	��Top=�5g      $
��Left=�5h       # FloatingHintTextBox_MediumStyle#���  5i      �� 5k      -   5         ��Name$ 	AddButton��5l      $	��Add��5m      
���   �$��18(�5o      
������ $��65��5q      $��
335 25 0 0q�5r      $	��Top=�5s      $
��Left=�5t        Button_FontStyle#���  5u      6H   �� 5w      $��0 75 0 0q�5y      $
��Left=�5z      $	��Top=�5{      ��5x      �� *
Comments+��5|      �� 5}   "   .R�5~   &     5   #   ��5�      �� 5�   "   .R�5�   &   � 5�   #   5�      5�      5�      5�      5�      5�      5�      