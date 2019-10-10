using System.Collections.Generic;

namespace TicTacToeCut2.Api.Models
{
    public class GameResultModel
    {
        public string[] Board { get; set; }
        public List<string> Players { get; set; }
        public string State { get; set; }
    }
}
