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

        public Game(int boardSize)
        {
            this.state = new GameState(boardSize);

            /* Debug.WriteLine(this.state.board[0, 0]);
            this.state.board[0, 0].setStone(BoardField.BLUESTONE);
            Debug.WriteLine(this.state.board[0, 0]); */

            this.state.board[boardSize / 2 - 1, boardSize / 2 - 1].setStone(BoardField.BLUESTONE);
            this.state.board[boardSize / 2 - 1, boardSize / 2].setStone(BoardField.REDSTONE);
            this.state.board[boardSize / 2 , boardSize / 2 - 1].setStone(BoardField.REDSTONE);
            this.state.board[boardSize / 2 , boardSize / 2].setStone(BoardField.BLUESTONE);

        }

        public Game(GameState state)
        {
            this.state = state;
        }
    }
}
