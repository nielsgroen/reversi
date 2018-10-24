using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace reversi
{
    class Game
    {
        // maak Gamestate read-only voor buitenstaanders.
        private GameState state;
        public GameState State
        {
            get { return this.state; }
        }



        public Game(int boardWidth, int boardHeight)
        {
            this.state = new GameState(boardWidth, boardHeight);

            // Zet de steen zelf ipv .setStone(), deze is voor spelerzetten.
            this.state.board[boardWidth / 2 - 1, boardHeight / 2 - 1].stone = BoardField.BLUESTONE;
            this.state.board[boardWidth / 2 - 1, boardHeight / 2].stone = BoardField.REDSTONE;
            this.state.board[boardWidth / 2, boardHeight / 2 - 1].stone = BoardField.REDSTONE;
            this.state.board[boardWidth / 2, boardHeight / 2].stone = BoardField.BLUESTONE;
            this.updatePlayable();
        }


        public Game(GameState state)
        {
            this.state = state;
        }


        public void makeMove(int i, int j)
        {
            switch (this.state.state)
            {
                case GameState.BLUETURN:
                    this.blueMoves(i, j);
                    break;
                case GameState.REDTURN:
                    this.redMoves(i, j);
                    break;
            }
        }

        public int getNumberStones(String playerStone)
        {
            int result = 0;
            for (int i = 0; i < this.state.boardWidth; i++)
            {
                for (int j = 0; j < this.state.boardHeight; j++)
                {
                    if(this.state.board[i, j].stone == playerStone)
                    {
                        result++;
                    }
                }
            }
            return result;
        }

        public bool redCanPlay()
        {
            for (int i = 0; i < this.state.boardWidth; i++)
            {
                for (int j = 0; j < this.state.boardHeight; j++)
                {
                    if (this.state.board[i, j].redPlayable)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public bool blueCanPlay()
        {
            for (int i = 0; i < this.state.boardWidth; i++)
            {
                for (int j = 0; j < this.state.boardHeight; j++)
                {
                    if (this.state.board[i, j].bluePlayable)
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        //      /\ public    || 
        //      ||           || 
        //      ||           \/ private



        private void blueMoves(int i, int j)
        {
            if (this.state.board[i, j].bluePlayable)
            {
                this.resetChanged();
                this.state.board[i, j].setStone(BoardField.BLUESTONE);
                this.flipStones(BoardField.BLUESTONE, i, j);
                this.updatePlayable();
                this.updateGamestate();
            }
        }

        private void redMoves(int i, int j)
        {
            if (this.state.board[i, j].redPlayable)
            {
                this.resetChanged();
                this.state.board[i, j].setStone(BoardField.REDSTONE);
                this.flipStones(BoardField.REDSTONE, i, j);
                this.updatePlayable();
                this.updateGamestate();
            }
        }

        private void updateGamestate()
        {
            // TODO make proper gamestate updater

            if (this.state.state == GameState.BLUETURN)
            {
                if (redCanPlay())
                {
                    this.state.state = GameState.REDTURN;
                    return;
                }

                if (blueCanPlay())
                {
                    return;
                }

                this.endGame();
            }
            else if (this.state.state == GameState.REDTURN)
            {
                if (blueCanPlay())
                {
                    this.state.state = GameState.BLUETURN;
                    return;
                }

                if (redCanPlay())
                {
                    return;
                }

                this.endGame();
            }
        }

        private void endGame()
        {
            int blue = this.getNumberStones(BoardField.BLUESTONE);
            int red = this.getNumberStones(BoardField.REDSTONE);

            if (blue > red)
            {
                this.state.state = GameState.BLUEWIN;
            }
            else if (red > blue)
            {
                this.state.state = GameState.REDWIN;
            }
            else
            {
                this.state.state = GameState.TIE;
            }
        }

        private void updatePlayable()
        {
            for (int i = 0; i < this.state.boardWidth; i++)
            {
                for (int j = 0; j < this.state.boardHeight; j++)
                {
                    this.setPlayable(i, j);
                }
            }
        }

        private void resetChanged()
        {
            for (int i = 0; i < this.state.boardWidth; i++)
            {
                for (int j = 0; j < this.state.boardHeight; j++)
                {
                    this.state.board[i, j].recentlyChanged = false;
                    this.state.board[i, j].lastPlayed = false;
                }
            }
        }

        private void setPlayable(int i, int j)
        {
            this.state.board[i, j].bluePlayable = false;
            this.state.board[i, j].redPlayable = false;

            if (this.state.board[i, j].stone == BoardField.NOSTONE)
            {
                bool bluePlayable = false, redPlayable = false;
                for (int iDir = -1; iDir <= 1; iDir++)
                {
                    for (int jDir = -1; jDir <= 1; jDir++)
                    {
                        bluePlayable = bluePlayable || this.checkDirection(i, j, iDir, jDir, BoardField.BLUESTONE); // naar linksboven
                        redPlayable = redPlayable || this.checkDirection(i, j, iDir, jDir, BoardField.REDSTONE); // naar linksboven
                    }
                }
                this.state.board[i, j].bluePlayable = bluePlayable;
                this.state.board[i, j].redPlayable = redPlayable;
            }

            

            // this.checkDirection(i, j, -1, -1, BoardField.REDSTONE); // naar linksboven
        }

        private bool checkDirection(int i, int j, int iDir, int jDir, String playerStone)
        {
            bool encounteredOtherColor = false;

            if (iDir == 0 && jDir == 0)
            {
                return false;
            }

            while (true)
            {
                if (i + iDir < 0 || i + iDir >= this.state.boardWidth || j + jDir < 0 || j + jDir >= this.state.boardHeight) // check of volgende vak buiten t bord valt
                {
                    return false;
                }

                i += iDir;
                j += jDir;

                if (this.state.board[i, j].stone == BoardField.NOSTONE) // check ofdat huidige vak leeg is
                {
                    return false;
                }
                else if (this.state.board[i, j].stone != playerStone)
                {
                    encounteredOtherColor = true;
                }
                else if (this.state.board[i, j].stone == playerStone)
                {
                    return encounteredOtherColor; // speelbaar als, en alleen als, andere kleur tegengekomen
                }

            }
        }

        private void flipStones(String playerStone, int i, int j)
        {
            for (int iDir = -1; iDir <= 1; iDir++)
            {
                for (int jDir = -1; jDir <= 1; jDir++)
                {
                    this.flipDirection(i, j, iDir, jDir, playerStone);
                }
            }
        }

        private void flipDirection(int i, int j, int iDir, int jDir, String playerStone)
        {
            bool loop = true;

            if ((iDir == 0 && jDir == 0) || !this.checkDirection(i, j, iDir, jDir, playerStone))
            {
                loop = false;
            }

            while (loop)
            {
                if (i + iDir < 0 || i + iDir >= this.state.boardWidth || j + jDir < 0 || j + jDir >= this.state.boardHeight) // check of volgende vak buiten t bord valt
                {
                    loop = false;
                }
                else
                {
                    i += iDir;
                    j += jDir;
                }

                

                if (this.state.board[i, j].stone == BoardField.NOSTONE) // check ofdat huidige vak leeg is
                {
                    loop =  false;
                }
                if (this.state.board[i, j].stone != playerStone && this.state.board[i, j].stone != BoardField.NOSTONE)
                {
                    this.state.board[i, j].setStone(playerStone);
                }
                else if (this.state.board[i, j].stone == playerStone)
                {
                    loop = false;
                }

            }
        }

    }
}
