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

            this.gameBitmap = new Bitmap(this.pictureBox1.Width / 2, this.pictureBox1.Height / 2);
            Graphics gr = Graphics.FromImage(this.gameBitmap);
            gr.DrawLine(Pens.Black, 0, 0, 30, 30);

            this.pictureBox1.Image = this.gameBitmap;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
