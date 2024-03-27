using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Media;
namespace Chess
{
    public partial class MainWindow : Window
    {

        public static int[,] ChessBoard = {
                                { 0, 0, 0, 0, -1000, -33, -30, -50  },
                                { 0, 0, 0, 0,   0,    0,    0,  0   },
                                { 0, 0, 0, 0,   0,    0,    0,  0   },
                                { 0, 0, 0, 0,   0,    0,    0,  0   },
                                { 0, 0, 0, 0,   0,    0,    0,  0   },
                                { 0, 0, 0, 0,   0,    0,    0,  0   },
                                { 0, 0, 0, 0,   10,   0,    0,  0   },
                                { 0, 0, 0, 0,   1000, 0,    0,  0   }
        };

        bool Random_Move_V = false, King_V, Bishop_V = false, Rook_V = false, Bishop_V_second = false, Rook_V_second = false, Bishop_V_third = false, Rook_V_third = false, White_Pawn = false, White_King = false;
        double DeltaX, DeltaY;
        int WhitePawn_Position_Y = 6, WhitePawn_Position_X = 4, WhiteKing_Position_Y = 7, WhiteKing_Position_X = 4;
        int BlackKnight_Position_Y = 0, BlackKnight_Position_X = 6, BlackBishop_Position_Y = 0, BlackBishop_Position_X = 5, BlackRook_Position_Y = 0, BlackRook_Position_X = 7, BlackKing_Position_Y = 0, BlackKing_Position_X = 4, BlackKnight_Position_Ytemp = 0, BlackKnight_Position_Xtemp = 6, BlackBishop_Position_Ytemp = 0, BlackBishop_Position_Xtemp = 5, BlackRook_Position_Ytemp = 0, BlackRook_Position_Xtemp = 7;

        SoundPlayer player = new SoundPlayer(Properties.Resources.step);
        SoundPlayer gameover = new SoundPlayer(Properties.Resources.game);
        public MainWindow()
        {
            
            InitializeComponent();
           

        }

        
        

        void Window_MouseMove(object sender, MouseEventArgs e)
        {

            if (White_Pawn == true)
                WhitePawn.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
            if (White_King == true)
                WhiteKing.Margin = new Thickness(e.GetPosition(this).X - DeltaX, e.GetPosition(this).Y - DeltaY, 0, 0);
        }

        void WhiteKing_MouseDown(object sender, MouseButtonEventArgs e)
        {
            
            if (e.ButtonState == e.LeftButton)
            {
                StackPanel.SetZIndex(WhiteKing, 1);
                StackPanel.SetZIndex(WhitePawn, 0);
                White_King = true;
                DeltaX = e.GetPosition(this).X - WhiteKing.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhiteKing.Margin.Top;
                

            }
            player.Play();
        }

        void WhiteKing_MouseUp(object sender, MouseButtonEventArgs e)
        {
            White_King = false;
            
            WhiteKing.Margin = new Thickness((int)(WhiteKing.Margin.Left + 25) / 50 * 50, (int)(WhiteKing.Margin.Top + 25) / 50 * 50, 0, 0);
            ChessBoard[(int)(WhiteKing.Margin.Top + 25) / 50, (int)(WhiteKing.Margin.Left + 25) / 50] = 1000;
            ChessBoard[WhiteKing_Position_Y, WhiteKing_Position_X] = 0;
            WhiteKing_Position_Y = (int)(WhiteKing.Margin.Top + 25) / 50;
            WhiteKing_Position_X = (int)(WhiteKing.Margin.Left + 25) / 50;
            //Implementing point 1
            Criteria_first();

        }
        void WhitePawn_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == e.LeftButton)
            {
                StackPanel.SetZIndex(WhitePawn, 1);
                StackPanel.SetZIndex(WhiteKing, 0);
                White_Pawn = true;
                DeltaX = e.GetPosition(this).X - WhitePawn.Margin.Left;
                DeltaY = e.GetPosition(this).Y - WhitePawn.Margin.Top;
            }
            player.Play();
        }

        void WhitePawn_MouseUp(object sender, MouseButtonEventArgs e)
        {
            White_Pawn = false;
            WhitePawn.Margin = new Thickness((int)(WhitePawn.Margin.Left + 25) / 50 * 50, (int)(WhitePawn.Margin.Top + 25) / 50 * 50, 0, 0);
            ChessBoard[(int)(WhitePawn.Margin.Top + 25) / 50, (int)(WhitePawn.Margin.Left + 25) / 50] = 10;
            ChessBoard[WhitePawn_Position_Y, WhitePawn_Position_X] = 0;
            WhitePawn_Position_Y = (int)(WhitePawn.Margin.Top + 25) / 50;
            WhitePawn_Position_X = (int)(WhitePawn.Margin.Left + 25) / 50;
            //Implementing point 1
            Criteria_first();

        }


        int Rook(int BlackRook_Position_Ytemp, int BlackRook_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((j == BlackRook_Position_Xtemp || i == BlackRook_Position_Ytemp) && ChessBoard[i, j] == 1000)
                    {
                        if (j == BlackRook_Position_Xtemp)
                        {
                            for (int l = 1; l < Math.Abs(WhiteKing_Position_Y - BlackRook_Position_Ytemp); l++)
                            {
                                if (WhiteKing_Position_Y > BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp + l, j] != 0)
                                {
                                    return 0;
                                }
                                if (WhiteKing_Position_Y < BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp - l, j] != 0)
                                {
                                    return 0;
                                }
                            }
                        }
                        else
                        {
                            for (int l = 1; l < Math.Abs(WhiteKing_Position_X - BlackRook_Position_Xtemp); l++)
                            {
                                if (WhiteKing_Position_X > BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp + l] != 0)
                                {
                                    return 0;
                                }
                                if (WhiteKing_Position_X < BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp - l] != 0)
                                {
                                    return 0;
                                }
                            }
                        }
                        if (ChessBoard[BlackRook_Position_Ytemp, BlackRook_Position_Xtemp] >= 0)
                        {
                            ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] = 0;
                            BlackRook_Position_Y = BlackRook_Position_Ytemp;
                            BlackRook_Position_X = BlackRook_Position_Xtemp;
                            ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] -= 50;
                            BlackRook.Margin = new Thickness(BlackRook_Position_Xtemp * 50, BlackRook_Position_Ytemp * 50, 0, 0);
                            return 11;
                        }
                    }
                }
            }
            return 0;
        }



        int Bishop(int BlackBishop_Position_Ytemp, int BlackBishop_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (Math.Abs(BlackBishop_Position_Ytemp - i) == Math.Abs(BlackBishop_Position_Xtemp - j) && ChessBoard[i, j] == 1000)
                    {
                        for (int l = 1; l < Math.Abs(WhiteKing_Position_Y - BlackBishop_Position_Ytemp); l++)
                        {
                            if (WhiteKing_Position_Y > BlackBishop_Position_Ytemp && WhiteKing_Position_X < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y > BlackBishop_Position_Ytemp && WhiteKing_Position_X > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y < BlackBishop_Position_Ytemp && WhiteKing_Position_X < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                return 0;
                            }
                            if (WhiteKing_Position_Y < BlackBishop_Position_Ytemp && WhiteKing_Position_X > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                return 0;
                            }
                        }
                        if (ChessBoard[BlackBishop_Position_Ytemp, BlackBishop_Position_Xtemp] >= 0)
                        {
                            ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] = 0;
                            BlackBishop_Position_Y = BlackBishop_Position_Ytemp;
                            BlackBishop_Position_X = BlackBishop_Position_Xtemp;
                            ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] -= 33;
                            MyWbFigure.Margin = new Thickness(BlackBishop_Position_Xtemp * 50, BlackBishop_Position_Ytemp * 50, 0, 0);
                            return 11;
                        }
                    }
                }
            }
            return 0;
        }


        int Knight(int BlackKnight_Position_Ytemp, int BlackKnight_Position_Xtemp)
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (((Math.Abs(BlackKnight_Position_Ytemp - i) == 2 && Math.Abs(BlackKnight_Position_Xtemp - j) == 1) || (Math.Abs(BlackKnight_Position_Ytemp - i) == 1 && Math.Abs(BlackKnight_Position_Xtemp - j) == 2)) && ChessBoard[i, j] == 1000)
                    {
                        if (ChessBoard[BlackKnight_Position_Ytemp, BlackKnight_Position_Xtemp] >= 0)
                        {
                            ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] = 0;
                            BlackKnight_Position_X = BlackKnight_Position_Xtemp;
                            BlackKnight_Position_Y = BlackKnight_Position_Ytemp;
                            ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] -= 30;
                            MyBnFigure.Margin = new Thickness(BlackKnight_Position_Xtemp * 50, BlackKnight_Position_Ytemp * 50, 0, 0);
                           
                            return 11;
                        }
                    }
                }
            }
            return 0;
        }

        void Utel(int[,] ChessBoard, int j, int i)
        {
                    if (ChessBoard[j, i] == 970)
                    {
                        string imagePath1 = "aaaaaaaaaaaaaaaaa";
                        BitmapImage bitmap1 = new BitmapImage(new Uri(imagePath1, UriKind.RelativeOrAbsolute));
                       
                        WhitePawn.Source = bitmap1;
                        BlackKing.Source = bitmap1;
                        
                        MyWbFigure.Source = bitmap1;
                        BlackRook.Source = bitmap1;
                        string imagePath = "Assets/gameover.jpg";
                        BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                        Board.Source = bitmap;
                 gameover.Play();
                        return;
                           

                    }else if(ChessBoard[j, i] == 950)
                    {
                        string imagePath1 = "aaaaaaaaaaaaaaaa"; 
                        BitmapImage bitmap1 = new BitmapImage(new Uri(imagePath1, UriKind.RelativeOrAbsolute));
                        
                        WhitePawn.Source = bitmap1;
                        BlackKing.Source = bitmap1;
                        MyBnFigure.Source = bitmap1;
                        MyWbFigure.Source = bitmap1;                        
                        string imagePath = "Assets/gameover.jpg"; 
                        BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                        Board.Source = bitmap;
                gameover.Play();
                return;
                    }
                    else if(ChessBoard[j, i] == 967)
                    {
                        string imagePath1 = "aaaaaaaaaaaaaaaaa"; 
                        BitmapImage bitmap1 = new BitmapImage(new Uri(imagePath1, UriKind.RelativeOrAbsolute));
                        
                        WhitePawn.Source = bitmap1;
                        BlackKing.Source = bitmap1;
                        MyBnFigure.Source = bitmap1;
                        
                        BlackRook.Source = bitmap1;
                        
                        string imagePath = "Assets/gameover.jpg"; 
                        BitmapImage bitmap = new BitmapImage(new Uri(imagePath, UriKind.RelativeOrAbsolute));
                        Board.Source = bitmap;
                gameover.Play();
                        return;

            }
                    else if (ChessBoard[j, i] == -23 || ChessBoard[j, i] == -20 || ChessBoard[j, i] == -40)
                    {
                        string imagePath1 = "aaaaaaaaaaaaaaaaaaaaa"; 
                        BitmapImage bitmap1 = new BitmapImage(new Uri(imagePath1, UriKind.RelativeOrAbsolute));
                        WhitePawn.Source = bitmap1;
                        return;


            }
                    else
                    {
                        
                        imageControl.Visibility = Visibility.Collapsed;
                    }
               
           
        }


        void Criteria_first()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((j == BlackRook_Position_X || i == BlackRook_Position_Y) && ChessBoard[i, j] == 1000)
                    {
                        Rook_V_second = false;
                        if (j == BlackRook_Position_X)
                        {
                            for (int l = 1; l < Math.Abs(i - BlackRook_Position_Y); l++)
                            {
                                if (i > BlackRook_Position_Y && ChessBoard[BlackRook_Position_Y + l, j] != 0)
                                {
                                    Rook_V_second = true;
                                    break;
                                }
                                if (i < BlackRook_Position_Y && ChessBoard[BlackRook_Position_Y - l, j] != 0)
                                {
                                    Rook_V_second = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int l = 1; l < Math.Abs(j - BlackRook_Position_X); l++)
                            {
                                if (j > BlackRook_Position_X && ChessBoard[i, BlackRook_Position_X + l] != 0)
                                {
                                    Rook_V_second = true;
                                    break;
                                }
                                if (j < BlackRook_Position_X && ChessBoard[i, BlackRook_Position_X - l] != 0)
                                {
                                    Rook_V_second = true;
                                    break;
                                }
                            }
                        }
                        if (!Rook_V_second)
                        {
                            ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] = 0;
                            BlackRook_Position_Y = i;
                            BlackRook_Position_X = j;
                            ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] -= 50;
                            BlackRook.Margin = new Thickness(j * 50, i * 50, 0, 0);
                            Utel(ChessBoard, BlackRook_Position_Y, BlackRook_Position_X);
                            return;
                        }
                    }
                    else if (Math.Abs(BlackBishop_Position_Y - i) == Math.Abs(BlackBishop_Position_X - j) && ChessBoard[i, j] == 1000)
                    {
                        Bishop_V_second = false;
                        for (int l = 1; l < Math.Abs(i - BlackBishop_Position_Y); l++)
                        {
                            if (i > BlackBishop_Position_Y && j < BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y + l, BlackBishop_Position_X - l] != 0)
                            {
                                Bishop_V_second = true;
                                break;
                            }
                            if (i > BlackBishop_Position_Y && j > BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y + l, BlackBishop_Position_X + l] != 0)
                            {
                                Bishop_V_second = true;
                                break;
                            }
                            if (i < BlackBishop_Position_Y && j < BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y - l, BlackBishop_Position_X - l] != 0)
                            {
                                Bishop_V_second = true;
                                break;
                            }
                            if (i < BlackBishop_Position_Y && j > BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y - l, BlackBishop_Position_X + l] != 0)
                            {
                                Bishop_V_second = true;
                                break;
                            }
                        }
                        if (!Bishop_V_second)
                        {
                            ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] = 0;
                            BlackBishop_Position_Y = i;
                            BlackBishop_Position_X = j;
                            ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] -= 33;
                            MyWbFigure.Margin = new Thickness(j * 50, i * 50, 0, 0);
                            Utel(ChessBoard, BlackBishop_Position_Y, BlackBishop_Position_X);
                            return;
                        }
                    }
                    else if (((Math.Abs(BlackKnight_Position_Y - i) == 2 && Math.Abs(BlackKnight_Position_X - j) == 1) || (Math.Abs(BlackKnight_Position_Y - i) == 1 && Math.Abs(BlackKnight_Position_X - j) == 2)) && ChessBoard[i, j] == 1000)
                    {
                        ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] = 0;
                        BlackKnight_Position_Y = i;
                        BlackKnight_Position_X = j;
                        ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] -= 30;
                        MyBnFigure.Margin = new Thickness(j * 50, i * 50, 0, 0);
                        Utel(ChessBoard, BlackKnight_Position_Y, BlackKnight_Position_X);
                        return;
                    }

                }
            }
            BlackRook_Position_Ytemp = BlackRook_Position_Y;
            BlackRook_Position_Xtemp = BlackRook_Position_X;
            BlackBishop_Position_Ytemp = BlackBishop_Position_Y;
            BlackBishop_Position_Xtemp = BlackBishop_Position_X;
            BlackKnight_Position_Xtemp = BlackKnight_Position_X;
            BlackKnight_Position_Ytemp = BlackKnight_Position_Y;
            
            Criteria_second();
        }

        void Criteria_second()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((j == BlackRook_Position_Xtemp || i == BlackRook_Position_Ytemp) && ChessBoard[i, j] >= 0)
                    {
                        Rook_V = false;
                        if (j == BlackRook_Position_Xtemp)
                        {
                            for (int l = 1; l < Math.Abs(i - BlackRook_Position_Ytemp); l++)
                            {
                                if (i > BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp + l, j] != 0)
                                {
                                    Rook_V = true;
                                    break;
                                }
                                if (i < BlackRook_Position_Ytemp && ChessBoard[BlackRook_Position_Ytemp - l, j] != 0)
                                {
                                    Rook_V = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            for (int l = 1; l < Math.Abs(j - BlackRook_Position_Xtemp); l++)
                            {
                                if (j > BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp + l] != 0)
                                {
                                    Rook_V = true;
                                    break;
                                }
                                if (j < BlackRook_Position_Xtemp && ChessBoard[i, BlackRook_Position_Xtemp - l] != 0)
                                {
                                    Rook_V = true;
                                    break;
                                }
                            }
                        }
                        if (!Rook_V)
                        {
                            if (Rook(i, j) == 11)
                            {
                                Utel(ChessBoard, i, j);
                                return;
                            }
                        }
                    }
                    if (Math.Abs(BlackBishop_Position_Ytemp - i) == Math.Abs(BlackBishop_Position_Xtemp - j) && ChessBoard[i, j] >= 0)
                    {
                        Bishop_V = false;
                        for (int l = 1; l < Math.Abs(i - BlackBishop_Position_Ytemp); l++)
                        {
                            if (i > BlackBishop_Position_Ytemp && j < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                Bishop_V = true;
                            }
                            if (i > BlackBishop_Position_Ytemp && j > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp + l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                Bishop_V = true;
                            }
                            if (i < BlackBishop_Position_Ytemp && j < BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp - l] != 0)
                            {
                                Bishop_V = true;
                            }
                            if (i < BlackBishop_Position_Ytemp && j > BlackBishop_Position_Xtemp && ChessBoard[BlackBishop_Position_Ytemp - l, BlackBishop_Position_Xtemp + l] != 0)
                            {
                                Bishop_V = true;
                            }
                        }
                        if (!Bishop_V)
                        {
                            if (Bishop(i, j) == 11)
                            {
                                Utel(ChessBoard, i, j);
                                return;
                            }
                        }
                    }

                    if (((Math.Abs(BlackKnight_Position_Ytemp - i) == 2 && Math.Abs(BlackKnight_Position_Xtemp - j) == 1) || (Math.Abs(BlackKnight_Position_Ytemp - i) == 1 && Math.Abs(BlackKnight_Position_Xtemp - j) == 2)) && ChessBoard[i, j] >= 0)
                    {
                        if (Knight(i, j) == 11)
                        {
                            Utel(ChessBoard, i, j);
                            return;
                        }
                    }
                }
            }
            Criteria_third();
        }

        void Criteria_third()
        {
            Random_Move_V = false;
            Random random = new Random();
            while (!Random_Move_V)
            {
                int random_Y = random.Next(0, 8);
                int random_X = random.Next(0, 8);

                if (((Math.Abs(BlackKnight_Position_Y - random_Y) == 2 && Math.Abs(BlackKnight_Position_X - random_X) == 1) || (Math.Abs(BlackKnight_Position_Y - random_Y) == 1 && Math.Abs(BlackKnight_Position_X - random_X) == 2)) && ChessBoard[random_Y, random_X] >= 0)
                {
                    ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] = 0;
                    BlackKnight_Position_Y = random_Y;
                    BlackKnight_Position_X = random_X;
                    ChessBoard[BlackKnight_Position_Y, BlackKnight_Position_X] -= 30;
                    MyBnFigure.Margin = new Thickness(random_X * 50, random_Y * 50, 0, 0);
                    Random_Move_V = true;
                    Utel(ChessBoard, BlackKnight_Position_Y, BlackKnight_Position_X);
                    return;
                }
                else if (Math.Abs(BlackBishop_Position_Y - random_Y) == Math.Abs(BlackBishop_Position_X - random_X) && ChessBoard[random_Y, random_X] >= 0)
                {
                    Bishop_V_third = false;
                    for (int l = 1; l < Math.Abs(random_Y - BlackBishop_Position_Y); l++)
                    {
                        if (random_Y > BlackBishop_Position_Y && random_X < BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y + l, BlackBishop_Position_X - l] != 0)
                        {
                            Bishop_V_third = true;
                            break;
                        }
                        if (random_Y > BlackBishop_Position_Y && random_X > BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y + l, BlackBishop_Position_X + l] != 0)
                        {
                            Bishop_V_third = true;
                            break;
                        }
                        if (random_Y < BlackBishop_Position_Y && random_X < BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y - l, BlackBishop_Position_X - l] != 0)
                        {
                            Bishop_V_third = true;
                            break;
                        }
                        if (random_Y < BlackBishop_Position_Y && random_X > BlackBishop_Position_X && ChessBoard[BlackBishop_Position_Y - l, BlackBishop_Position_X + l] != 0)
                        {
                            Bishop_V_third = true;
                            break;
                        }
                    }
                    if (!Bishop_V_third)
                    {
                        ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] = 0;
                        BlackBishop_Position_Y = random_Y;
                        BlackBishop_Position_X = random_X;
                        ChessBoard[BlackBishop_Position_Y, BlackBishop_Position_X] -= 33;
                        MyWbFigure.Margin = new Thickness(random_X * 50, random_Y * 50, 0, 0);
                        Random_Move_V = true;
                        Utel(ChessBoard, BlackBishop_Position_Y, BlackBishop_Position_X);
                        return;
                    }
                }
                else if ((random_X == BlackRook_Position_X || random_Y == BlackRook_Position_Y) && ChessBoard[random_Y, random_X] >= 0)
                {
                    Rook_V_third = false;
                    if (random_X == BlackRook_Position_X)
                    {
                        for (int l = 1; l < Math.Abs(random_Y - BlackRook_Position_Y); l++)
                        {
                            if (random_Y > BlackRook_Position_Y && ChessBoard[BlackRook_Position_Y + l, random_X] != 0)
                            {
                                Rook_V_third = true;
                                break;
                            }
                            if (random_Y < BlackRook_Position_Y && ChessBoard[BlackRook_Position_Y - l, random_X] != 0)
                            {
                                Rook_V_third = true;
                                break;
                            }
                        }
                    }
                    else
                    {
                        for (int l = 1; l < Math.Abs(random_X - BlackRook_Position_X); l++)
                        {
                            if (random_X > BlackRook_Position_X && ChessBoard[random_Y, BlackRook_Position_X + l] != 0)
                            {
                                Rook_V_third = true;
                                break;
                            }
                            if (random_X < BlackRook_Position_X && ChessBoard[random_Y, BlackRook_Position_X - l] != 0)
                            {
                                Rook_V_third = true;
                                break;
                            }
                        }
                    }
                    if (!Rook_V_third)
                    {
                        ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] = 0;
                        BlackRook_Position_Y = random_Y;
                        BlackRook_Position_X = random_X;
                        ChessBoard[BlackRook_Position_Y, BlackRook_Position_X] -= 50;
                        BlackRook.Margin = new Thickness(random_X * 50, random_Y * 50, 0, 0);
                        Random_Move_V = true;
                        Utel(ChessBoard, BlackRook_Position_Y, BlackRook_Position_X);
                        return;
                    }
                }
                
            }
        }
    }
}
