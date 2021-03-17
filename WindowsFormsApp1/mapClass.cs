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
            this.mapGrid = new int[Convert.ToInt32(world.Width * (size / 100)), Convert.ToInt32(world.Height * (size / 100))];
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

        private int[] expandLandRecursion(int blockType, List<int[]> coordList)
        {
            System.Threading.Thread.Sleep(100);
            Random rnd = new Random();
            int[] coord = coordList.ElementAt(rnd.Next(0, coordList.Count() - 1));

            try
            {
                switch (rnd.Next(0, 3))
                {
                    case 0:
                        if (coord[1] == 0 | mapGrid[coord[0], coord[1] - 1] == blockType)
                        {
                            coord = expandLandRecursion(blockType, coordList);
                        }
                        else
                        {                            
                            coord[1] += -1;

                        }
                        break;

                    case 1:
                        if (coord[0] == mapGrid.GetLength(0) - 1 | mapGrid[coord[0] + 1, coord[1]] == blockType)
                        {
                            coord = expandLandRecursion(blockType, coordList);
                        }
                        else
                        {                           
                            coord[0] += 1;
                        }
                        break;


                    case 2:
                        if (coord[1] == mapGrid.GetLength(1) - 1 | mapGrid[coord[0], coord[1] + 1] == blockType)
                        {
                            coord = expandLandRecursion(blockType, coordList);
                        }
                        else
                        {
                            
                            coord[1] += 1;

                        }
                        break;

                    case 3:
                        if (coord[0] == 0 | mapGrid[coord[0] - 1, coord[1]] == blockType)
                        {
                            coord = expandLandRecursion(blockType, coordList);
                        }
                        else
                        {                            
                            coord[0] += -1;
                        }
                        break;

                }



            }
            catch
            {
                coord = expandLandRecursion(blockType, coordList);
            }

            //if chosen place == already chosen, call expandLandRecursion again.


            return coord;
        }

        private void expandLand(int blockType, int expandCount)
        { //try doing this recursive //if already has block of type then rerun
            //choose random where == to thing try having list of blockType

            List<int[]> coordList = new List<int[]>();

            for (int x = 0; x <= mapGrid.GetLength(0) - 1; x++)
            {
                for (int y = 0; y <= mapGrid.GetLength(1) - 1; y++)
                {
                    if (blockType == mapGrid[x, y])
                    {
                        coordList.Add(new int[2]);
                        coordList.Last()[0] = x;
                        coordList.Last()[1] = y;

                    }

                }
            }

            while (returnBlockCount(blockType) < expandCount)
            {
                int[] temp = new int[2];
                temp = expandLandRecursion(blockType, coordList);

                mapGrid[temp[0], temp[1]] = blockType;

            }

            //call expandLandRecursion until count achieved

        }

        private void connectRiver()
        {

        }

        public void generate(int rivers, int lakes, int islandNumbers)
        {
            generateSeed(rivers, lakes, islandNumbers);
            expandLand(1, 100);
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
