   M S B A M L   `   `   `  ����I  EAudioPlayerApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:AudioPlayerAppAudioPlayerApp  5   	       AudioPlayerApp.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:AudioPlayerApp     5   	   -   5        $��
MainScreen��5   	   $	��900��6   $
��1440��5	   	   $	��600��6   $	��800��5
   	     � WindowStyle$
  None=�6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 30Q�6   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��30��6   ���#3c3c3c��6(   ��  �� ElementName$ 
MainScreen�� �� Path$ ActualWidth�.+�5      ��  �� TextAlignment$ Center=�6   $
��Left=�6/   ���#cdcdcd$	��150��6_   $��18(�6k   Audio Player App6�   � 5      $��Right=�6   .+�5      �� -   5         ��Name$ MinimizeBtn��5         IsHitTestVisibleInChrome$
 True��6.   
������    Button.Hoverless#���   6t   $��30��6�   $��30��6�   $	��5,0q�6�   .��5      �� $2��,pack://application:,,,/Graphics/minimize.png��6   5      �� 5      -   5        $ CloseBtn��5      $
 True��6+   
������ #���   6q   $��30��6�   $��30��6�   $	��5,0q�6�   .��5      �� $/��)pack://application:,,,/Graphics/close.png��6   5      5      5      5      5       