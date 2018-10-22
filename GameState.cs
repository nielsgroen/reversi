using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace reversi
{
    class GameState
    {
        public const String BLUETURN   = "state bt";
        public const String REDTURN    = "state rt";
        public const String BLUEWIN    = "state bw";
        public const String REDWIN     = "state rw";
        public const String TIE        = "state tie";


        //Board board;
        public String state;
        public int blueStones, redStones, boardWidth, boardHeight;
        public BoardField[,] board;


        public GameState(int boardWidth, int boardHeight)
        {
            this.state = GameState.BLUETURN;
            this.boardWidth = boardWidth;
            this.boardHeight = boardHeight;
            this.board = new BoardField[this.boardWidth, this.boardHeight];
            for (int i = 0; i < this.boardWidth; i++)
            {
                for (int j = 0; j < this.boardHeight; j++)
                {
                    this.board[i, j] = new BoardField();
                }
            }


        }
    }
}
