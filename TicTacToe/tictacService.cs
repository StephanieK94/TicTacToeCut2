using System;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class TictacService
    {
        public ConsoleGame NewGame()
        {
            var game = new Game();
            var consoleGame = new ConsoleGame();

            consoleGame.TurnCount = game.TurnCount;
            consoleGame.CurrentPlayer = game.Player.ToString();
            consoleGame.Move.Position = game.CurrentMove;
            consoleGame.Board.Layout = game.Board.Layout;

            return consoleGame;
        }
    }
}