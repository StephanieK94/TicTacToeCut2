using System;
using TicTacToe.Games;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartNewGame:
            var game = new ConsoleGame();

            game.StartGame();

            if ( game.PromptForNewGame() == true )
                goto StartNewGame;

        }
    }
}
