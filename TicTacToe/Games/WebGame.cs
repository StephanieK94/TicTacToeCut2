using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Players;

namespace TicTacToe.Games
{
    public class WebGame: IGame
    {
        public string[] Board { get; set; }
        public List<Player> Players { get; set; }
        public void StartGame()
        {
            throw new NotImplementedException();
        }
    }
}
