using System.Collections.Generic;

namespace TicTacToeCut2.Api
{
    public class GameResultModel
    {
        public string[] Board { get; set; }
        public List<PlayerModel> Players { get; set; }
        public string GameState { get; set; }
    }
}
