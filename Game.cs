﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace reversi
{
    class Game
    {
        // TODO logica inbouwen dat boardSize altijd even getal is.


        public GameState state;

        public Game(int boardWidth, int boardHeight)
        {
            this.state = new GameState(boardWidth, boardHeight);

            /* Debug.WriteLine(this.state.board[0, 0]);
            this.state.board[0, 0].setStone(BoardField.BLUESTONE);
            Debug.WriteLine(this.state.board[0, 0]); */

            this.state.board[boardWidth / 2 - 1, boardHeight / 2 - 1].setStone(BoardField.BLUESTONE);
            this.state.board[boardWidth / 2 - 1, boardHeight / 2].setStone(BoardField.REDSTONE);
            this.state.board[boardWidth / 2, boardHeight / 2 - 1].setStone(BoardField.REDSTONE);
            this.state.board[boardWidth / 2, boardHeight / 2].setStone(BoardField.BLUESTONE);
            this.updatePlayable();

            Debug.WriteLine(this.state.board[4, 2].bluePlayable);
            Debug.WriteLine(this.checkDirection(4, 4, 0, -1, BoardField.BLUESTONE));
        }

        public Game(GameState state)
        {
            this.state = state;
        }

        public void updatePlayable()
        {
            for (int i = 0; i < this.state.boardWidth; i++)
            {
                for (int j = 0; j < this.state.boardHeight; j++)
                {
                    this.setPlayable(i, j);
                }
            }
        }

        public void setPlayable(int i, int j)
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

        public bool checkDirection(int i, int j, int iDir, int jDir, String playerStone)
        {

            // Recursieve versie, doet het ook niet meer gezien parameteraanpassingen van checkDirection

            /* bool lastIter = false;
            if (i + iDir < 0 || i + iDir >= this.state.boardWidth || j + jDir < 0 || j + jDir >= this.state.boardHeight) // check of volgende vak buiten t bord valt
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

            return true; */

            Debug.WriteLine("StartCoords: " + i.ToString() + " " + j.ToString() + " " + iDir.ToString() + " " + jDir.ToString());

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
    }
}
