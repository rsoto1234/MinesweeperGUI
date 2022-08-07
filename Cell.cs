using System;
using System.Collections.Generic;
using System.Text;
using MinesweeperGUI;

namespace MinesweeperGUI
{
    internal class Cell
    {
        //Declare variables 
        private int row = -1;
        private int column = -1;
        private int liveNeighbors = 0;
        private bool visited = false;
        private bool live = false;

        //Declare constructor
        public Cell(int row, int column, int liveNeighbors, bool visited, bool live)
        {
            this.row = row;
            this.column = column;
            this.liveNeighbors = liveNeighbors;
            this.visited = visited;
            this.live = live;
        }

        //Declare getters and setters
        public int getRow()
        {
            return row;
        }
        public void setRow(int row)
        {
            this.row = row;
        }
        public int getColumn()
        {
            return column;
        }
        public void setColumn(int column)
        {
            this.column = column;
        }
        public int getLiveNeighbors()
        {
            return liveNeighbors;
        }
        //Every time the setLiveNeighbors is called it adds the number to itself.
        public void setLiveNeighbors(int liveNeighbors)
        {
            this.liveNeighbors += liveNeighbors;
        }
        public bool getVisited()
        {
            return visited;
        }
        public void setVisited(bool visited)
        {
            this.visited = visited;
        }
        public bool getLive()
        {
            return live;
        }
        public void setLive(bool live)
        {
            this.live = live;
        }

    }
}
