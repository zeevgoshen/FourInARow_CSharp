using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourInARowModel
{
    public class GameState
    {
        public string NowPlaying { get; set; }
        public string NowPlayingColor { get; set; }
        public int TopScore { get; set; }
        public string TopScorePlayerName { get; set; }
        public Player CurrentPlayer { get; set; }
    }
}
