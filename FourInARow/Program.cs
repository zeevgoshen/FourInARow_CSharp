using FourInARowModel;
using FourInARowModel.Constants;
using FourInARowModel.src.logic;
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
        static WinCheck     winChecker = new WinCheck();

        static void Main(string[] args)
        {
            Cell currentCell = null;
            bool win = false;

            playerSelect();
            
            // show the empty chess board
            //printBoard(myBoard);

            StartNewGame(currentCell, win);
            

            state.CurrentPlayer.CurrentScore += 1;
            
            Console.WriteLine($"{state.CurrentPlayer.Name} {Strings.WON}");
            Console.WriteLine($"{ Strings.REPLAY}");
            
            string replay = Console.ReadLine();
            if (replay == "y")
            {
                win = false;
                StartNewGame(currentCell, win);
            }
            else
            {
                Console.WriteLine($"{Strings.THANKS}");
            }
        }

        private static void StartNewGame(Cell currentCell, bool win)
        {
            myBoard = new Board(6, 7);
            printBoard(myBoard);
            
            while (!win)
            {
                Console.WriteLine($"{Strings.NOW_PLAYING} {state.CurrentPlayer.Name}," +
                    $" {Strings.COLOR} {state.CurrentPlayer.Color}");

                // ask the user for an x and y coordinate where will place a piece
                currentCell = getValideCell();
                //currentCell.CurrentlyOccupied = true;

                myBoard.SetCellOnBoard(currentCell, state);

                winChecker = new WinCheck();
                win = winChecker.SearchWins(myBoard, state);

                //
                // Switch players
                //
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
        }

        private static void playerSelect()
        {
            players[0] = new Player();
            players[1] = new Player();

            Console.WriteLine(Strings.P1_ENTER_NAME);
            
            players[0].Name = Console.ReadLine();

            Console.WriteLine(Strings.P1_CHOOSE_COLOR);
            string color = Console.ReadLine();

            if (color == "r".ToLower())
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
            
            //
            // Updating the state with the first playing user
            //
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

        private static Cell getValideCell()
        {
            bool    isValidInput = false;
            
            int     currentRow = 0;
            
            int     currentColumn = 0;
            
            try
            {
                
                while (!isValidInput)
                {
                    // get x and y from the user. return a cell location
                    //Console.WriteLine("Enter row number");
                    //currentRow = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter column number");
                    currentColumn = int.Parse(Console.ReadLine());

                    //isValidInput = CheckForILLegalChars(currentRow, currentColumn);

                    currentRow = getVacantLine(currentColumn);

                    isValidInput = CheckPositionOnBoard(currentRow, currentColumn);

                }

                
                return myBoard.theGrid[currentRow, currentColumn];
            }
            catch (Exception ex)
            {
                Console.WriteLine(Strings.INVALID_POSITION);
                throw new Exception(ex.Message);
            }
        }

        private static int getVacantLine(int currentColumn)
        {
            for (int j = myBoard.theGrid.GetLength(1) - 2; j >= 0; j--)
            {
                if (myBoard.theGrid[j, currentColumn].CurrentlyOccupied == false)
                {
                    return j;
                }
            }

            return -1;
        }


        private static bool CheckPositionOnBoard(int currentRow, int currentColumn)
        {
            if (currentColumn < 0 || currentColumn > myBoard.theGrid.GetLength(1) - 1)
            {
                Console.WriteLine(Strings.INVALID_COLUMN);
                return false;
            } 
            else if (currentRow == -1)
            {
                Console.WriteLine(Strings.INVALID_POSITION);
                return false;
            }
            
            //else if (myBoard.theGrid[currentColumn].CurrentlyOccupied)
            //{
            //    Console.WriteLine(Strings.INVALID_POSITION);
            //    return false;
            //}
            else
            {
                return true;
            }
        }

        private static void printBoard(Board myBoard)
        {
            // print the chess board.
            // . means an empty cell
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
