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
        bool displayHelp;

        public RenderForm()
        {
            this.displayHelp = true;
            this.game = new Game(6, 6);
            InitializeComponent();

            drawGamestate();
        }


        private void drawBitmap()
        {
            this.gameBitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics gr = Graphics.FromImage(this.gameBitmap);


            for (int i = 0; i < this.game.State.boardWidth; i++)
            {
                for (int j = 0; j < this.game.State.boardHeight; j++)
                {
                    drawVakje(gr, i, j);
                    
                }
            }

            this.pictureBox1.Image = this.gameBitmap;
        }

        private void drawVakje(Graphics gr, int i, int j)
        {
            int vakBreedte = this.gameBitmap.Width / this.game.State.boardWidth - 1; // -1 zorgt ervoor dat rand van laatste vakken compleet getekend wordt
            int vakHoogte = this.gameBitmap.Height / this.game.State.boardHeight - 1;

            Rectangle vak = new Rectangle((i * vakBreedte), (j * vakHoogte), vakBreedte, vakHoogte);

            // teken het vak
            gr.DrawRectangle(Pens.Black, vak);

            // teken de steen
            switch (this.game.State.board[i, j].stone)
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

            if (this.displayHelp)
            {
                // teken ofdat veld speelbaar is
                if ((this.game.State.state == GameState.BLUETURN && this.game.State.board[i, j].bluePlayable) || (this.game.State.state == GameState.REDTURN && this.game.State.board[i, j].redPlayable))
                {
                    Rectangle playableVak = vak;
                    playableVak.Inflate(-2, -2);
                    gr.DrawEllipse(Pens.Gray, playableVak);
                }

                if (this.game.State.board[i, j].recentlyChanged && !this.game.State.board[i, j].lastPlayed)
                {
                    Rectangle recentlyVak = vak;
                    recentlyVak.Inflate(-20, -20);
                    //recentlyVak.Offset(5, 5);
                    gr.FillRectangle(Brushes.Green, recentlyVak);
                    gr.DrawRectangle(Pens.Gray, recentlyVak);
                }
                if (this.game.State.board[i, j].lastPlayed)
                {
                    Rectangle recentlyVak = vak;
                    recentlyVak.Inflate(-20, -20);
                    //recentlyVak.Offset(5, 5);
                    gr.FillRectangle(Brushes.Yellow, recentlyVak);
                    gr.DrawRectangle(Pens.Gray, recentlyVak);
                }
            }
            

        }

        private Point pictureBoxToBoardCoords(Point po)
        {
            int vakBreedte = this.gameBitmap.Width / this.game.State.boardWidth - 1; // -1 zorgt ervoor dat rand van laatste vakken compleet getekend wordt (maar het bord iets kleiner wordt)
            int vakHoogte = this.gameBitmap.Height / this.game.State.boardHeight - 1;
            int i = po.X / vakBreedte;
            int j = po.Y / vakHoogte;
            return new Point(i, j);
        }

        private Point pictureBoxToBoardCoords(int x, int y)
        {
            return pictureBoxToBoardCoords(new Point(x, y));
        }



        // Eventhandlers

        private void button1_Click(object sender, EventArgs e)
        {
            int breedte, hoogte;

            try
            {
                breedte = int.Parse(this.textBox1.Text);
                hoogte = int.Parse(this.textBox2.Text);
            } catch (FormatException)
            {
                breedte = 6;
                hoogte = 6;
            }


            this.game = new Game(breedte, hoogte);
            this.drawGamestate();

            this.textBox1.Text = breedte.ToString();
            this.textBox2.Text = hoogte.ToString();
        }

        private void RenderForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs mea)
        {
            Point vak = pictureBoxToBoardCoords(mea.X, mea.Y);
            this.game.makeMove(vak.X, vak.Y);
            this.drawGamestate();
        }

        private void drawGamestate()
        {
            this.drawBitmap();
            this.label5.Text = this.game.getNumberStones(BoardField.REDSTONE).ToString();
            this.label6.Text = this.game.getNumberStones(BoardField.BLUESTONE).ToString();
            this.label7.Text = this.game.State.state;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.displayHelp = !this.displayHelp;
            this.drawGamestate();
        }
    }
}
