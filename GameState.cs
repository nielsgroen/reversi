using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace reversi
{
    class GameState
    {
        const String BLUETURN   = "state bt";
        const String REDTURN    = "state rt";
        const String BLUEWIN    = "state bw";
        const String REDWIN     = "state rw";
        const String TIE        = "state tie";


        //Board board;
        public String state;
        public int blueStones, redStones, boardSize;
        public BoardField[,] board;


        public GameState(int boardSize)
        {
            this.state = GameState.BLUETURN;
            this.boardSize = boardSize;
            this.board = new BoardField[this.boardSize, this.boardSize];
            for (int i = 0; i < this.boardSize; i++)
            {
                for (int j = 0; j < this.boardSize; j++)
                {
                    this.board[i, j] = new BoardField();
                }
            }


        }
    }
}
