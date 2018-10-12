using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace reversi
{
    class Game
    {
        // TODO logica inbouwen dat boardSize altijd even getal is.


        GameState state;

        public Game()
        {
            this.state = new GameState();

            Debug.WriteLine(this.state.board[0, 0]);
            this.state.board[0, 0].setStone(BoardField.BLUESTONE);
            Debug.WriteLine(this.state.board[0, 0]);
        }

        public Game(GameState state)
        {
            this.state = state;
        }
    }
}
