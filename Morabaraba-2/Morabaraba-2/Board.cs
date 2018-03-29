using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba_2
{
    class Board
    {
        private List<Tile> board;
        private List<string[]> mills;
        private string enemyPos = "";
        string[] millPoints1 = {  "d1", "a1", "a7",
                                  "c3", "c5", "d3","e3",
                                  "e4", "e5", "g1" };

        string[] millPoints2 = {  "a1", "a4", "b2",
                                  "b6", "d1", "d5",
                                  "c3", "c5", "e3",
                                  "f2", "g1", "a7" };
        private string[] positions =
                               {"a1", "a4","a7",
                               "b2","b4","b6",
                               "c3", "c4", "c5",
                               "d1", "d2", "d3",
                               "d5", "d6","d7",
                               "e3","e4","e5",
                               "f2","f4", "f6",
                               "g1", "g4","g7"};

        public Board()
        {
            GenerateNewBoard();
            mills = new List<string[]>();
        }
        public void addMill(string[] mill)
        {
            mills.Add(mill);
        }
        public void removeMill(string[] mill)
        {
            mills.Remove(mill);
        }
        public List<string[]> getMills()
        {
            return this.mills;
        }
        public void GenerateNewBoard()
        {
            board = new List<Tile>();
            for (int i = 0; i < positions.Length; i++)
            {
                Tile t = new Tile(positions[i], "blank");
                board.Add(t);
            }
        }
        public List<Tile> getBoard()
        {
            return this.board;
        }
        public bool contains(string[] list)
        {
            for (int i = 0; i < mills.Count; i++)
            {
                if (mills[i] == list) return true;
            }
            return false;
        }
        public void UpdateTile(Tile t)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (board[i].pos == t.pos)
                {
                    board.Insert(i, t);
                    board.Remove(board[i + 1]);
                    break;
                }
            }
        }
        public override string ToString()
        {
            StringBuilder build = new StringBuilder();
            for (int i = 0; i < board.Count; i++)
            {
                build.Append(board[i].cond + " ");
            }
            // Return a string of the board to make it easier to print out the board
            return build.ToString().Substring(0, build.Length - 1);
            //return base.ToString();
        }
        // A method to get a tile given a certain position
        public Tile getTile(string pos)
        {
            for (int i = 0; i < board.Count; i++)
            {
                if (board[i].pos == pos) return board[i];
            }
            return null;
        }

        // Returns all possible positions
        public string[] getPositions()
        {
            return this.positions;
        }


        public string[] checkMills1(string pos)
        {
            switch (pos)
            {
                case "d1": return new string[] { "a1", "d1", "g1" };
                case "a1": return new string[] { "a1", "a4", "a7" };
                case "a7": return new string[] { "a7", "b6", "c5" };
                case "c3": return new string[] { "c3", "c4", "c5" };
                case "c5": return new string[] { "c5", "b6", "a7" };
                case "d3": return new string[] { "c3", "d3", "e3" };
                case "e4": return new string[] { "e4", "f4", "g4" };
                case "e5": return new string[] { "e5", "f6", "g7" };
                case "e3": return new string[] { "e3", "f2", "g1" };
                case "g1": return new string[] { "g1", "f2", "e3" };
            }
            return new string[] { };
        }

        public string[] checkMills2(string pos)
        {
            switch (pos)
            {
                case "a1": return new string[] { "a1", "b2", "c3" };
                case "a4": return new string[] { "a4", "b4", "c4" };
                case "b2": return new string[] { "b2", "b4", "b6" };
                case "b6": return new string[] { "b6", "d6", "f6" };
                case "d1": return new string[] { "d1", "d2", "d3" };
                case "d5": return new string[] { "d5", "d6", "d7" };
                case "c3": return new string[] { "c3", "d3", "e3" };
                case "c5": return new string[] { "c5", "d5", "e5" };
                case "e3": return new string[] { "e3", "e4", "e5" };
                case "f2": return new string[] { "f2", "f4", "f6" };
                case "g1": return new string[] { "g1", "g4", "g7" };
                case "a7": return new string[] { "a7", "d7", "g7" };
            }
            return new string[] { };
        }

        public List<string> getNeighbourCells(string pos)
        {
            switch (pos)
            {
                case "a1": return new string[] { "d1", "b2", "a4" }.ToList();
                case "a4": return new string[] { "b3", "a7", "a1" }.ToList();
                case "a7": return new string[] { "d7", "a4", "b6" }.ToList();

                case "b4": return new string[] { "a1", "c7", "b4", "d2" }.ToList();
                case "b5": return new string[] { "b4", "b6", "b2", "c7" }.ToList();
                case "b6": return new string[] { "b3", "c5", "d6", "a7" }.ToList();

                case "c3": return new string[] { "b2", "c4", "d3" }.ToList();
                case "c4": return new string[] { "c3", "b4", "c5" }.ToList();
                case "c5": return new string[] { "c4", "d5", "b6" }.ToList();

                case "d1": return new string[] { "a1", "g1", "d2" }.ToList();
                case "d2": return new string[] { "d1", "f2", "d3", "b2" }.ToList();
                case "d3": return new string[] { "d2", "e3", "c3" }.ToList();

                case "d5": return new string[] { "e5", "d6", "c5" }.ToList();
                case "d6": return new string[] { "d5", "f6", "b6", "d7" }.ToList();
                case "d7": return new string[] { "d6", "g7", "a7" }.ToList();

                case "e3": return new string[] { "d3", "f2", "e4" }.ToList();
                case "e4": return new string[] { "e3", "f4", "e5" }.ToList();
                case "e5": return new string[] { "e4", "f6", "d5" }.ToList();

                case "f2": return new string[] { "g1", "f4", "e3", "d2" }.ToList();
                case "f4": return new string[] { "f2", "g4", "f6", "e4" }.ToList();
                case "f6": return new string[] { "f4", "g7", "d6", "e5" }.ToList();

                case "g1": return new string[] { "d1", "g4", "f2" }.ToList();
                case "g4": return new string[] { "g1", "f4", "g7" }.ToList();
                case "g7": return new string[] { "g4", "f6", "d7" }.ToList();
            }
            return new List<string>();
        }
        public string[] getMillP1()
        {
            return this.millPoints1;
        }
        public string[] getMillP2()
        {
            return this.millPoints2;
        }
    }
}
