   M S B A M L   `   `   `  ����B  >artTech, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:artTechartTech  5   	       artTech.MainWindow   5   	   _ [MaterialDesignThemes.Wpf, Version=4.2.1.2, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:artTech     5   	   -   5          � Title$  artTech��5	   	   $	��800��6   $
��1200��6&   $	��600��63   $	��500��6B    � WindowStartupLocation$ CenterScreen=�6R    � Icon$" /Resources/Image/appIcon.ico��6�    � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� Orientation	 �� CornerRadius
 ��Name'  !MaterialDesignThemes.Wpf.PackIcon  Name   Kind ��Name � 	Resources   Key �� TargetProperty �� 
TargetName g� Duration t� From	 t� To t� EasingFunction/  )System.Windows.Media.Animation.CircleEase7  1System.Windows.Media.Animation.EasingFunctionBase   
EasingMode �� Triggers P� Property P� Value N� ExitActions �� BeginStoryboardName ��Name 	 right �� 
TargetName  left��%�  '��       7  7  �� 5   
   " ��6   .�5      ��  � �� 5      �� 5      " ��6&   .R�5      �� $ 
Horizontal=�6%   .+�5      � .+�5   "   �� $��45��6)   $��20��64   
�������$	 10��6W   $	��4,0q�6i   6x   �� 5   "   $
 button��6)   $��17��69   $��17��6E   $
	 12.5��6P   $
��Left=�6d   $��6,0,0,0q�6   ._�5   &     $ 
buttonIcon��6>   $ WbSunny=�6R   $��14��6a   $��14��6m   $��1.4,1.8,0,0q�6x   5   #   5      �� 5      $ content��6/   $��10,0,0,0q�6@   #��z��6R   $��Center=�6v   5       5      ���� 5      	right  .��5   "   t� $ Margin�65   $ button��6X   $ 0:0:0.4D�6w    6,0,0,06�    30,0,0,06�    5   &     5   *   $ EaseOut=�65   5   #   5       �� 5!      left  .��5"   "   t� $ Margin�65   $ button��6X   $ 0:0:0.4D�6w    30,0,0,06�    6,0,0,06�    5#   &     5$   *   $ EaseOut=�65   5&   #   5'      5(       5)      P� 5*       �@d�	IsChecked$ falseY�6;    5+   "   �� 5,   &   $ leftt��67   6U   �� 5-   &   $ rightt��6Z   8��  6m   . �5/   "   �� $ button��6)    � �� �#7575756e   50      P� 51       �@d�	IsChecked$
 trueY�6;    52   "   �� 53   &   $ rightt��67   6V   �� 54   &   $ leftt��6Y   8�� 6k   . �56   "   �� $ button��6)    � �� �#7575756S   �� 57   "   $ 
buttonIcon��6)    �@ Kind$ WeatherNight=�6Q   58      5:      5<      5=      5>      .��5@      �   LightThemeBackground_Grid#���  6    � ColumnDefinitions 5A   
   �� 5B      $��1* �6   �� 5C      $��6* �6   �� 5D      $��1* �6    � RowDefinitions 5G   
   �� 5H      $	��100 �6   �� 5I      $��8* �6   �� 5J      $��75 �6   .+�5M   
   �� $��0��6   $��1��6"   $��1��62   .+�5N      � $��0 0 0 10q�6   .+�5O      �� -   5         ��Name$ Theme��5P      $��6,10,0,0q�5Q      $
��Left=�5R      5S      �� 5U        m_MainTitle_TextBlock#��[ 5V      $��Center=�5W      $��34(�5X       % !TextBlock_StyleFonts_BlackRegular#���  5Y      �� 5[      -   5          ��Name$  LogInButton��5\        m_LogOrReg_Button#���  5]      $��Right=�5^      $��Bottom=�5_       ! FlatButtonDesign_RegularStyle#���  5`      5a      5c      � 5e      .+�5l      �� -   5        $  CatalogButton��5m        m_Catalog_ComboBox#���  5n      $��5,10,0,0q�5o      $��4q�5p      $
��Left=�5q      $��Bottom=�5r      #���  5s      5t      �� 5v      -   5        $  Configurator��5w       	 m_Config_Button#��� 	 5x      $��	70 10 0 0q�5y      $��4q�5z      $
��Left=�5{      $��Bottom=�5|      #���  5}      5~      �� 5�      -   5        $  
AddNewItem��5�       
 m_AddNewItem_Button#��� 
 5�      $��
170 10 0 0q�5�      $��4q�5�      $
��Left=�5�      $��Bottom=�5�      #���  5�      5�      �� 5�      -   5        ! ��Name$! Search��5�        m_Search_TextBox)  #MaterialDesignThemes.Wpf.HintAssist"   Hint#" �  5�      $	��120��5�      $��	0 0 10 10q�5�      $��Right=�5�       $  FloatingHintTextBox_RegularStyle#���  5�      5�      5�      5�      �� 5�   
   $��0��5�      $��0��5�      $��3��5�      
�������$��1q�5�       � 5�   
   -   5        #  �Name$# 	MainFrame��5�      $��1��5�      $��1��5�      $��	0,10,0,10q�5�      $  � NavigationUIVisibility$$ Hidden=�5�      �� 5�   
   $��2��6   $��0��6"   $��3��62   
���   �.+�5�      � -	   5        % �Name$% LanguageSettings��5�      $��Center=�6-   $	��135��6q   & � Cursor$
& Hand��6}   .+�5�      �� -
   5        ' ��Name$' Language��5�      $��18(�5�        m_Language_TextBlock#���  5�      
�������$��0 15 0 0q�5�      $
��Left=�5�      $��Center=�5�        TextBlock_RegularStyle#���  5�      �� 5�      -   5        $' 
LanguageID��5�      $��18(�5�        m_LanguageID_TextBlock#���  5�      ���#C83B1D$��0 15 0 0q�5�      $��Right=�5�      $��Center=�5�      #���  5�      5�      � 5�      -   5        $% LanguageChoise��5�      $	��120��6+   $��Center=�67   $��0 5 0 0q�6T   .+�5�      �� -   5        $' ru_Language��5�         m_LanguageButtonRU_TextBlock#���  5�      $��14(�5�      $��Right=�6#   
�������$y�Hidden=�5�      $
& Hand��5�      #���  5�      5�      �� 5�      -   5        $' en_Language��5�         m_LanguageButtonEN_TextBlock#���  5�      $��14(�5�      $
��Left=�5�      ���#C83B1D$y�Hidden=�5�      $
& Hand��5�      #���  5�      5�      5�      5�      5�      5�      