using System.Collections.Generic;

namespace TicTacToeCut2.Api.Models
{
    public class GameInputModel
    {
        public string[] Board { get; set; }
        public int Move { get; set; }
        public string Player { get; set; }  

    }
}
