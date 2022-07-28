using FourInARowModel.Constants;
using System;
using System.Collections.Generic;

namespace FourInARowModel.src.entities { }
public class Game
{
    public static List<Player> PlayerHighScores = new List<Player>();
    public static Player CurrentPlayer { get; set; }
    static Player[] players = new Player[2];
    static GameState state = new GameState();
    static Board myBoard = null;
    static WinCheck winChecker = new WinCheck();
    static bool win = false;

    public Game()
    {
    }

    public static void SetStartingPlayer()
    {
        Console.WriteLine($"{Strings.MOVE_FIRST_MSG} {players[0].Name} or {players[1].Name} ?");
        CurrentPlayer = new Player();

        // set the first playing user
        CurrentPlayer.Name = Console.ReadLine();
        SetPlayer(players);
    }
    public static void CreatePlayers()
    {
        players[0] = new Player();
        players[1] = new Player();

        PlayerHighScores.Add(players[0]);
        PlayerHighScores.Add(players[1]);

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

    public static bool StartNewGame()
    {
        Cell currentCell = new Cell(0, 0);
        
        myBoard = new Board(6, 7);
        winChecker = new WinCheck();
        myBoard.printBoard();

        while (!win)
        {
            Console.WriteLine($"{Strings.NOW_PLAYING} {CurrentPlayer.Name}," +
                $" {Strings.COLOR} {CurrentPlayer.Color}");

            currentCell = myBoard.getValidCell();
            myBoard.SetCellOnBoard(currentCell);

            win = winChecker.SearchWins(myBoard);

            if (!win)
            {
                SwitchPlayer();
            }

            myBoard.printBoard();
            if (win)
            {
                win = false;
                CurrentPlayer.CurrentScore += 1;

                // Saving top score and top score player name
                if (CurrentPlayer.CurrentScore > state.TopScore)
                {
                    state.TopScore = CurrentPlayer.CurrentScore;
                    state.TopScorePlayerName = CurrentPlayer.Name;
                }
                break;
            }
        }
        return PrintStatsAndContinue();
    }
    public static bool PrintStatsAndContinue()
    {
        if (players[0].CurrentScore == players[1].CurrentScore)
        {
            Console.WriteLine(Strings.TIE);
        }
        else
        {
            Console.WriteLine($"{CurrentPlayer.Name} {Strings.WON} {Strings.SCORE_TXT}" +
                $" {CurrentPlayer.CurrentScore} ");

            Console.WriteLine($"{Strings.TOP_PLAYER_NAME} {state.TopScorePlayerName}" +
                $" {Strings.SCORE_TXT} {state.TopScore}");
        }

        Console.WriteLine($"{Strings.REPLAY}");

        string replay = Console.ReadLine();
        if (replay == "y")
        {
            SetStartingPlayer();
            return true;
        }
        else
        {
            ShowHighScores();
            return false;
        }
    }
    public static void SwitchPlayer()
    {
        //
        // Switch players
        //
        if (CurrentPlayer.Name == players[1].Name)
        {
            CurrentPlayer = players[0];
        }
        else
        {
            CurrentPlayer = players[1];
        }
    }

    public static void SetPlayer(Player[] players)
    {
        //
        // Set player in cache
        //
        if (CurrentPlayer.Name == players[0].Name)
        {
            CurrentPlayer = players[0];
        }
        else
        {
            CurrentPlayer = players[1];
        }
    }

    public static void ShowHighScores()
    {
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(Strings.THANKS);
        Console.WriteLine();
        Console.WriteLine();
        Console.WriteLine(Strings.HIGHSCORES);
        Console.WriteLine(Strings.HIGHSCORES_SEPARATOR);

        foreach (Player player in PlayerHighScores)
        {
            Console.WriteLine($"{Strings.PLAYER_TXT} {player.Name}, {Strings.SCORE_TXT} {player.CurrentScore}");
        }
    }
}
