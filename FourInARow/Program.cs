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
        static Board        myBoard = new Board(7, 6);
        static GameState    state = new GameState();
        static Player[]     players = new Player[2];
        static WinCheck     winChecker = new WinCheck();

        static void Main(string[] args)
        {
            Cell currentCell = new Cell(0,0);
            bool win = false;

            try
            {
                CreatePlayers();

                SetStartingPlayerInState();

                while (StartNewGame(currentCell, win));
              
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        private static void SetStartingPlayerInState()
        {
            Console.WriteLine($"{Strings.MOVE_FIRST_MSG} {players[0].Name} or {players[1].Name} ?");
            state.CurrentPlayer = new Player();

            // Updating the state with the first playing user
            state.CurrentPlayer.Name = Console.ReadLine();
            state.SetPlayer(players);
        }

        private static bool StartNewGame(Cell currentCell, bool win)
        {
            myBoard = new Board(6, 7);
            winChecker = new WinCheck();
            printBoard(myBoard);
            
            while (!win)
            {
                Console.WriteLine($"{Strings.NOW_PLAYING} {state.CurrentPlayer.Name}," +
                    $" {Strings.COLOR} {state.CurrentPlayer.Color}");

                // ask the user for an x and y coordinate where will place a piece
                currentCell = getValideCell();
                //currentCell.CurrentlyOccupied = true;

                myBoard.SetCellOnBoard(currentCell, state);

                win = winChecker.SearchWins(myBoard, state);

                state.SwitchPlayer(players);
               
                printBoard(myBoard);
                if (win)
                {
                    state.CurrentPlayer.CurrentScore += 1;
                    break;
                }
            }
            
            Console.WriteLine($"{state.CurrentPlayer.Name} {Strings.WON}");
            
            Console.WriteLine($"state.CurrentPlayer.CurrentScore - {state.CurrentPlayer.CurrentScore} ");

            
            Console.WriteLine($"state.TopScorePlayerName - {state.TopScorePlayerName} ");
            Console.WriteLine($"state.TopScore - {state.TopScore} ");

            Console.WriteLine($"{Strings.REPLAY}");

            string replay = Console.ReadLine();
            if (replay == "y")
            {
                return true;
            }
            else
            {
                Console.WriteLine($"{Strings.THANKS}");
                return false;
            }
        }

        private static void CreatePlayers()
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

                    Console.WriteLine("Enter a column number");
                    currentColumn = int.Parse(Console.ReadLine());

                    currentRow = getVacantLine(currentColumn);

                    if (currentRow == -1)
                    {
                        isValidInput = false;
                    }
                    else
                    {
                        isValidInput = true;
                    }
                }

                
                return myBoard.theGrid[currentRow, currentColumn];
            }
            catch (Exception ex)
            {
                Console.WriteLine(Strings.INVALID_POSITION);
                throw new Exception(ex.Message);
            }
        }

        // finding the first vacant line in the column the user selected
        private static int getVacantLine(int currentColumn)
        {
            if (currentColumn < 0 || currentColumn > myBoard.theGrid.GetLength(1) - 1)
            {
                Console.WriteLine(Strings.INVALID_COLUMN);
                return -1;
            }
            for (int j = myBoard.theGrid.GetLength(1) - 2; j >= 0; j--)
            {
                if (myBoard.theGrid[j, currentColumn].CurrentlyOccupied == false)
                {
                    return j;
                }
            }

            // incase the column is full, we return -1 and not 0, since 0 is also
            // a valid row number
            return -1;
        }

        private static void printBoard(Board myBoard)
        {
            // print the chess board. . means an empty cell

            for (int i = 0; i < myBoard.theGrid.GetLength(1); i++)
                Console.Write($" {i} ");
            Console.WriteLine();
            Console.WriteLine("--------------------");

            for (int i = 0; i < myBoard.theGrid.GetLength(0); i++)
            {

                for (int j = 0; j < myBoard.theGrid.GetLength(1); j++)
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
