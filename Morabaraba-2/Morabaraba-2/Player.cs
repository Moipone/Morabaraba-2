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
        public string symbol;
        public int CowLives = 12;
        public string phase;
        public int kills = 0;

        public List<string> LastPosPlayed;
        public List<List<string>> millsFormed;


        public Player(string symbol)
        {
            LastPosPlayed = new List<string>();
            millsFormed = new List<List<string>>();
            phase = "placing";
            this.symbol = symbol;
        }

    }
}
