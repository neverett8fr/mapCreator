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
        //0 - water
        //1 - land
        //2 - fresh water
        //3 - river water (connect lake / fresh water to closest ocean)

        int[,] mapGrid;
        PictureBox world;
        ProgressBar progress;

        public mapClass(int size, PictureBox world, ProgressBar progress)
        {
            //this.mapGrid = new int[size];
            this.mapGrid = new int[world.Width*(size/100), world.Height*(size/100)];
            this.world = world;
            this.progress = progress;

        }

        public void generate(int rivers, int lakes, int islandNumbers)
        {
            Random rnd = new Random();


            for (int i = 0; i <= islandNumbers - 1; i++)
            {
                mapGrid[rnd.Next(0, mapGrid.GetLength(0) - 1), rnd.Next(0, mapGrid.GetLength(1) - 1)] = 1;

            }

            for (int i = 0; i <= lakes - 1; i++)
            {
                mapGrid[rnd.Next(0, mapGrid.GetLength(0) - 1), rnd.Next(0, mapGrid.GetLength(1) - 1)] = 2;

            }


        }


    }
}
