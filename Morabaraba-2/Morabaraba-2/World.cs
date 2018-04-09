using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba_2
{
    class World
    {
        public string currentPlayer { get; set; }
        public Player player1;
        public Player player2;

        public Board board = new Board();
        public bool mill;       // Has a mill been formed, set this to true to shoot once, then set to false
        public bool draw;       // Has the game ended in a draw ???

        public World(Player one, Player two)
        {
            this.player1 = one;
            this.player2 = two;
            draw = false;

        }
        public Player getPlayer(string symbol)
        {
            if (symbol == "CW") return player1;

            return player2;
        }
        // Fix the broken mill
        // Fix the a
        // This method removes a piece, it was in a mill and was either shot or eliminated
        public void RemoveBrokenMill(string pos, Player player)
        {
            Tile t = board.getTile(pos);
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos) && t.cond == "blank")
                {
                    player.millsFormed.Remove(player.millsFormed[i]);

                }
            }

        }
        ///<summary> 
        ///Given a list of mills and a position, check if that position exists in that mill.
        /// </summary>
        //A Method to check if a piece is currently in a mill
        public bool isInMillPos(string pos, Player player)
        {
            for (int i = 0; i < player.millsFormed.Count; i++)
            {
                if (player.millsFormed[i].Contains(pos)) return true;
            }
            return false;
        }
        public List<string> getPlayerPieces(Player player)
        {
            List<string> positions = new List<string>();
            for (int i = 0; i < board.getBoard().Count; i++)
            {
                Tile t = board.getBoard()[i];
                if (t.cond == player.symbol) positions.Add(t.pos);

            }
            return positions;
        }
        //This method checks whether there's any pieces that's not in a mill
        public bool isNotAvailablePieces(Player player)
        {
            List<string> list = getPlayerPieces(player);
            bool isNotAvailable = false;
            foreach (string str in list)
            {
                isNotAvailable = isInMillPos(str, player);
                if (!isNotAvailable) return false;
            }
            return true;
        }
        public bool matchLists(List<string> list1, List<string> list2)
        {
            if (list1.Count != list2.Count) return false;
            for (int i = 0; i < list1.Count; i++)
            {
                if (list1[i] != list2[i]) return false;
            }
            return true;
        }
        public bool contains(List<string> list, List<List<string>> mills)
        {
            if (mills.Count == 0) return false;
            //Check if each individual string is equal to the other
            for (int i = 0; i < mills.Count; i++)
            {
                if (mills[i].Count != list.Count) return false;
                // If the two lists match return true
                if (matchLists(mills[i], list)) return true;
            }
            return false;
        }
        //This is a method to check if a mill has been formed...
        public void isMill()
        {
            if (currentPlayer == "CW")
            {
                for (int i = 0; i < board.mills.Count; i++)
                {
                    int millCount = 0;
                    for (int j = 0; j < player1.LastPosPlayed.Count; j++)
                    {
                        Tile one = board.getTile(player1.LastPosPlayed[j]);

                        if (board.mills[i].Contains(player1.LastPosPlayed[j]) && one.cond == "CW")
                        {
                            millCount++;
                            if (millCount == 3 && !player1.millsFormed.Contains(board.mills[i]))
                            {
                                //Prevent any errors from arising where duplicate mills are added to the mills formed list in player 
                                for (int z = 0; z < player1.millsFormed.Count; z++)
                                    if (matchLists(player1.millsFormed[z], board.mills[i])) return;

                                player1.millsFormed.Add(board.mills[i]);

                                mill = true;
                                return;
                            }
                        }
                    }
                    if (millCount == 3 && !player1.millsFormed.Contains(board.mills[i]))
                    {
                        player1.millsFormed.Add(board.mills[i]);

                        mill = true;
                        return;
                    }
                }
            }
            else
            {
                for (int i = 0; i < board.mills.Count; i++)
                {
                    int millCount = 0;
                    for (int j = 0; j < player2.LastPosPlayed.Count; j++)
                    {
                        Tile one = board.getTile(player2.LastPosPlayed[j]);

                        if (board.mills[i].Contains(player2.LastPosPlayed[j]) && one.cond == "CB")
                        {
                            millCount++;
                            if (millCount == 3 && !player2.millsFormed.Contains(board.mills[i]))
                            {
                                //Prevent any errors from arising where duplicate mills are added to the mills formed list in player 
                                for (int z = 0; z < player2.millsFormed.Count; z++)
                                    if (matchLists(player2.millsFormed[z], board.mills[i])) return;

                                player2.millsFormed.Add(board.mills[i]);

                                mill = true;
                                return;
                            }

                        }
                        if (millCount == 3 && !player2.millsFormed.Contains(board.mills[i]))
                        {
                            //Prevent any errors from arising where duplicate mills are added to the mills formed list in player
                            for (int z = 0; z < player2.millsFormed.Count; z++)
                                if (matchLists(player2.millsFormed[z], board.mills[i])) return;

                            player2.millsFormed.Add(board.mills[i]);

                            mill = true;
                            return;
                        }
                    }
                }
            }
        }
        //This method can be used for both destroying a cow, and placing a cow
        public void Play(string pos, Player player)
        {
            Tile t = new Tile(pos, player.symbol);

            if (player.CowLives > 0)
            {
                board.UpdateTile(t);

            }

        }
        public void addPiece(string pos, Player player)
        {
            Tile t = new Tile(pos, player.symbol);
            board.UpdateTile(t);
        }
        public void switchPlayer()
        {
            if (currentPlayer == "CW") currentPlayer = "CB";
            else currentPlayer = "CW";
        }
        public void RemovePiece(string pos)
        {
            Tile t = new Tile(pos, "blank");
            board.UpdateTile(t);
        }


    }
}
}
