   M S B A M L   `   `   `  ����N  JAPIManagmentConsole, Version=0.0.0.1, Culture=neutral, PublicKeyToken=nullO,clr-namespace:APIManagmentConsole.ConvertersAPIManagmentConsole.Converters  5      '    !APIManagmentConsole.Views.APIList   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      B	converter,clr-namespace:APIManagmentConsole.Converters     5        � 	Resources  5	      A   ;APIManagmentConsole.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverter�   �APIManagmentConsole.Converters.BooleanConverter`1[[System.Windows.Visibility, PresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35]]   True   False�� 5
   
   %@   &	          5      $ Visible=�6\   $ 	Collapsed=�6k   5      .��5      � 
�������.+�5   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��PRODUCT:��6   $
��Bold"�6+   �� 5      $
��Bold"�69   ��6   �� *Product.Name+69   5      �� 5      $
��Bold"�6   
���   �6*   �� 5      $��PRODUCT APIS:��6   $
��Bold"�6,   �� 5      $
��Bold"�6   
���   �6*   �� 5      $��Stretch=�6   $��Stretch=�65   $
��Left=�5   	   $	��150��6+   $	��200��6;   ��5   	   �� *ProductApis+ �� SelectedItem 6-   �� *SelectedApi+��5      �� 5       �� 
TargetType" ��6   .�5      ��  �� Property � �� �� Value$
 Left=�6G   5       �� View 5      �� 5       !	 �� ColumnHeaderContainerStyle	 5!      �� 5"      " ��6$   .�5#   "   ��  � ��$
 Left=�6O   5$      .P�5&      �� 
 �� Width$	
 450��6)   $	��API��65    �� DisplayMemberBinding 6B   �� *Name+5(      5*      �� 5+      $��Right=�6   $ 
Horizontal=�65   .+�5,      �� $��
Export API��6   ��6.   �� *ExportApiCommand+6U   �� 5-      $��Get API Operations��6   ��66   �� *GetApiOperationsCommand+6d   5.      �� 5/      $��0,20,0,0q�6   y�6+   �� *HasOperations+ �� 	Converter# [  .+�50      �� $��API OPERATIONS:��6   $
��Bold"�62   �� 51      $
��Bold"�6   
���   �6.   �� 52      $��Stretch=�6   $��Stretch=�69   $
��Left=�53      $	��250��64   $	��150��6D   ��54      �� *ApiOperations+ 68   �� *SelectedOperation+��55      �� 56      " ��6    .�57      ��  � ��$
 Left=�6K   58       5:      �� 5;      	 5<      �� 5=   "   " ��6(   .�5>   &   ��  � ��$
 Left=�6S   5?   #   .P�5A      �� $	
 100��6-   $��Method��69    6I   �� *Method+�� 5B      $	
 450��6-   $��	Operation��69    6L   �� *Name+5C      5E      �� 5F      $��Right=�6   $ 
Horizontal=�69   .+�5G      �� $��Export API Operation��6   ��6<   �� *ExportApiOperationCommand+6l   5H      5I      5K      5M      5N      