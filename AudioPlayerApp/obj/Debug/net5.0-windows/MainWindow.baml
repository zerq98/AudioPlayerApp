   M S B A M L   `   `   `  ����U  QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf  5   	    AudioPlayerApp   AudioPlayerApp.MainWindow   5   	   \ XPresentationFramework, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=5.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=5.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Dchr4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5   	   -   5        $��
MainScreen��5   	   $	��900��6   $
��1440��5	   	   $	��600��6   $	��800��5
   	     � WindowStyle$
  None=�6   '  !System.Windows.Shell.WindowChrome   WindowChrome 5        5   
      CaptionHeight$ 30Q�6   .��5      �  � RowDefinitions 5   
   �� 5      $��30 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��30��6   ���#3c3c3c��6(   ��  �� ElementName$ 
MainScreen�� �� Path$ ActualWidth�.+�5      ��  �� TextAlignment$ Center=�6   $
��Left=�6/   ���#cdcdcd$	��150��6_   $��18(�6k   Audio Player App6�   � 5      $��Right=�6   .+�5      �� -   5         ��Name$ MinimizeBtn��5         IsHitTestVisibleInChrome$
 True��6.   
������    Button.Hoverless#���   6t   $��30��6�   $��30��6�   $	��5,0q�6�   .��5      �� $��/minimize.png��6   5      �� 5      -   5        $ CloseBtn��5      $
 True��6+   
������ #���   6q   $��30��6�   $��30��6�   $	��5,0q�6�   .��5      �� $��
/close.png��6   5      5      5      �� 5   
   $��1��6   .+�5       � -   5        $��ImagesPanel��5       .+�5!      �� $	��370��6   $	��850��6*   $��30,10q�66   .+�5"      �� -   5        	 ��Name$	 SpectrumBorder��5"      
���   �$��2q�6I   $	��300��6]   $	��850��6j   ._�5#      �� -   5        
 ��Name$
 SpectrumImage��5#       $��Uniform=�6�   ��67   �� $ SpectrumBorder��$ ActualHeight���6z   �� $ SpectrumBorder��$ ActualWidth�6�   5$      � 5%      .+�5&      �� -   5        $ 
LoadWavBtn��5&   !   $��60��65   $��60��6@   $��10,5,0,0q�6L   $
��Left=�6^   
������ #���   6�   .��5'      �� .+�5(   "   �� $��Graphics/loadFile.png��6(   $��40��6G   6T   �� 5)   "   $��loadFile��6,   6>   5*      5+      �� 5,      .+�5-      �� -   5         ��Name$ DurationSlider��5-   %    � Value$ 0Q�6=   $	��500��6G   $��25��6S   $	��Top=�6_   $��0,10,0,0q�6w   6�   � 5.      $��30��6(   .+�5/   "   �� -	   5        $ StepBackBtn��5/   )   #���   6>   $��30��6i   $��30��6t   
������ .��50   &   �� $��/Graphics/backward.png��6,   6N   51   #   �� 52   "   -
   5        $ PlayPauseBtn��52   )   #���   6?   $��30��6j   $��30��6u   
������ .��53   &   �� -   5        $
 PlayPauseImg��53   ,   $��/Graphics/play.png��6B   6`   54   #   �� 55   "   -   5        $ 
ForwardBtn��55   )   #���   6=   $��30��6h   $��30��6s   
������ .��56   &   �� $��/Graphics/forward.png��6,   6M   57   #   58      59      �� 5:      -   5         ��Name$ DurationText��5:   $   $�� ��6:   $	��120��6B   $��30��6N   $ Center=�6Z   $��20(�6q   6�   5;      5<      5=      � 5>      -   5        $��ChartsPanel��5>      $	��300��6+   ��68   �� $ 
MainScreen��$ ActualWidth�.+�5?      #   LiveCharts.Wpf.CartesianChart  -   5        $��VolumeChart��5?   M   $��1q�6%   
���   ���6`   �� $ ChartsPanel��$ ActualHeight�&    LiveCharts.Wpf.Charts.Base.Chart   Series 5A         LiveCharts.Wpf.LineSeries  -   5          Name$ LeftChannel��5A   )      LiveCharts.Wpf.Series   Fill �	#26FF0000 � ToolTip$ LeftChannel��6O     5B      -   5        $ RightChannel��5B   )    �	#260000FF$ RightChannel��6P   5D      5E      5F      5G      5H      