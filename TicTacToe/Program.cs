using System;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartNewGame:
            NewGame game = new NewGame();

            game.StartGame();

            if ( game.PromptForNewGame() == true )
                goto StartNewGame;

        }
    }
}
