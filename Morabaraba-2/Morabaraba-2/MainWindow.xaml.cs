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
        List<string> neighbours = new List<string>();
        string tmpPos = "";
        bool tmpFlag = false;  //controls the flow of the game
        int k = 0, z = 0;
        int t = 0;
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
        public void clearBoard()
        {
            List<string> positions = world.board.getPositions().ToList();
            for (int i = 0; i < positions.Count; i++)
            {
                updateBoardBlank(positions[i]);
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
        public void playMills()
        {
            world.isMill();
            if (world.mill)
            {
                flag = true;
                MessageBox.Show("Which enemy would you like to eliminate");
                return;
            }
            return;

        }
        public void helperCheck1()
        {
            if (world.board.getTile(move).cond != "blank")
            {
                MessageBox.Show("You can't play there, that's an invalid move");
                return;
            }
            world.Play(move, world.getPlayer(tmpPlayer));
            //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
            if (world.getPlayer(world.currentPlayer).LastPosPlayed.Contains(move))
                world.getPlayer(world.currentPlayer).LastPosPlayed.Remove(move);

            world.getPlayer(world.currentPlayer).LastPosPlayed.Add(move);
            world.getPlayer(world.currentPlayer).CowLives--;
            updateBoardWhite(move, tmpPlayer);
            playMills();
            world.currentPlayer = "CB";

        }
        public void restartGame()
        {

        }
        public void helperCheck2()
        {
            if (world.board.getTile(move).cond != "blank" && !shift)
            {
                MessageBox.Show("You can't play there, that's an invalid move");
                return;
            }
            world.Play(move, world.getPlayer(world.currentPlayer));

            //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
            if (world.getPlayer(world.currentPlayer).LastPosPlayed.Contains(move))
                world.getPlayer(world.currentPlayer).LastPosPlayed.Remove(move);

            world.getPlayer(world.currentPlayer).LastPosPlayed.Add(move);
            world.getPlayer(world.currentPlayer).CowLives--;

            updateBoardBlack(move, world.currentPlayer);
            playMills();

            world.currentPlayer = "CW";
        }
        private void updateGame(string pos)
        {
            //If you're in the shifting/flying phase don't make use of this method
            if (shift) return;

            hit = pos;

            if (world.mill)
            {
                // player.SetEnemyPos(hit);
                string enemy = world.board.getTile(hit).cond;
                if (enemy == "blank")
                {
                    MessageBox.Show("You can't destroy a blank spot");
                    return;
                }

                if (enemy != world.currentPlayer && enemy != "blank")
                {
                    MessageBox.Show("You can't destroy your own player!!!");
                    MessageBox.Show("Please choose an enemy piece!");
                    return;
                }
                //Naming of this wasn't great, it basically checks whether there is still pieces that's not in a mill
                if (!world.isNotAvailablePieces(world.getPlayer(enemy)))
                {

                    if (world.isInMillPos(hit, world.getPlayer(enemy)))
                    {
                        MessageBox.Show("You can't shoot a piece in a mill.\n There are still available pieces to shoot");
                        return;
                    }
                    //If there's only pieces in mills, then you can shoot those pieces, and it would fall through this clause
                }

                world.mill = false;
                world.RemovePiece(hit);
                //Check to see if a mill has been broken, to recheck
                world.RemoveBrokenMill(hit, world.getPlayer(world.currentPlayer));
                updateBoardBlank(hit);
                UpdateGUI();
                return;
            }
            if (!world.mill)
            {
                move = pos;
                startPlaying();

                UpdateGUI();
            }

        }
        private void updateGameMove(string pos) //This is anothe method that's a backbone of the game. It validates co-ordinates and implements shooting
        {
            //If you're in the shifting/flying phase don't make use of this method
            if (shift) return;

            hit = pos;

            if (world.mill)
            {
                // player.SetEnemyPos(hit);
                string enemy = world.board.getTile(hit).cond;
                if (enemy == "blank")
                {
                    MessageBox.Show("You can't destroy a blank spot");
                    return;
                }

                if (enemy == world.currentPlayer && enemy != "blank")
                {
                    MessageBox.Show("You can't destroy your own player!!!");
                    MessageBox.Show("Please choose an enemy piece!");
                    //Something went wrong, redo by attempting again
                    flag = true;
                    return;
                }
                //Naming of this wasn't great, it basically checks whether there is still pieces that's not in a mill
                if (!world.isNotAvailablePieces(world.getPlayer(enemy)))
                {

                    if (world.isInMillPos(hit, world.getPlayer(enemy)))
                    {
                        MessageBox.Show("You can't shoot a piece in a mill.\n There are still available pieces to shoot");
                        //Something went wrong, redo by attempting to shoot another piece
                        flag = true;
                        return;
                    }
                    //If there's only pieces in mills, then you can shoot those pieces, and it would fall through this clause
                }

                world.mill = false;
                world.RemovePiece(hit);
                //Check to see if a mill has been broken, to recheck
                world.RemoveBrokenMill(hit, world.getPlayer(world.currentPlayer));
                updateBoardBlank(hit);
                switchFlag = false;
                world.switchPlayer();
                UpdateGUI();
                flag = false;
                return;
            }
            if (!world.mill)
            {
                move = pos;
                startPlaying();

                UpdateGUI();
            }

        }
        private void a1_MouseDown(object sender, MouseButtonEventArgs e)
        {


            startShifting("a1");
            updateGame("a1");
            //MessageBox.Show("a1"); //remove
        }

        public void ControlMills()
        {
            if (world.mill)
            {
                tmpFlag = true;
                if (tmpFlag)
                {
                    MessageBox.Show("Which enemy would you like to destroy");
                    shift = true;
                    return;
                }

            }
            world.switchPlayer();
            UpdateGUI();
            t++;
            switchFlag = false;
        }

        public void RunMoving()
        {
            //Go through neighbour cells to see if there's an available position  
            if (neighbours.Contains(moveTo))
            {

                for (int i = 0; i < neighbours.Count; i++)
                {
                    Tile tl = world.board.getTile(neighbours[i]);
                    Tile two = world.board.getTile(tmpPos);
                    if (two.cond == "Blank")
                    {
                        MessageBox.Show("You can't move an empty piece");
                        flag = true;
                        return;
                    }
                    if (two.cond != world.currentPlayer)
                    {
                        MessageBox.Show("You can't move your oponents piece\nPlease move your own piece!");
                        flag = true;
                        return;
                    }

                    if (tl.cond == "blank" && moveTo == neighbours[i] && two.cond != "blank")
                    {


                        //Remove the old piece from the board
                        world.RemovePiece(tmpPos);
                        //Remove the broken mill of the old piece
                        world.RemoveBrokenMill(tmpPos, world.getPlayer(world.currentPlayer));
                        //Update board
                        updateBoardBlank(tmpPos);
                        if (world.currentPlayer == "CW")
                        {
                            updateBoardWhite(moveTo, "CW");
                            //UpdateGUI();
                        }
                        else
                        {
                            updateBoardBlack(moveTo, "CB");
                            //UpdateGUI();
                        }
                        world.addPiece(moveTo, world.getPlayer(world.currentPlayer));
                        //if the last piece was destroyed, and a player plays the same pos, remove that pos from last 
                        if (world.getPlayer(world.currentPlayer).LastPosPlayed.Contains(moveTo))
                            world.getPlayer(world.currentPlayer).LastPosPlayed.Remove(moveTo);
                        //Add the new position to player
                        world.getPlayer(world.currentPlayer).LastPosPlayed.Add(moveTo);
                        //Check if a new mill has been formed.
                        world.isMill();

                        ControlMills();
                        return;
                    }
                }

            }
            else
            {
                int indx = world.getPlayer(world.currentPlayer).LastPosPlayed.Count - 1;
                MessageBox.Show(string.Format("To which adjacent, free space would you like to move {0} ? ", world.getPlayer(world.currentPlayer).LastPosPlayed[indx]));

                return;
            }
        }

        //This code runs the game, and calls various methods to make the game run
        public void startPlaying()
        {
            // Flying and moving should be implemented in this method.
            if (move.Length == 0)
            {
                MessageBox.Show("Please select where you'd like to play");
                //continue;
            }
            //Placing phase only lasts while both players has a cow to place, the we move on to shifting/moving then flying
            if (world.player1.CowLives > 0 || world.player2.CowLives > 0 || t > 1)
            {
                // if (world.player1.CowLives == 0 && world.player2.CowLives == 0)
                if (world.currentPlayer == "CW")
                {
                    helperCheck1();
                }
                else
                {
                    helperCheck2();

                }
            }

            string board = world.board.ToString();

        }
      
        public void startShifting(string pos)
        {

        }
        //private void a1_MouseDown(object sender, MouseButtonEventArgs e)
        //{


        //    startShifting("a1");
        //    updateGame("a1");
        //    //MessageBox.Show("a1"); //remove
        //}

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
