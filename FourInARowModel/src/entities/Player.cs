using System;

namespace FourInARowModel { }
public class Player
{
    public string Color { get; set; }
    public string Name { get; set; }
    public int CurrentScore { get; set; }
    public string Symbol { get; set; }

    public bool CheckNames(Player[] players)
    {
        return (String.Compare(players[0].Name, players[1].Name, StringComparison.OrdinalIgnoreCase) == 0);
    }
}
