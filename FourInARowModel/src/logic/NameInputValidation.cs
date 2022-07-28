using FourInARowModel.Constants;
using System;

namespace FourInARowModel.src.logic { }
public static class NameInputValidation
{
    public static bool CheckNames(Player[] players)
    {
        return (String.Compare(players[0].Name, players[1].Name, StringComparison.OrdinalIgnoreCase) == 0);
    }

    public static void GetAndValidateSecondPlayerName(Player[] players)
    {
        bool identicalNames = true;
        
        while (identicalNames)
        {
            Console.WriteLine(Strings.P2_ENTER_NAME);
            players[1].Name = Console.ReadLine();
            identicalNames = CheckNames(players);

            if (identicalNames)
            {
                Console.WriteLine(Strings.EQUAL_PLAYERS_NAME_ERROR);
            }
        }
    }
}
