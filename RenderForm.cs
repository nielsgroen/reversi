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

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

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

            if ((this.game.state.state == GameState.BLUETURN && this.game.state.board[i, j].bluePlayable) || (this.game.state.state == GameState.REDTURN && this.game.state.board[i, j].redPlayable))
            {
                Rectangle playableVak = vak;
                playableVak.Inflate(-2, -2);
                gr.DrawEllipse(Pens.Gray, playableVak);
            }

        }


    }
}
