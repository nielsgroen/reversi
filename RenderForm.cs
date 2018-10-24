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
            this.game = new Game(8);
            InitializeComponent();

            this.gameBitmap = new Bitmap(this.pictureBox1.Width, this.pictureBox1.Height);
            Graphics gr = Graphics.FromImage(this.gameBitmap);

            int dia = 40;

            for (int x = 0; x < this.game.state.boardSize; x++)
            {
                for (int y = 0; y < this.game.state.boardSize; y++)
                {
                    gr.DrawRectangle(Pens.Black, x*dia, y*dia, dia, dia);
                }
            }

            this.pictureBox1.Image = this.gameBitmap;
        }

        private void RenderForm_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseClick(object sender, MouseEventArgs e)
        {

        }
    }
}
