using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class mapClass
    {
        int[,] mapGrid;
        PictureBox world;

        public mapClass(int size, PictureBox world)
        {
            //this.mapGrid = new int[size];
            this.mapGrid = new int[(world.Width)*(size/100), (world.Height)*(size/100)];
            this.world = world;

        }


    }
}
