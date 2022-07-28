using FourInARowModel.Constants;

namespace ChessBoardConsole
{
    internal class Program
    {
        static Board?       myBoard = null;
        static GameState    state = new GameState();
        static Player[]     players = new Player[2];
        static WinCheck     winChecker = new WinCheck();
        static Game         game = null;

        static void Main(string[] args)
        {
            Cell currentCell = new Cell(0,0);
            bool win = false;
            game = new Game(state);
            
            game.PlayerHighScores = new List<Player>();
            
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
            game.CurrentPlayer = new Player();
            
            // Updating the state with the first playing user
            game.CurrentPlayer.Name = Console.ReadLine();
            game.SetPlayer(players);
        }

        private static bool StartNewGame(Cell currentCell, bool win)
        {
            myBoard = new Board(6, 7);
            winChecker = new WinCheck();
            myBoard.printBoard();
            
            while (!win)
            {
                Console.WriteLine($"{Strings.NOW_PLAYING} {game.CurrentPlayer.Name}," +
                    $" {Strings.COLOR} {game.CurrentPlayer.Color}");
                
                currentCell = myBoard.getValidCell();
                myBoard.SetCellOnBoard(currentCell, game);

                win = winChecker.SearchWins(myBoard, game);

                if (!win) { 
                    game.SwitchPlayer(players);
                }
                
                myBoard.printBoard();
                if (win)
                {
                    game.CurrentPlayer.CurrentScore += 1;

                    // Saving top score and top score player name
                    if (game.CurrentPlayer.CurrentScore > state.TopScore)
                    {
                        state.TopScore = game.CurrentPlayer.CurrentScore;
                        state.TopScorePlayerName = game.CurrentPlayer.Name;
                    }
                    break;
                }
            }

            return PrintStatsAndContinue();
        }

        private static bool PrintStatsAndContinue()
        {
            if (players[0].CurrentScore == players[1].CurrentScore)
            {
                Console.WriteLine(Strings.TIE);
            } 
            else
            {
                Console.WriteLine($"{game.CurrentPlayer.Name} {Strings.WON} {Strings.SCORE_TXT}" +
                    $" {game.CurrentPlayer.CurrentScore} ");

                Console.WriteLine($"{Strings.TOP_PLAYER_NAME} {state.TopScorePlayerName}" +
                    $" {Strings.SCORE_TXT} {state.TopScore}");
            }

            Console.WriteLine($"{Strings.REPLAY}");

            string replay = Console.ReadLine();
            if (replay == "y")
            {
                SetStartingPlayerInState();
                return true;
            }
            else
            {
                game.ShowHighScores();
                return false;
            }
        }
        
        
        private static void CreatePlayers()
        {
            players[0] = new Player();
            players[1] = new Player();

            game.PlayerHighScores.Add(players[0]);
            game.PlayerHighScores.Add(players[1]);

            Console.WriteLine(Strings.P1_ENTER_NAME);
            players[0].Name = Console.ReadLine();

            Console.WriteLine(Strings.P1_CHOOSE_COLOR);
            string color = Console.ReadLine();

            if (color == "r".ToLower())
            {
                players[0].Color = Strings.COLOR_RED;
                players[0].Symbol = "R";
                players[1].Color = Strings.COLOR_YELLOW;
                players[1].Symbol = "Y";
            }
            else
            {
                players[0].Color = Strings.COLOR_YELLOW;
                players[0].Symbol = "Y";
                players[1].Color = Strings.COLOR_RED;
                players[1].Symbol = "R";
            }

            NameInputValidation.GetAndValidateSecondPlayerName(players);
        }
    }
}
