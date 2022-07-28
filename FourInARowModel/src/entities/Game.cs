﻿using FourInARowModel.Constants;
using System;
using System.Collections.Generic;

namespace FourInARowModel.src.entities { }
public class Game
{
    public List<Player> PlayerHighScores { get; set; }
    public Player CurrentPlayer { get; set; }
    
    GameState state;
    public Game(GameState _state)
    {
        state = _state;
    }


    public void SwitchPlayer(Player[] players)
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

    public void SetPlayer(Player[] players)
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

    public void ShowHighScores()
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