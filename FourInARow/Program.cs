using FourInARowModel;
using FourInARowModel.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoardConsole
{
    internal class Program
    {
        static Board        myBoard = new Board(6, 7);
        static GameState    state = new GameState();
        static Player[]     players = new Player[2];
        
        static void Main(string[] args)
        {
            Cell currentCell;
            bool win = false;

            playerSelect();
            
            // show the empty chess board
            printBoard(myBoard);

            while (!win)
            {
                Console.WriteLine($"{Strings.NOW_PLAYING} {state.CurrentPlayer.Name}, {Strings.COLOR} {state.CurrentPlayer.Color}");

                // ask the user for an x and y coordinate where will place a piece
                
                currentCell = setCurrentCell();
                currentCell.CurrentlyOccupied = true;

                
                // calculate all legal moves for that piece

                myBoard.MarkNextLegalMoves(currentCell, "Red", state);

                if (state.CurrentPlayer.Name == players[1].Name)
                {
                    state.CurrentPlayer = players[0];
                }
                else
                {
                    state.CurrentPlayer = players[1];
                }

                // print the chess board. Use an X fpr occupied square. Use + for a legal move
                // Use . for empty cell
                printBoard(myBoard);
                
            }

            // wait for another enter key press before ending the program.
            Console.ReadLine();
        }

        private static void playerSelect()
        {
            players[0] = new Player();
            players[1] = new Player();

            Console.WriteLine(Strings.P1_ENTER_NAME);
            
            players[0].Name = Console.ReadLine();

            Console.WriteLine(Strings.P1_CHOOSE_COLOR);
            string color = Console.ReadLine();

            if (color == "Red".ToLower())
            {
                players[0].Color = "Red";
                players[0].Symbol = "R";
                players[1].Color = "Yellow";
                players[1].Symbol = "Y";
            }
            else
            {
                players[0].Color = "Yellow";
                players[0].Symbol = "Y";
                players[1].Color = "Red";
                players[1].Symbol = "R";
            }

            Console.WriteLine(Strings.P2_ENTER_NAME);
            players[1].Name = Console.ReadLine();

            Console.WriteLine($"{ Strings.MOVE_FIRST_MSG} { players[0].Name } or {players[1].Name } ?");

            state.CurrentPlayer = new Player();
            
            state.CurrentPlayer.Name = Console.ReadLine();

            if (state.CurrentPlayer.Name == players[0].Name)
            {
                state.CurrentPlayer = players[0];
            }
            else
            {
                state.CurrentPlayer = players[1];
            }
        }

        private static Cell setCurrentCell()
        {
            bool isValidPosition = false;
            int currentRow = 0;
            int currentColumn = 0;
            
            while (!isValidPosition)
            {
                // get x and y from the user. return a cell location
                Console.WriteLine("Enter row number");
                currentRow = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter column number");
                currentColumn = int.Parse(Console.ReadLine());

                isValidPosition = CheckPositionOnBoard(currentRow, currentColumn);

            }
            return myBoard.theGrid[currentRow, currentColumn];
        }

        private static bool CheckPositionOnBoard(int currentRow, int currentColumn)
        {
            if (currentRow < 0 || currentRow > myBoard.theGrid.GetLength(0) - 1)
            {
                Console.WriteLine(Strings.INVALID_ROW);
                return false;
            }
            else if (currentColumn < 0 || currentColumn > myBoard.theGrid.GetLength(1) - 1)
            {
                Console.WriteLine(Strings.INVALID_COLUMN);
                return false;
            }
            else if (myBoard.theGrid[currentRow, currentColumn].CurrentlyOccupied)
            {
                Console.WriteLine(Strings.INVALID_POSITION);
                return false;
            }
            else
            {
                return true;
            }
        }

        private static void printBoard(Board myBoard)
        {
            // print the chess board. Use an X fpr occupied square. Use + for a legal move
            // Use . for empty cell
            for (int i = 0; i < myBoard.Size_Width; i++)
            {
                for (int j = 0; j < myBoard.Size_Height; j++)
                {
                    Cell c = myBoard.theGrid[i, j];

                    if (c.CurrentlyOccupied == true)
                    {
                        Console.Write($" { myBoard.theGrid[i, j].Symbol} ");
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
}
