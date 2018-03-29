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
        public int blueCows = 5; //initial number of cows for each player 
        public int yellowCows = 5;
        List<string> blueplayer = new List<string> { };// list of where blue cows are
        List<string> yellowplayer = new List<string> { };// list of where yellow cows a
        List<string> allcowpos = new List<string> { };
        string tmpPlayer = "CW";
        bool flag = false;
        Player player; //= new Player(p1Cows, p2Cows);
        string move = "";
        string movefrom = "";
        string hit = "";
        int barHeightY, barHeightB;
        bool flagMove = false; 
        public MainWindow()
        {
            InitializeComponent();
            //get input from user 
            ///Placing
            ///
            outL.Content = getP(tmpPlayer) + " Place your cow!";
            barHeightB = 120;
            barHeightY = 120;
            player = new Player(blueCows, yellowCows);
            MessageBox.Show("Player 1: Blue\nPlayer 2: Yellow");
           // startPlaying();
        }
       
        public bool isvalidcowtomove(string pos, string player)// checks if player is trying to move their own cow
        {
            if (player == "CW")
            {
                return blueplayer.Contains(pos); //checks if cow belongs to player
            }
            if (player == "CB")
            {
                return yellowplayer.Contains(pos); //checks if cow belongs to player
            }
            return false;
        }
        
        public bool isvalidposition(string pos, string player)//return true or false if the possition has been played before
        {
            if (player == "CW")
            {
                return allcowpos.Contains(pos); //checks if possition is occupied
            }
            if (player == "CB")
            {
                return allcowpos.Contains(pos); //checks if possition is occupied
            }
            return false;
        }
        public Brush colour(string player)
        {
            switch (player)
            {
                case "CW": return Brushes.Blue;
                case "CB": return Brushes.Yellow;
            }
            return Brushes.Black;
        }
        public void updateBoardBlack(string pos, string player)
        {
            if (isvalidposition(pos, player) == false)
            {
                yellowplayer.Add(pos); //add pos to the list of possition played by yellowplayer
                allcowpos.Add(pos);    //add pos to the list of played possitions by both players
                yellowCows--;          //decrease yellow cows at hand after plasing
                if (!flagMove) { barHeightY = (barHeightY - 10); borderY.Height = barHeightY; }
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
                    tmpPlayer = "CW";
                }
            
                }
            else
            {
                if (blueCows == 0 || yellowCows == 0) //checks if player is in moving stage and allows them click their own cow
                {
                    return;
                }
                else
                {
                    MessageBox.Show("cannot place at played possition"); //if player is not in moving stage, show massage box
                }

                tmpPlayer = "CB";//gives player another attempts after invalid position to place
                
            }
        }



        public void updateBoardWhite(string pos, string player)
        {
            if (isvalidposition(pos, player) == false)
            {
                blueplayer.Add(pos); //add played pos to the list of all possisioned played by blueplayer
                allcowpos.Add(pos);//add played pos to the list of all played possition
                blueCows--; //decrease blue cows at hand after placing
                if (!flagMove) { barHeightB = (barHeightB - 10); borderB.Height = barHeightB; }
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


                    tmpPlayer = "CB";
                }

            }
            else
            {
                if(blueCows == 0 || yellowCows == 0)// checks if player is in moving stage and allows them to click ther cow
                {
                   return ;
                }
                else
                {
                    MessageBox.Show("cannot place at played possition");// if player is not in moving stage message box pops up
                }
                tmpPlayer = "CW"; // allows player to attempt again after entering invalid possition
            }
        }

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

        public bool validNeighbour(string from, string to)
        {
            switch (from)
            {
                case "a1":
                    if (to == "d1" || to == "b2" || to == "a4") { return true; } else { return false; }
                case "a4":
                    if (to == "a1" || to == "b4" || to == "a7") { return true; } else { return false; }
                case "a7":
                    if (to == "a4" || to == "b6" || to == "d7") { return true; } else { return false; }
                case "b2":
                    if (to == "a1" || to == "d2" || to == "c3" || to == "b4") { return true; } else { return false; }
                case "b4":
                    if (to == "b2" || to == "a4" || to == "b6" || to == "c4") { return true; } else { return false; }
                case "b6":
                    if (to == "b4" || to == "a7" || to == "c5" || to == "d6") { return true; } else { return false; }
                case "c3":
                    if (to == "b2" || to == "d3" || to == "c4") { return true; } else { return false; }
                case "c4":
                    if (to == "c3" || to == "b4" || to == "c5") { return true; } else { return false; }
                case "c5":
                    if (to == "c4" || to == "b6" || to == "d5") { return true; } else { return false; }
                case "d1":
                    if (to == "a1" || to == "d2" || to == "g1") { return true; } else { return false; }
                case "d2":
                    if (to == "d1" || to == "b2" || to == "f2" || to == "d3") { return true; } else { return false; }
                case "d3":
                    if (to == "d2" || to == "c3" || to == "e3") { return true; } else { return false; }
                case "d5":
                    if (to == "c5" || to == "e5" || to == "d6") { return true; } else { return false; }
                case "d6":
                    if (to == "d5" || to == "b6" || to == "f6" || to == "d7") { return true; } else { return false; }
                case "d7":
                    if (to == "a7" || to == "d6" || to == "g7") { return true; } else { return false; }
                case "e3":
                    if (to == "d3" || to == "f2" || to == "e4") { return true; } else { return false; }
                case "e4":
                    if (to == "e3" || to == "e5" || to == "f4") { return true; } else { return false; }
                case "e5":
                    if (to == "e4" || to == "d5" || to == "f6") { return true; } else { return false; }
                case "f2":
                    if (to == "g1" || to == "e3" || to == "d2" || to == "f4") { return true; } else { return false; }
                case "f4":
                    if (to == "e4" || to == "g4" || to == "f2" || to == "f4") { return true; } else { return false; }
                case "f6":
                    if (to == "f4" || to == "d6" || to == "e5" || to == "g7") { return true; } else { return false; }
                case "g1":
                    if (to == "d1" || to == "f2" || to == "g4") { return true; } else { return false; }
                case "g4":
                    if (to == "g1" || to == "g7" || to == "f4") { return true; } else { return false; }
                case "g7":
                    if (to == "g4" || to == "f6" || to == "d7") { return true; } else { return false; }
            }
            return false;
        }
        public void movecows(string from, string player)
        {
            if (isvalidcowtomove(from, player) == true)
            {
                string to = from;
                movefrom = from;
                updateBoardBlank(from); // selected cow to be moved back to blank
                if (player == "CB")
                {
                    // MessageBox.Show("Here");
                    yellowCows++; //gives yellow player a cow to place anywhere
                    startPlayingMove();
                    updateBoardBlack(to, player);

                    allcowpos.Remove(from); //removes cow all from played possition list
                    yellowplayer.Remove(from); //removes cow from yellowplayes list
                    //startPlayingMove();
                }
                if (player == "CW")
                {
                    // MessageBox.Show("Here");
                    blueCows++; //gives blue player a cow to place anywhere
                    startPlayingMove();
                    updateBoardWhite(to, player);

                    allcowpos.Remove(from); //removes cow all from played possition list
                    blueplayer.Remove(from); //removes cow from yellowplayes list
                    //startPlayingMove();
                }
            }
        }
        //Complete this to allow mills to work, by updating the player position
        /*     public void playMills()
             {
                 //Once you found a mill, return from this method.
                 string[] list1 = player.board.getMillP1();
                 string[] list2 = player.board.getMillP2();
                 bool contained = false;
                 for (int i = 0; i < list1.Length; i++)
                 {
                     flag = player.isMill1(list1[i]);

                     //Mill shouldn't already be contained 
                     string[] mil = player.board.checkMills1(list1[i]);
                     contained = player.isContainedInMills(mil);
                     if (flag && !contained)
                     {
                         MessageBox.Show("Which enemy would you like to eliminate");
                         return;
                         //player.SetEnemyPos(hit);
                         //player.accountForMill1();
                     }
                 }
                 for (int i = 0; i < list2.Length; i++)
                 {
                     flag = player.isMill2(list2[i]);
                     //Mill shouldn't already be contained 
                     string[] mil = player.board.checkMills2(list2[i]);
                     contained = player.isContainedInMills(mil);
                     if (flag && !contained)
                     {
                         MessageBox.Show("Which enemy would you like to eliminate");
                         return;
                         //player.SetEnemyPos(hit);
                         //player.accountForMill2();
                     }
                 }
             }*/
        //Clean up this code
        public void startPlayingMove()
        {

            if (blueCows > 0 || yellowCows > 0) //==1
            {
                if (tmpPlayer == "CW" && flagMove)
                {

                    if (validNeighbour(movefrom, move))
                    {
                        player.Play(move, tmpPlayer);

                        updateBoardWhite(move, tmpPlayer); //place

                    }
                }
                if (tmpPlayer == "CB" && flagMove)
                {
                    if (validNeighbour(movefrom, move))
                    {
                        player.Play(move, tmpPlayer);

                        updateBoardBlack(move, tmpPlayer);
                    }

                }
                //string board = player.board.ToString();
            }
            if (blueCows <= 0 && yellowCows <= 0)
            {
                flagMove = true;
                movecows(move, tmpPlayer);
            }
        }

        public void startPlaying()
        {

            if (blueCows > 0 || yellowCows > 0)
            {
                if (move.Length == 0)
                {
                    MessageBox.Show("Please select where you'd like to play");
                    //continue;
                }
                if (tmpPlayer == "CW")
                {
                    player.Play(move, tmpPlayer);
                    updateBoardWhite(move, tmpPlayer);
                    // tmpPlayer = "CB";
                }
                else
                {
                    player.Play(move, tmpPlayer);
                    //player.accountForMill2();
                    updateBoardBlack(move, tmpPlayer);
                    //tmpPlayer = "CW";
                }
                string board = player.board.ToString();
            }
            if(blueCows <= 0 && yellowCows <= 0)
            {
                flagMove = true;
                outL.Content = getP(tmpPlayer) + " move your cow to neighbouring position";
                movecows(move,  tmpPlayer);

            }
        }
        private void a1_Click(object sender, RoutedEventArgs e)
        {
           // MessageBox.Show("jdjd"); //remove
        }
        private void activeAttack()
        {
            player.accountForMill1();
            player.accountForMill2();
        }
        private void updateGame(string pos)
        {
            hit = pos;
            if (flag)
            {
                player.SetEnemyPos(hit);
                string enemy = player.getEnemyPlayer(hit);
                if ( enemy != tmpPlayer && enemy != "blank")
                {
                    MessageBox.Show("You can't destroy your own player!!!");
                    MessageBox.Show("Please choose an enemy piece!");
                    return;
                }
                activeAttack();
                flag = false;
                updateBoardBlank(hit);
                return;
            }
         //   playMills();

            if (!flag)
            {
                move = pos;
                if (!flagMove) { startPlaying(); } else if (flagMove) { startPlayingMove(); }
                //  playMills();
            }
        } //updateGame ends 

        private string invertP(string p)
        {
            if (p == "CW") return "Yellow Player";
            else if (p == "CB") return "Blue Player";
            else return "";

        }

        private string getP(string p)
        {
            if (p == "CB") return "Yellow Player";
            else if (p == "CW") return "Blue Player";
            else return "";

        }

        private void a1_MouseDown(object sender, MouseButtonEventArgs e)
        {

            updateGame("a1");
            //MessageBox.Show("a1"); //remove
        }

        private void a4_MouseDown(object sender, MouseButtonEventArgs e)
        {

            updateGame("a4");
        }

        private void a7_MouseDown(object sender, MouseButtonEventArgs e)
        {

            updateGame("a7");
        }

        private void b2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("b2");
       
        }

        private void b4_MouseDown(object sender, MouseButtonEventArgs e)
        {

            updateGame("b4");
        }

        private void b6_MouseDown(object sender, MouseButtonEventArgs e)
        {

            updateGame("b6");
        }

        private void c3_MouseDown(object sender, MouseButtonEventArgs e)
        {

            updateGame("c3");
        }

        private void c4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("c4");
        }

        private void c5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("c5");
        }

        private void d1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("d1");
        }

        private void d2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("d2");
        }

        private void d3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("d3");
        }

        private void d5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("d5");
        }

        private void d6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("d6");

        }

        private void d7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("d7");
        }

        private void e3_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("e3");
        }

        private void e4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("e4");
        }

        private void e5_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("e5");
        }

        private void f2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("f2");

        }


        private void f4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("f4");
        }

        private void f6_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("f6");
        }

        private void g1_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("g1");
        }

        private void g4_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("g4");
        }

        private void g7_MouseDown(object sender, MouseButtonEventArgs e)
        {
            updateGame("g7");
        }
    }
}
