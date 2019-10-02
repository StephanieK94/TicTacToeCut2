using System;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class TicTacService
    {
        public ConsoleGame NewGame()
        {
            var game = new Game();
            var consoleGame = new ConsoleGame
            {
                CurrentMove = { Position = game.CurrentMove},
                CurrentPlayer = game.Player,
                TurnCount = game.TurnCount,
            };

            return consoleGame;
        }
    }
}