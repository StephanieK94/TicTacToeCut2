﻿using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            StartNewGame:
            Game game = new Game();

            game.StartGame();

            if ( game.PromptForNewGame() == true )
                goto StartNewGame;

        }
    }
}
