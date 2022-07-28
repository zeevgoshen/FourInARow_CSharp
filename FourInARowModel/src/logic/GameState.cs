using FourInARowModel.Constants;
using System;
using System.Collections.Generic;

namespace FourInARowModel { }
public class GameState
{
    public int TopScore { get; set; }
    public string TopScorePlayerName { get; set; }

    public List<Player> PlayerHighScores { get; set; }


    public Player CurrentPlayer { get; set; }

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
        if (CurrentPlayer.Name == players[0].Name)
        {
            CurrentPlayer = players[0];
        }
        else
        {
            CurrentPlayer = players[1];
        }
    }    
}
