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
            this.state.board[boardSize / 2, boardSize / 2 - 1].setStone(BoardField.REDSTONE);
            this.state.board[boardSize / 2, boardSize / 2].setStone(BoardField.BLUESTONE);
            this.updatePlayable();

        }

        public Game(GameState state)
        {
            this.state = state;
        }

        public void updatePlayable()
        {
            for (int i = 0; i < this.state.boardSize; i++)
            {
                for (int j = 0; j < this.state.boardSize; j++)
                {
                    this.setPlayable(i, j);
                }
            }
        }

        public void setPlayable(int i, int j)
        {
            this.state.board[i, j].bluePlayable = false;
            this.state.board[i, j].redPlayable = false;

            if (this.state.board[i,j].stone == BoardField.NOSTONE)
            {
                bool bluePlayable = false, redPlayable = false;
                for (int iDir = -1; iDir <= 1; iDir++)
                {
                    for (int jDir = -1; jDir <= 1; jDir++)
                    {
                        bluePlayable = bluePlayable || this.checkDirection(i, j, iDir, jDir, BoardField.BLUESTONE, false); // naar linksboven
                        redPlayable = redPlayable || this.checkDirection(i, j, iDir, jDir, BoardField.REDSTONE, false); // naar linksboven
                    }
                }
                this.state.board[i, j].bluePlayable = bluePlayable;
                this.state.board[i, j].redPlayable = redPlayable;
            }

            

            // this.checkDirection(i, j, -1, -1, BoardField.REDSTONE); // naar linksboven
        }

        public bool checkDirection(int i, int j, int iDir, int jDir, String playerStone, bool encounteredOtherColor)
        {
            bool lastIter = false;
            if (i + iDir < 0 || i + iDir > this.state.boardSize || j + jDir < 0 || j + jDir > this.state.boardSize) // check of volgende vak buiten t bord valt
            {
                lastIter = true;
            }

            if (this.state.board[i, j].stone == BoardField.NOSTONE) // check ofdat huidige vak leeg is
            {
                return false;
            }
            else if (this.state.board[i, j].stone != BoardField.NOSTONE && this.state.board[i, j].stone != playerStone)
            {
                encounteredOtherColor = true;
                if (lastIter)
                {
                    return false;
                }
                return this.checkDirection(i + iDir, j + jDir, iDir, jDir, playerStone, encounteredOtherColor);
            }
            else if (this.state.board[i, j].stone != BoardField.NOSTONE && this.state.board[i, j].stone == playerStone)
            {
                return encounteredOtherColor; // speelbaar als, en alleen als, andere kleur tegengekomen
            }

            return true;
        }
    }
}
