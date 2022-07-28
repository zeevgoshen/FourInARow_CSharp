using FourInARowModel;
using FourInARowModel.Constants;
using FourInARowModel.src.logic;

namespace ChessBoardConsole
{
    internal class Program
    {
        static Board?       myBoard = null;
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
            myBoard.printBoard();
            
            while (!win)
            {
                
                Console.WriteLine($"{Strings.NOW_PLAYING} {state.CurrentPlayer.Name}," +
                    $" {Strings.COLOR} {state.CurrentPlayer.Color}");

                currentCell = myBoard.getValideCell();
                myBoard.SetCellOnBoard(currentCell, state);

                win = winChecker.SearchWins(myBoard, state);

                if (!win) { 
                    state.SwitchPlayer(players);
                }
                
                myBoard.printBoard();
                if (win)
                {
                    state.CurrentPlayer.CurrentScore += 1;

                    // Saving top score and top score player name
                    if (state.CurrentPlayer.CurrentScore > state.TopScore)
                    {
                        state.TopScore = state.CurrentPlayer.CurrentScore;
                        state.TopScorePlayerName = state.CurrentPlayer.Name;
                    }
                    
                    break;
                }
            }

            return PrintStatsAndContinue();

        }

        private static bool PrintStatsAndContinue()
        {
            Console.WriteLine($"{state.CurrentPlayer.Name} {Strings.WON} {Strings.SCORE_TXT}" +
                $" {state.CurrentPlayer.CurrentScore} ");

            Console.WriteLine($"{Strings.TOP_PLAYER_NAME} {state.TopScorePlayerName}" +
                $" {Strings.SCORE_TXT} {state.TopScore}");

            Console.WriteLine($"{Strings.REPLAY}");

            string replay = Console.ReadLine();
            if (replay == "y")
            {
                SetStartingPlayerInState();
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
    }
}
