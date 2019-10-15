using System;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class TicTacService
    {
        public consoleGame NewGame()
        {
            var game = new Game();
            var consoleGame = new consoleGame
            {
                CurrentMove = { Position = game.CurrentMove},
                CurrentPlayer = game.Player,
                TurnCount = game.TurnCount,
            };

            return consoleGame;
        }

        public void StartGame(consoleGame game)
        {
            game.StartGame();

            MovePrompt:
            var input = game.ConsoleReader.GetInput();
            if ( game.ValidateInput( input ) == false ) goto MovePrompt;
            if ( game.WinCalculator.IsWinner == true ) goto EndGame;
            if ( game.PlayMove( game.CurrentMove.Position ) == false ) goto MovePrompt;

            game.WinCalculator.CalculateWinner( game.Board.Layout );
            game.TurnCount++;

            if ( game.WinCalculator.IsWinner == false && game.TurnCount < 9 )
            {
                game.ChangePlayer();
                game.ConsoleWriter.PrintBoard(game.Board.Layout);
                goto MovePrompt;
            }

            EndGame:

            game.ConsoleWriter.PrintOutput( game.WinCalculator.IsWinner == false
                ? game.Message.ReturnDraw()
            : game.Message.ReturnWinner( game.CurrentPlayer ));
        }
    }
}