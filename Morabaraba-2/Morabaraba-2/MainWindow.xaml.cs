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
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //global variables 
        int p1Cows = 12; //initial number of cows for each player 
        int p2Cows = 12;
        SolidColorBrush cowcolor = new SolidColorBrush(Color.FromRgb(0, 0, 0));
        //Each of the characterd represent a space on the game board, and will turn Yellow or Blue depending on the player value
        char A1, A4, A7, B2, B4, B6, C3, C4, C5, D1, D2, D3, D5, D6, D7, E3, E4, E5, F2, F4, F6, G1, G4, G7 = 'B';
        char playerY = 'Y';
        char playerB = 'B';

        public MainWindow()
        {
            InitializeComponent();
            //get input from user 
            ///Placing
            string placemsg = "Where would you like to place your cow?";
            string placeerror = "Invalid selection, please click on empty space";

            ///Moving
            string movemsg1 = "Which cow would you like to move?";
            string movemsg2 = "Where would you like to place your cow?";
            string moveerror1 = "Invalid selection, please choose own cow";
            string moveerror2 = "Invalid selection, please click on empty space";
            MessageBox.Show("jdjd"); //remove 

            ///flying
            string flymsg1 = "Which cow would you like to fly?";
            string flysg2 = "Where would you like to land your cow?";
            string flyerror1 = "Invalid selection, please choose own cow";
            string flyerror2 = "Invalid selection, please click on empty space";

        }

        private void a1_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("jdjd"); //remove
        }
    }
}
