using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace reversi
{
    class Program
    {
        public static void Main()
        {
            Debug.WriteLine("hallo");
            Form render = new RenderForm();
            Application.Run(render);
        }
    }
}
