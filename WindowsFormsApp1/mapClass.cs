using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

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
        Graphics graphics;
        ProgressBar progress;

        public mapClass(double size, PictureBox world, ProgressBar progress)
        {
            //this.mapGrid = new int[size];
            this.mapGrid = new int[Convert.ToInt32(world.Width*(size/100)), Convert.ToInt32(world.Height*(size/100))];
            this.world = world;
            this.progress = progress;

            graphics = world.CreateGraphics();

        }

        private int returnBlockCount(int blockType)
        {
            int count = 0;

            for (int x = 0; x <= mapGrid.GetLength(0) - 1; x++)
            {
                for (int y = 0; y <= mapGrid.GetLength(1) - 1; y++)
                {
                    if (blockType == mapGrid[x, y])
                    {
                        count += 1;

                    }
                }
            }


            return count;
        }


        private void generateSeed(int rivers, int lakes, int islandNumbers)
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
            for (int i = 0; i <= rivers - 1; i++)
            {
                mapGrid[rnd.Next(0, mapGrid.GetLength(0) - 1), rnd.Next(0, mapGrid.GetLength(1) - 1)] = 3;

            }
        }

        private void expandLand(int blockType, int expandCount)
        {
            while (expandCount > returnBlockCount(blockType))
            {
                for (int x = 0; x <= mapGrid.GetLength(0) - 1; x++)
                {
                    for (int y = 0; y <= mapGrid.GetLength(1) - 1; y++)
                    {
                        if (blockType == mapGrid[x, y])
                        {

                        }

                    }
                }
            }            
        }

        private void connectRiver()
        {

        }

        public void generate(int rivers, int lakes, int islandNumbers)
        {
            generateSeed(rivers, lakes, islandNumbers);
            expandLand(1, 80);
            expandLand(2, 20);

            connectRiver();
            drawBoard();

        }

        private void drawBoard()
        {
            graphics.Clear(Color.LightGray);
            graphics.DrawLine(new Pen(Color.Gray), 0, 0, world.Width, 0);
            graphics.DrawLine(new Pen(Color.Gray), 0, 0, 0, world.Height);
            graphics.DrawLine(new Pen(Color.Gray), 0, world.Height - 1, world.Width, world.Height - 1);
            graphics.DrawLine(new Pen(Color.Gray), world.Width - 1, 0, world.Width - 1, world.Height);

            int stepUp = world.Height / mapGrid.GetLength(1);
            int stepDown = world.Width / mapGrid.GetLength(0);

            for (int x = 0; x <= mapGrid.GetLength(0) - 1; x++)
            {
                //MessageBox.Show("x");

                for (int y = 0; y <= mapGrid.GetLength(1) - 1; y++)
                {
                    graphics.FillRectangle(Brushes.Blue, x * stepDown, y * stepUp, stepDown, stepUp);
                    graphics.DrawRectangle(Pens.Black, x * stepDown, y * stepUp, stepDown, stepUp);
                    if (mapGrid[x, y] == 1)
                    {
                        graphics.FillRectangle(Brushes.Green, x * stepDown, y * stepUp, stepDown, stepUp);
                        graphics.DrawRectangle(Pens.Black, x * stepDown, y * stepUp, stepDown, stepUp);
                    }
                    else if (mapGrid[x, y] == 2)
                    {
                        graphics.FillRectangle(Brushes.LightBlue, x * stepDown, y * stepUp, stepDown, stepUp);
                        graphics.DrawRectangle(Pens.Black, x * stepDown, y * stepUp, stepDown, stepUp);
                    }
                    else if (mapGrid[x, y] == 3)
                    {
                        graphics.FillRectangle(Brushes.BlueViolet, x * stepDown, y * stepUp, stepDown, stepUp);
                        graphics.DrawRectangle(Pens.Black, x * stepDown, y * stepUp, stepDown, stepUp);
                    }
                }
            }


        }


    }
}
