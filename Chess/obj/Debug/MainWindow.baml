   M S B A M L   `   `   `  ����@  <Chess, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:ChessChess  5   	       Chess.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   %localclr-namespace:Chess     5   	   -   5          � Title$  
MainWindow��5   	   $	��438��6   $	��416��6)    � 
ResizeMode$ CanMinimize=�65   .��5	      � .+�5
   
   �� -   5        $��Board��5
      $��Assets/board.png��6   $
��Fill=�67   �� 5   
   -   5        $��	WhiteKing��5      $��Assets/WhiteKing.png��6!   $��200,350,0,0q�6?   $	��Top=�6T   $
��Left=�6l   $��50��6�   $��50��6�    � Cursor$
 Hand��6�   �� 5   
   -   5        $��	WhitePawn��5      $��Assets/WhitePawn.png��6!   $��200,300,0,0q�6?   $	��Top=�6T   $
��Left=�6l   $��50��6�   $��50��6�   $
 Hand��6�   �� 5   
   -   5        $��
MyBnFigure��5      $��Assets/BlackKnight.png��6"   $��	300,0,0,0q�6B   $	��Top=�6U   $
��Left=�6m   $��50��6�   $��50��6�   �� 5   
   -   5        $��
MyWbFigure��5      $��Assets/BlackBishop.png��6"   $��	250,0,0,0q�6B   $	��Top=�6U   $
��Left=�6m   $��50��6�   $��50��6�    J� RenderTransformOrigin$ -0.063,0.547&�6�   �� 5   
   -   5        $��	BlackRook��5      $��Assets/BlackRook.png��6!   $��	350,0,0,0q�6?   $	��Top=�6R   $
��Left=�6j   $��50��6�   $��50��6�   �� 5   
   -   5        $��	BlackKing��5      $��Assets/BlackKing.png��6!   $��	200,0,0,0q�6?   $	��Top=�6R   $
��Left=�6j   $��50��6�   $��50��6�   �� 5   
   -	   5         ��Name$ imageControl��5      $	��438��6&   $	��416��62   5      5      