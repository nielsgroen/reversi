using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace reversi
{
    public partial class RenderForm : Form
    {
        Game game;
        Bitmap gameBitmap;

        public RenderForm()
        {
            this.game = new Game(8, 8);
            InitializeComponent();

            drawBitmap();
        }

        private void RenderForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs mea)
        {
            Point vak = pictureBoxToBoardCoords(mea.X, mea.Y);
            this.game.makeMove(vak.X, vak.Y);
            this.drawBitmap();
        }

        private void drawBitmap()
        {
            this.gameBitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics gr = Graphics.FromImage(this.gameBitmap);


            for (int i = 0; i < this.game.state.boardWidth; i++)
            {
                for (int j = 0; j < this.game.state.boardHeight; j++)
                {
                    drawVakje(gr, i, j);
                    
                }
            }

            this.pictureBox1.Image = this.gameBitmap;
        }

        private void drawVakje(Graphics gr, int i, int j)
        {
            int vakBreedte = this.gameBitmap.Width / this.game.state.boardWidth - 1; // -1 zorgt ervoor dat rand van laatste vakken compleet getekend wordt
            int vakHoogte = this.gameBitmap.Height / this.game.state.boardHeight - 1;

            Rectangle vak = new Rectangle((i * vakBreedte), (j * vakHoogte), vakBreedte, vakHoogte);

            // teken het vak
            gr.DrawRectangle(Pens.Black, vak);

            // teken de steen
            switch (this.game.state.board[i, j].stone)
            {
                case BoardField.NOSTONE:
                    break;
                case BoardField.REDSTONE:
                    gr.FillEllipse(Brushes.Red, vak);
                    break;
                case BoardField.BLUESTONE:
                    gr.FillEllipse(Brushes.Blue, vak);
                    break;
            }

            // teken ofdat veld speelbaar is
            if ((this.game.state.state == GameState.BLUETURN && this.game.state.board[i, j].bluePlayable) || (this.game.state.state == GameState.REDTURN && this.game.state.board[i, j].redPlayable))
            {
                Rectangle playableVak = vak;
                playableVak.Inflate(-2, -2);
                gr.DrawEllipse(Pens.Gray, playableVak);
            }

            if (this.game.state.board[i, j].recentlyChanged && !this.game.state.board[i, j].lastPlayed)
            {
                Rectangle recentlyVak = vak;
                recentlyVak.Inflate(-20, -20);
                //recentlyVak.Offset(5, 5);
                gr.FillRectangle(Brushes.Green, recentlyVak);
                gr.DrawRectangle(Pens.Gray, recentlyVak);
            }
            if (this.game.state.board[i, j].lastPlayed)
            {
                Rectangle recentlyVak = vak;
                recentlyVak.Inflate(-20, -20);
                //recentlyVak.Offset(5, 5);
                gr.FillRectangle(Brushes.Yellow, recentlyVak);
                gr.DrawRectangle(Pens.Gray, recentlyVak);
            }

        }

        private Point pictureBoxToBoardCoords(Point po)
        {
            int vakBreedte = this.gameBitmap.Width / this.game.state.boardWidth - 1; // -1 zorgt ervoor dat rand van laatste vakken compleet getekend wordt (maar het bord iets kleiner wordt)
            int vakHoogte = this.gameBitmap.Height / this.game.state.boardHeight - 1;
            int i = po.X / vakBreedte;
            int j = po.Y / vakHoogte;
            return new Point(i, j);
        }

        private Point pictureBoxToBoardCoords(int x, int y)
        {
            return pictureBoxToBoardCoords(new Point(x, y));
        }


    }
}
