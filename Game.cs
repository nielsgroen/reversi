using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reversi
{
    class Game
    {
        GameState state;

        public Game()
        {
            this.state = new GameState();
        }

        public Game(GameState state)
        {
            this.state = state;
        }
    }
}
