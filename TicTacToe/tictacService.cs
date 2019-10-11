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

        public void StartGame(ConsoleGame game)
        {
            game.StartGame();

            MovePrompt:
            if ( game.ValidateInput( game.ConsoleReader.GetInput() ) == false ) goto MovePrompt;
            if ( game.WinCalculator.IsWinner == true ) goto EndGame;
            if ( game.PlayMove( game.CurrentMove.Position ) == false ) goto MovePrompt;

            game.WinCalculator.CalculateWinner( game.Board.Layout );
            game.TurnCount++;

            if ( game.WinCalculator.IsWinner == false && game.TurnCount < 9 )
            {
                game.ChangePlayer();
                goto MovePrompt;
            }

            EndGame:

            game.ConsoleWriter.PrintOutput( game.WinCalculator.IsWinner == false
                ? game.Message.ReturnDraw()
            : game.Message.ReturnWinner( game.CurrentPlayer ));
        }
    }
}