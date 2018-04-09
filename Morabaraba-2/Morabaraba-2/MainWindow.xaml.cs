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

namespace Morabaraba_2
{
    /// <summary> //git
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {




        //global variables 
        public int p1Cows = 12; //initial number of cows for each player 
        public int p2Cows = 12;
        string tmpPlayer = "CW";
        string moveTo = "";
        bool flag = false;
        bool shift = false;
        bool fly = false;
        int draw = 0;
        bool switchFlag = false;
        World world = new World(new Player("CW"), new Player("CB"));
        SolidColorBrush cowcolor = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        //Each of the characterd represent a space on the game board, and will turn Yellow or Blue depending on the player value
        //char A1, A4, A7, B2, B4, B6, C3, C4, C5, D1, D2, D3, D5, D6, D7, E3, E4, E5, F2, F4, F6, G1, G4, G7 = 'B';
        //char playerY = 'Y';
        //char playerB = 'B';
        string move = "";
        string hit = "";
        // Fix re-forming of mills 
        public MainWindow()
        {
            InitializeComponent();
            //get input from user 
            ///Placing
            ///
            world.currentPlayer = tmpPlayer;
            UpdateGUI();
            MessageBox.Show("Player 1: Blue\nPlayer 2: Yellow");


        }
        public void UpdateGUI()
        {
            if (world.currentPlayer == "CW")
            {
                player1_Box.Content = "";
                player2_Box.Content = "Blue Playing";
                ScoreP1_Box.Content = Convert.ToString(world.getPlayer("CW").CowLives);
                ScoreP2_Box.Content = Convert.ToString(world.getPlayer("CB").CowLives);
            }
            else
            {
                player2_Box.Content = "";
                player1_Box.Content = "Yellow Playing";
                ScoreP1_Box.Content = Convert.ToString(world.getPlayer("CW").CowLives);
                ScoreP2_Box.Content = Convert.ToString(world.getPlayer("CB").CowLives);
            }
        }

        // Red = CW
        // Blue = CB
        // Black = Blank
        public Brush colour(string player)
        {
            switch (player)
            {
                case "CW": return Brushes.Blue;
                case "CB": return Brushes.Yellow;
            }
            return Brushes.Black;
        }
        /// <summary>
        /// Method makes the colouring effects on the gui
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="player"></param>
        public void updateBoardBlack(string pos, string player)
        {
            if (player == "CB")
            {

                switch (pos)
                {
                    case "a1":
                        a1.Stroke = colour(player);
                        a1.StrokeThickness = 5;
                        break;
                    case "a4":
                        a4.Stroke = colour(player);
                        a4.StrokeThickness = 5;
                        break;
                    case "a7":
                        a7.Stroke = colour(player);
                        a7.StrokeThickness = 5;
                        break;
                    case "b2":
                        b2.Stroke = colour(player);
                        b2.StrokeThickness = 5;
                        break;
                    case "b4":
                        b4.Stroke = colour(player);
                        b4.StrokeThickness = 5;
                        break;
                    case "b6":
                        b6.Stroke = colour(player);
                        b6.StrokeThickness = 5;
                        break;
                    case "c3":
                        c3.Stroke = colour(player);
                        c3.StrokeThickness = 5;
                        break;
                    case "c4":
                        c4.Stroke = colour(player);
                        c4.StrokeThickness = 5;
                        break;
                    case "c5":
                        c5.Stroke = colour(player);
                        c5.StrokeThickness = 5;
                        break;
                    case "d1":
                        d1.Stroke = colour(player);
                        d1.StrokeThickness = 5;
                        break;
                    case "d2":
                        d2.Stroke = colour(player);
                        d2.StrokeThickness = 5;
                        break;
                    case "d3":
                        d3.Stroke = colour(player);
                        d3.StrokeThickness = 5;
                        break;
                    case "d5":
                        d5.Stroke = colour(player);
                        d5.StrokeThickness = 5;
                        break;
                    case "d6":
                        d6.Stroke = colour(player);
                        d6.StrokeThickness = 5;
                        break;
                    case "d7":
                        d7.Stroke = colour(player);
                        d7.StrokeThickness = 5;
                        break;
                    case "e3":
                        e3.Stroke = colour(player);
                        e3.StrokeThickness = 5;
                        break;
                    case "e4":
                        e4.Stroke = colour(player);
                        e4.StrokeThickness = 5;
                        break;
                    case "e5":
                        e5.Stroke = colour(player);
                        e5.StrokeThickness = 5;
                        break;
                    case "f2":
                        f2.Stroke = colour(player);
                        f2.StrokeThickness = 5;
                        break;
                    case "f4":
                        f4.Stroke = colour(player);
                        f4.StrokeThickness = 5;
                        break;
                    case "f6":
                        f6.Stroke = colour(player);
                        f6.StrokeThickness = 5;
                        break;
                    case "g1":
                        g1.Stroke = colour(player);
                        g1.StrokeThickness = 5;
                        break;
                    case "g4":
                        g4.Stroke = colour(player);
                        g4.StrokeThickness = 5;
                        break;
                    case "g7":
                        g7.Stroke = colour(player);
                        g7.StrokeThickness = 5;
                        break;
                }
            }

        }
        /// <summary>
        /// Method makes the colouring effects on the gui
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="player"></param>
        public void updateBoardWhite(string pos, string player)
        {

            if (player == "CW")
            {

                switch (pos)
                {
                    case "a1":
                        a1.Stroke = colour(player);
                        a1.StrokeThickness = 5;
                        break;
                    case "a4":
                        a4.Stroke = colour(player);
                        a4.StrokeThickness = 5;
                        break;
                    case "a7":
                        a7.Stroke = colour(player);
                        a7.StrokeThickness = 5;
                        break;
                    case "b2":
                        b2.Stroke = colour(player);
                        b2.StrokeThickness = 5;
                        break;
                    case "b4":
                        b4.Stroke = colour(player);
                        b4.StrokeThickness = 5;
                        break;
                    case "b6":
                        b6.Stroke = colour(player);
                        b6.StrokeThickness = 5;
                        break;
                    case "c3":
                        c3.Stroke = colour(player);
                        c3.StrokeThickness = 5;
                        break;
                    case "c4":
                        c4.Stroke = colour(player);
                        c4.StrokeThickness = 5;
                        break;
                    case "c5":
                        c5.Stroke = colour(player);
                        c5.StrokeThickness = 5;
                        break;
                    case "d1":
                        d1.Stroke = colour(player);
                        d1.StrokeThickness = 5;
                        break;
                    case "d2":
                        d2.Stroke = colour(player);
                        d2.StrokeThickness = 5;
                        break;
                    case "d3":
                        d3.Stroke = colour(player);
                        d3.StrokeThickness = 5;
                        break;
                    case "d5":
                        d5.Stroke = colour(player);
                        d5.StrokeThickness = 5;
                        break;
                    case "d6":
                        d6.Stroke = colour(player);
                        d6.StrokeThickness = 5;
                        break;
                    case "d7":
                        d7.Stroke = colour(player);
                        d7.StrokeThickness = 5;
                        break;
                    case "e3":
                        e3.Stroke = colour(player);
                        e3.StrokeThickness = 5;
                        break;
                    case "e4":
                        e4.Stroke = colour(player);
                        e4.StrokeThickness = 5;
                        break;
                    case "e5":
                        e5.Stroke = colour(player);
                        e5.StrokeThickness = 5;
                        break;
                    case "f2":
                        f2.Stroke = colour(player);
                        f2.StrokeThickness = 5;
                        break;
                    case "f4":
                        f4.Stroke = colour(player);
                        f4.StrokeThickness = 5;
                        break;
                    case "f6":
                        f6.Stroke = colour(player);
                        f6.StrokeThickness = 5;
                        break;
                    case "g1":
                        g1.Stroke = colour(player);
                        g1.StrokeThickness = 5;
                        break;
                    case "g4":
                        g4.Stroke = colour(player);
                        g4.StrokeThickness = 5;
                        break;
                    case "g7":
                        g7.Stroke = colour(player);
                        g7.StrokeThickness = 5;
                        break;
                }



            }

        }
        /// <summary>
        /// Method makes the colouring effects on the gui
        /// </summary>
        /// <param name="pos"></param>
        public void updateBoardBlank(string pos)
        {
            string player = "blank";
            switch (pos)
            {
                case "a1":
                    a1.Stroke = colour(player);
                    a1.StrokeThickness = 3;
                    break;
                case "a4":
                    a4.Stroke = colour(player);
                    a4.StrokeThickness = 3;
                    break;
                case "a7":
                    a7.Stroke = colour(player);
                    a7.StrokeThickness = 3;
                    break;
                case "b2":
                    b2.Stroke = colour(player);
                    b2.StrokeThickness = 3;
                    break;
                case "b4":
                    b4.Stroke = colour(player);
                    b4.StrokeThickness = 3;
                    break;
                case "b6":
                    b6.Stroke = colour(player);
                    b6.StrokeThickness = 3;
                    break;
                case "c3":
                    c3.Stroke = colour(player);
                    c3.StrokeThickness = 3;
                    break;
                case "c4":
                    c4.Stroke = colour(player);
                    c4.StrokeThickness = 3;
                    break;
                case "c5":
                    c5.Stroke = colour(player);
                    c5.StrokeThickness = 3;
                    break;
                case "d1":
                    d1.Stroke = colour(player);
                    d1.StrokeThickness = 3;
                    break;
                case "d2":
                    d2.Stroke = colour(player);
                    d2.StrokeThickness = 3;
                    break;
                case "d3":
                    d3.Stroke = colour(player);
                    d3.StrokeThickness = 3;
                    break;
                case "d5":
                    d5.Stroke = colour(player);
                    d5.StrokeThickness = 3;
                    break;
                case "d6":
                    d6.Stroke = colour(player);
                    d6.StrokeThickness = 3;
                    break;
                case "d7":
                    d7.Stroke = colour(player);
                    d7.StrokeThickness = 3;
                    break;
                case "e3":
                    e3.Stroke = colour(player);
                    e3.StrokeThickness = 3;
                    break;
                case "e4":
                    e4.Stroke = colour(player);
                    e4.StrokeThickness = 3;
                    break;
                case "e5":
                    e5.Stroke = colour(player);
                    e5.StrokeThickness = 3;
                    break;
                case "f2":
                    f2.Stroke = colour(player);
                    f2.StrokeThickness = 3;
                    break;
                case "f4":
                    f4.Stroke = colour(player);
                    f4.StrokeThickness = 3;
                    break;
                case "f6":
                    f6.Stroke = colour(player);
                    f6.StrokeThickness = 3;
                    break;
                case "g1":
                    g1.Stroke = colour(player);
                    g1.StrokeThickness = 3;
                    break;
                case "g4":
                    g4.Stroke = colour(player);
                    g4.StrokeThickness = 3;
                    break;
                case "g7":
                    g7.Stroke = colour(player);
                    g7.StrokeThickness = 3;
                    break;
            }





        }

        private void a1_MouseDown(object sender, MouseButtonEventArgs e)
        {


            startShifting("a1");
            updateGame("a1");
            //MessageBox.Show("a1"); //remove
        }

        private void a4_MouseDown(object sender, MouseButtonEventArgs e)
        {

            startShifting("a4");
            updateGame("a4");
        }

        private void a7_MouseDown(object sender, MouseButtonEventArgs e)
        {

            startShifting("a7");
            updateGame("a7");
        }

        private void b2_MouseDown(object sender, MouseButtonEventArgs e)
        {

            startShifting("b2");
            updateGame("b2");

        }

        private void b4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("b4");
            updateGame("b4");
        }

        private void b6_MouseDown(object sender, MouseButtonEventArgs e)
        {

            startShifting("b6");
            updateGame("b6");
        }

        private void c3_MouseDown(object sender, MouseButtonEventArgs e)
        {

            startShifting("c3");
            updateGame("c3");
        }

        private void c4_MouseDown(object sender, MouseButtonEventArgs e)
        {

            startShifting("c4");
            updateGame("c4");
        }

        private void c5_MouseDown(object sender, MouseButtonEventArgs e)
        {

            startShifting("c5");
            updateGame("c5");
        }

        private void d1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("d1");
            updateGame("d1");
        }

        private void d2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("d2");
            updateGame("d2");
        }

        private void d3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("d3");
            updateGame("d3");
        }

        private void d5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("d5");
            updateGame("d5");
        }

        private void d6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("d6");
            updateGame("d6");

        }

        private void d7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("d7");
            updateGame("d7");
        }

        private void e3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("e3");
            updateGame("e3");
        }

        private void e4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("e4");
            updateGame("e4");
        }

        private void e5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("e5");
            updateGame("e5");
        }

        private void f2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("f2");
            updateGame("f2");

        }


        private void f4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("f4");
            updateGame("f4");
        }

        private void f6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("f6");
            updateGame("f6");
        }

        private void g1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("g1");
            updateGame("g1");
        }

        private void g4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("g4");
            updateGame("g4");
        }

        private void g7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            startShifting("g7");
            updateGame("g7");
        }
    }
}
