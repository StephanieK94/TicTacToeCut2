using System.Collections.Generic;

namespace TicTacToeCut2.Api.Models
{
    public class GameResultModel
    {
        public string[] Board { get; set; }
        public List<PlayerModel> Players { get; set; }
        public string GameState { get; set; }

        public GameResultModel()
        {
            Board = new string[9];
            Players = new List<PlayerModel>()
            {
                new PlayerModel(){Piece = "X"},
                new PlayerModel(){Piece = "O"},
            };
            GameState = "New Game";
        }
    }
}
