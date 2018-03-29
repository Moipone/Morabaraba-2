﻿using System;
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
        SolidColorBrush cowcolor = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        //Each of the characterd represent a space on the game board, and will turn Yellow or Blue depending on the player value
        char A1, A4, A7, B2, B4, B6, C3, C4, C5, D1, D2, D3, D5, D6, D7, E3, E4, E5, F2, F4, F6, G1, G4, G7 = 'B';
        char playerY = 'Y';
        char playerB = 'B';
        string move = "";
        string movefrom = "";
        string hit = "";
        public MainWindow()
        {
            InitializeComponent();
            //get input from user 
            ///Placing
            ///
            player = new Player(blueCows, yellowCows);
            MessageBox.Show("Player 1: Red\nPlayer 2: Blue");
            string placemsg = "Where would you like to place your cow?";
            string placeerror = "Invalid selection, please click on empty space";

            ///Moving
            string movemsg1 = "Which cow would you like to move?";
            string movemsg2 = "Where would you like to place your cow?";
            string moveerror1 = "Invalid selection, please choose own cow";
            string moveerror2 = "Invalid selection, please click on empty space";
            //MessageBox.Show("jdjd"); //remove 

            ///flying
            string flymsg1 = "Which cow would you like to fly?";
            string flysg2 = "Where would you like to land your cow?";
            string flyerror1 = "Invalid selection, please choose own cow";
            string flyerror2 = "Invalid selection, please click on empty space";

           // startPlaying();
        }
        // Red = CW
        // Blue = CB
        // Black = Blank
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
        public void movecows(string from, string player)
        {
            if (isvalidcowtomove(from, player) == true)
            {
                string to = from;
                updateBoardBlank(from); // selected cow to be moved back to blank
                //allcowpos.Remove(from); //removes cow all from played possition list
                if (player == "CB")
                {
                    yellowCows++; //gives yellow player a cow to place anywhere
                    startPlaying();
                    updateBoardBlack(to, player);
                    yellowplayer.Add(to); // adds new pos to yellow players list
                    allcowpos.Add(to);    //adds new pos to all played pos list
                    allcowpos.Remove(from); //removes cow all from played possition list
                    yellowplayer.Remove(from); //removes cow from yellowplayes list
                }
                if (player == "CW")
                {
                    blueCows++; //gives blue player a cow to place anywhere
                    startPlaying();
                    updateBoardWhite(to, player);
                    blueplayer.Add(to); // adds new pos to yellow players list
                    allcowpos.Add(to);    //adds new pos to all played pos list
                    allcowpos.Remove(from); //removes cow all from played possition list
                    blueplayer.Remove(from); //removes cow from yellowplayes list
                }
            }
            else
            {
               // MessageBox.Show("you can only move your own cow");
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
                
               // MessageBox.Show("time for moving");
               // player.Play(move, tmpPlayer);
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
                startPlaying();
              //  playMills();
            }
        } //updateGame ends 
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