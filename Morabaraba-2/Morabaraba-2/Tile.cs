using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Morabaraba_2
{
    class Tile
    {
        public string pos;
        public string cond;

        public Tile(string pos, string cond)
        {
            this.cond = cond;
            this.pos = pos;
        }

    }
}
