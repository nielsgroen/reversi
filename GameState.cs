using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace reversi
{
    class GameState
    {
        public const String BLUETURN   = "Blauw is aan de beurt";
        public const String REDTURN    = "Rood is aan de beurt";
        public const String BLUEWIN    = "Blauw heeft gewonnen";
        public const String REDWIN     = "Rood heeft gewonnen";
        public const String TIE        = "Het is gelijkspel";


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
