using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace reversi
{
    class BoardField
    {
        // This is a single field on the reversi board

        public const String NOSTONE = "stone none";
        public const String BLUESTONE = "stone blue";
        public const String REDSTONE = "stone red";
        
        /**
         * Should contain properties like:
         * - is it playable by red?
         * - is it playable by blue?
         * - What is the color of the tile Red/Blue/None?
         * - Did it recently change color?
         * - Was it the last played?
         */
        bool bluePlayable, redPlayable, recentlyChanged, lastPlayed;
        String stone;

        public BoardField()
        {
            this.stone = BoardField.NOSTONE;
            this.bluePlayable = false;
            this.redPlayable = false;
            this.recentlyChanged = false;
            this.lastPlayed = false;

        }

        public void setStone(String newStone)
        {
            String oldStone = this.stone;

            if (oldStone == newStone)
            {
                this.recentlyChanged = false;
                this.lastPlayed = false;
            }
            else if (oldStone == BoardField.NOSTONE && newStone != BoardField.NOSTONE)
            {
                this.stone = newStone;
                this.bluePlayable = false;
                this.redPlayable = false;
                this.recentlyChanged = true;
                this.lastPlayed = true;
            }
            else if (oldStone != BoardField.NOSTONE && newStone != BoardField.NOSTONE)
            {
                this.stone = newStone;
                this.bluePlayable = false;
                this.redPlayable = false;
                this.recentlyChanged = true;
                this.lastPlayed = false;
            }
        }

        override
        public String ToString()
        {
            return "Stone: " + this.stone + "\nBlueplayable: " + this.bluePlayable + "\nRedPlayable: " + this.redPlayable + "\nRecently Changed: " + this.recentlyChanged + "\nLast Played: " + this.lastPlayed + "\n";
        }
    }
}
