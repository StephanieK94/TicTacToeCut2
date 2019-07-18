using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();

            StartNewGame:
            game.StartGame();

            if ( game.PromptForNewGame() == true )
                goto StartNewGame;

        }
    }
}
