using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARowModel
{
    public class Board
    {
        public int Size_Width { get; set; }
        public int Size_Height { get; set; }

        // 2d array of type cell
        public Cell[,] theGrid { get; set; }

        public Board(int width, int height)
        {
            // initial size of the board is defined by s.
            Size_Width = width;
            Size_Height = height;

            // create a new 2D array of type cell.
            theGrid = new Cell[Size_Width, Size_Height];

            // fill the 2D array with new Cells, each with unique x and y coordinates.
            for (int i = 0; i < Size_Width; i++)
            {
                for (int j = 0; j < Size_Height; j++)
                {
                    theGrid[i, j] = new Cell(i, j);
                }
            }
        }

        public void SetCellOnBoard(Cell currentCell, GameState state)
        {
            // check ouf of bounds
            if (!theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied)
            {
                theGrid[currentCell.RowNumber, currentCell.ColumnNumber].LegalNextMove = true;
                theGrid[currentCell.RowNumber, currentCell.ColumnNumber].Symbol = state.CurrentPlayer.Symbol;
                theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
            }
        }
    }
}
