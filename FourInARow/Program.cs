using FourInARowModel.Constants;

namespace ChessBoardConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Game.CreatePlayers();
                
                Game.SetStartingPlayer();

                while (Game.StartNewGame());
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
