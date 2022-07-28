using FourInARowModel.Constants;
using System;

namespace FourInARowModel {}

public class Board
{
    public int Size_Height { get; set; }
    public int Size_Width { get; set; }

    // 2d array of type cell
    public Cell[,] theGrid { get; set; }

    public Board(int height, int width)
    {
        // initial size of the board.
        Size_Height = height;
        Size_Width = width;

        // create a new 2D array of type cell.
        theGrid = new Cell[Size_Height, Size_Width];

        // fill the 2D array with new Cells, each with unique x and y coordinates.
        for (int i = 0; i < Size_Height; i++)
        {
            for (int j = 0; j < Size_Width; j++)
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
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].Symbol = state.CurrentPlayer.Symbol;
            theGrid[currentCell.RowNumber, currentCell.ColumnNumber].CurrentlyOccupied = true;
        }
    }

    public Cell getValidCell()
    {
        bool isValidInput = false;
        int currentRow = 0;
        int currentColumn = 0;

        try
        {

            while (!isValidInput)
            {
                // get x and y from the user. return a cell location
                int result = 0;
                bool columnInput = false;
                Console.WriteLine(Strings.ENTER_A_COLUMN);

                columnInput = int.TryParse(Console.ReadLine(), out result);
                
                if (columnInput)
                {
                    currentColumn = result;
                }
                else
                {
                    Console.WriteLine(Strings.NONE_NUMERIC_INPUT);
                    isValidInput = false;
                    continue;
                }
                currentRow = getVacantLine(currentColumn);

                if (currentRow == -1)
                {
                    Console.WriteLine(Strings.INVALID_POSITION);
                    isValidInput = false;
                }
                else
                {
                    isValidInput = true;
                }
            }


            return theGrid[currentRow, currentColumn];
        }
        catch (Exception ex)
        {
            Console.WriteLine(Strings.INVALID_POSITION);
            throw new Exception(ex.Message);
        }
    }
        
    public int getVacantLine(int currentColumn)
    {
        if (currentColumn < 0 || currentColumn > theGrid.GetLength(1) - 1)
        {
            Console.WriteLine(Strings.INVALID_COLUMN);
            return -1;
        }
        for (int j = theGrid.GetLength(1) - 2; j >= 0; j--)
        {
            if (theGrid[j, currentColumn].CurrentlyOccupied == false)
            {
                return j;
            }
        }

        // incase the column is full, we return -1 and not 0, since 0 is also
        // a valid row number
        return -1;
    }

    public void printBoard()
    {
        // print the chess board. . means an empty cell

        for (int i = 0; i < theGrid.GetLength(1); i++)
            Console.Write($" {i} ");
        Console.WriteLine();
        Console.WriteLine("--------------------");

        for (int i = 0; i < theGrid.GetLength(0); i++)
        {

            for (int j = 0; j < theGrid.GetLength(1); j++)
            {
                Cell c = theGrid[i, j];

                if (c.CurrentlyOccupied == true)
                {
                    Console.Write($" {theGrid[i, j].Symbol} ");
                }
                else
                {
                    Console.Write(" . ");
                }
            }
            Console.WriteLine();
        }

        Console.WriteLine("===========================");
    }
}

