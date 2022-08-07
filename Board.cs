using System;
using System.Collections.Generic;
using System.Text;
using MinesweeperGUI;


namespace MinesweeperGUI
{
    class Board
    {
        //Declare variables
        private int size;
        private Cell[,] grid;
        private int difficulty;

        //Constructor
        public Board(int size)
        {
            //Half the size to get an even number of rows and cols
            this.size = size / 2;

            //Create the grid and populate it with cells.
            grid = new Cell[this.size, this.size];
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {
                    grid[i, j] = new Cell(i, j, 0, false, false);
                }
            }
        }

        public Cell[,] getGrid()
        {
            return this.grid;
        }
        public int getSize()
        {
            return this.size;
        }

        //Method for setting the live bombs based on the difficulty chosen.
        public void SetupLiveNeighbors(int difficulty)
        {
            //Create new instance of random object.
            var rand = new Random();
            //Set the difficulty
            this.difficulty = difficulty;

            //Get the total number of cells by multiplying the two sides (its a square so the sides are the same).
            int numOfCells = size * size;

            //Set bombs to 0 by default.
            double bombs = 0;

            //Sets the number of bombs as a percent of the total number of cells based on user choice.
            //10% for easy, 35% for medium, 50% for hard.
            switch (difficulty)
            {
                case 1:
                    {
                        bombs = numOfCells * 0.1;
                        break;
                    }
                case 2:
                    {
                        bombs = numOfCells * 0.35;
                        break;
                    }
                case 3:
                    {
                        bombs = numOfCells * 0.50;
                        break;
                    }
                default:
                    break;
            }

            //Set the bombs. the && here is because I noticed when I used larger sized grids like 15x15 and 25x25
            //the bomb count would go into the negatives because it would miss exactly 0 and run indefinitely.
            while (bombs != 0 && bombs >= 0)
            {

                int row = (rand.Next(numOfCells + 1) / this.size);
                int col = (rand.Next(numOfCells + 1) / this.size);

                //Try catch to handle out of bounds exceptions, should they occur.
                try
                {
                    //Check to see if the number will even fall within the matrix.
                    if (row <= this.size && col <= this.size)
                    {
                        //Check to see if the cell is already live.
                        if (grid[row, col].getLive() == false)
                        {
                            grid[row, col].setLive(true);
                            bombs--;
                        }
                    }
                }
                catch (Exception)
                {

                }
            }


        }


        //Method for calculating the live neighbors
        public void CalculateLiveNeighbors()
        {
            //For loop to traverse the matrix.
            for (int i = 0; i < grid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.GetLength(1); j++)
                {

                    try
                    {
                        if (grid[i, j + 1].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (grid[i, j - 1].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (grid[i + 1, j].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (grid[i - 1, j].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (grid[i + 1, j + 1].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (grid[i + 1, j - 1].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (grid[i - 1, j - 1].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        if (grid[i - 1, j + 1].getLive() == true)
                        {
                            grid[i, j].setLiveNeighbors(1);
                        }
                    }
                    catch (Exception)
                    {
                    }
                    //Per the instructions "If the cell is live and the neighbor count is 8, set the neighbor count to 9.
                    if (grid[i, j].getLiveNeighbors() == 8)
                    {
                        grid[i, j].setLiveNeighbors(1);
                    }
                }
            }
        }
        public void FloodFill(int x, int y)
        {

            Cell neighbour = new Cell();
            Button btn = new Button();
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    int row = i + x;
                    int column = j + y;
                    if (row > -1 && row < rows && column > -1 && column < col)
                    {

                        neighbour = grid[row, column];
                        if (!neighbour.GetIsBomb() && !neighbour.isRevealed)
                        {


                            btn = neighbour.individualButton(row, column);
                            btn.Click += Button_Click;

                            Console.WriteLine("Button " + row.ToString() + " " + column.ToString() + " Text is " + neighbour.individualButton(row, column).Text);
                            btn.PerformClick();

                        }
                    }


                }

            }



        }
        void Button_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int x = Convert.ToInt32(button.Name.Substring(0, 1));
            int y = Convert.ToInt32(button.Name.Substring(1, 1));
            Console.WriteLine(x.ToString() + " " + y.ToString());

            grid[x, y].isRevealed = true;

            show(x, y, button);
            if (grid[x, y].GetBombCount() == 0)

            {
                FloodFill(x, y);

            }
        }
    }
}