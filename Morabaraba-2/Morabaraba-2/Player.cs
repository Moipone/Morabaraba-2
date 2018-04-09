using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba_2
{
    class Player
    {
        //Start each player with 12 pieces
        public int CW = 12, CB = 12;
        public string CWStr = "CW", CBStr = "CB";
        public Board board = new Board();
        private string enemyPos = "";

        public Player(int cw, int cb)
        {
            this.CB = cw;
            this.CB = cb;
        }

        //This method can be used for both destroying a cow, and placing a cow
        public void Play(string pos, string condition)
        {
            Tile t = new Tile(pos, condition);
            board.UpdateTile(t);

        }
        public void SetEnemyPos(string pos)
        {
            this.enemyPos = pos;
        }
        public string getEnemyPos()
        {
            return this.enemyPos;
        }
        public string getEnemyPlayer(string pos)
        {
            return board.getTile(pos).cond;
        }
        public void accountForMill1()
        {
            string[] list = board.getMillP1();
            List<string[]> mills = board.getMills();
            //Always remove the last element from the board list
            if (mills.Count > 0) board.getMills().Remove(mills[mills.Count - 1]);

            for (int i = 0; i < list.Length; i++)
            {
                bool flag = isMill1(list[i]);
                if (flag)
                {
                    //board.addMill(list);
                    //If this mill already exists in the list don't do anything
                    string[] tmp = board.checkMills2(list[i]);
                    if (board.contains(tmp)) return;
                    // create a separat method to destroy a piece
                    Tile t = new Tile(enemyPos, "blank"); //Update this, so that it doesn't shoot its own players.
                    board.UpdateTile(t);
                    break;
                }
            }




        }
        public void accountForMill2()
        {
            string[] list = board.getMillP2();

            for (int i = 0; i < list.Length; i++)
            {
                bool flag = isMill2(list[i]);

                if (flag)
                {
                    //If this mill already exists in the list don't do anything
                    string[] tmp = board.checkMills2(list[i]);
                    if (board.contains(tmp)) return;

                    // create a separat method to destroy a piece
                    Tile t = new Tile(enemyPos, "blank"); //Update this, so that it doesn't shoot its own players.
                    board.UpdateTile(t);
                }
            }



        }
        public bool isMill1(string pos)
        {
            string[] possibleMill = board.checkMills1(pos);

            Tile one = null, two = null, three = null;
            if (possibleMill.Length > 0)
            {
                one = board.getTile(possibleMill[0]);
                two = board.getTile(possibleMill[1]);
                three = board.getTile(possibleMill[2]);

            }
            // Only need to check one of the values for null. 
            if (one == null) return false;
            if ((one.cond == two.cond && two.cond == three.cond && one.cond == three.cond) &&
                (one.cond != "blank" && two.cond != "blank" && three.cond != "blank"))
            {
                if (!board.contains(possibleMill))
                    board.addMill(possibleMill);
                else return false;

                return true;
                //board.UpdateTile(board.getTile(enemyPos));
            }
            return false;
        }
        public bool isContainedInMills(string[] list)
        {
            if (list.Length > 3) throw new Exception("A mill is always length 3");

            return board.contains(list);
        }

        public bool isMill2(string pos)
        {
            string[] possibleMill = board.checkMills2(pos);

            Tile one = null, two = null, three = null;
            if (possibleMill.Length > 0)
            {
                one = board.getTile(possibleMill[0]);
                two = board.getTile(possibleMill[1]);
                three = board.getTile(possibleMill[2]);

            }
            if (one == null) return false;
            //All the tiles must have the same condition and that condition can't be blank
            if (one.cond == two.cond && two.cond == three.cond && one.cond == three.cond &&
                (one.cond != "blank" && two.cond != "blank" && three.cond != "blank"))
            {
                if (!board.contains(possibleMill))
                    board.addMill(possibleMill);
                else return false;

                return true;
                //board.UpdateTile(board.getTile(enemyPos));
            }
            return false;
        }
    }
}
