namespace FourInARowModel.src.logic { }
public class WinCheck
{
    public bool SearchWins(Board myBoard, Game game)
    {
        string player = game.CurrentPlayer.Symbol;

        // Horizontal Check 
        for (int j = 0; j < myBoard.theGrid.GetLength(1) - 3; j++)
        {
            for (int i = 0; i < myBoard.theGrid.GetLength(0); i++)
            {
                if (myBoard.theGrid[i,j].Symbol == player
                    && myBoard.theGrid[i,j + 1].Symbol == player
                    && myBoard.theGrid[i,j + 2].Symbol == player
                    && myBoard.theGrid[i,j + 3].Symbol == player)
                {
                    return true;
                }
            }
        }
        // Vertical Check
        for (int i = 0; i < myBoard.theGrid.GetLength(0) - 3; i++)
        {
            for (int j = 0; j < myBoard.theGrid.GetLength(1); j++)
            {
                if (myBoard.theGrid[i,j].Symbol == player
                    && myBoard.theGrid[i + 1,j].Symbol == player
                    && myBoard.theGrid[i + 2,j].Symbol == player
                    && myBoard.theGrid[i + 3,j].Symbol == player)
                {
                    return true;
                }
            }
        }


        // ascendingDiagonalCheck 
        for (int i = 3; i < myBoard.theGrid.GetLength(0); i++)
        {
            for (int j = 0; j < myBoard.theGrid.GetLength(1) - 3; j++)
            {
                if (myBoard.theGrid[i, j].Symbol == player &&
                    myBoard.theGrid[i - 1, j + 1].Symbol == player &&
                    myBoard.theGrid[i - 2, j + 2].Symbol == player && 
                    myBoard.theGrid[i - 3, j + 3].Symbol == player)
                    return true;
            }
        }

        // descendingDiagonalCheck
        for (int i = 3; i < myBoard.theGrid.GetLength(0); i++)
        {
            for (int j = 3; j < myBoard.theGrid.GetLength(1); j++)
            {
                if (myBoard.theGrid[i, j].Symbol == player &&
                    myBoard.theGrid[i - 1, j - 1].Symbol == player &&
                    myBoard.theGrid[i - 2, j - 2].Symbol == player &&
                    myBoard.theGrid[i - 3, j - 3].Symbol == player)
                    return true;
            }
        }
        return false;
    }
}
