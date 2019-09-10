using System.Collections.Generic;

namespace TicTacToeCut2.Api.Tests
{
    public class GameResultModel
    {
        public string[] board { get; set; }
        public List<PlayerModel> players { get; set; }
        public string gameState { get; set; }
    }
}
