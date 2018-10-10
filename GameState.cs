using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reversi
{
    class GameState
    {
        const String BLUETURN   = "state bt";
        const String REDTURN    = "state rt";
        const String BLUEWIN    = "state bw";
        const String REDWIN     = "state rw";
        const String TIE        = "state tie";


        Board board;
        String state;
        int blueStones, redStones;

        public GameState()
        {

        }
    }
}
