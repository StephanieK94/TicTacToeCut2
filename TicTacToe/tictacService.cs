using System;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class TicTacService
    {
        private ConsoleGameModel game { get; set; }

        public ConsoleGameModel NewGame()
        {
            var game = new Game();
            var consoleGame = new ConsoleGameModel();

            consoleGame.TurnCount = game.TurnCount;
            consoleGame.Board = game.Board;
            consoleGame.CurrentPlayer = game.Player;

            consoleGame.CurrentMove = Factory.CreateNewConsoleMove();
            consoleGame.CurrentMove.Position = game.CurrentMove;

            consoleGame.WinCalculator = Factory.CreateConsoleWinCalculator();
            consoleGame.ConsoleWriter = Factory.CreateConsoleWriter();
            consoleGame.Message = Factory.CreateMessageList();
            consoleGame.ConsoleReader = Factory.CreateConsoleReader();
            

            return consoleGame;
        }

        public void Play(ConsoleGameModel _game)
        {
            // Passing over whatever game neeeded (could be a new game or a resumed game)
            // sets the private game for service as this game
            game = _game;
            StartGame();

            MovePrompt:
            game.ConsoleWriter.PrintOutput(game.Message.PromptForMove());
            var input = game.ConsoleReader.GetInput();

            if ( ValidateInput( input ) == false ) goto MovePrompt;
            if ( game.WinCalculator.IsWinner == true ) goto End;
            if ( PlayMove( game.CurrentMove.Position ) == false ) goto MovePrompt;

            game.WinCalculator.CalculateWinner( game.Board );
            game.TurnCount++;

            if ( game.WinCalculator.IsWinner == false && game.TurnCount < 9 )
            {
                ChangePlayer();
                goto MovePrompt;
            }

            End:
            EndGame();
        }
        private void StartGame()
        {
            game.ConsoleWriter.PrintOutput(game.Message.Welcome());
            game.ConsoleWriter.PrintBoard(game.Board);
        }
        private void EndGame()
        {
            game.ConsoleWriter.PrintOutput(game.WinCalculator.IsWinner == false
                ? game.Message.ReturnDraw()
            : game.Message.ReturnWinner(game.CurrentPlayer));
        }
        public bool PlayMove(int currentMove)
        {
            if (game.Board[currentMove] != "")
            {
                game.ConsoleWriter.PrintOutput(game.Message.InvalidMove());
                return false;
            }
            else
            {
                game.Board[currentMove] = game.CurrentPlayer;
                game.ConsoleWriter.PrintBoard(game.Board);
            }
            return true;
        }
        public bool ValidateInput(string playerInput)
        {
            if (game.CurrentMove.CheckForForfeit(playerInput) == true)
            {
                ChangePlayer();
                game.WinCalculator.IsWinner = true;
                return true;
            }

            if (game.CurrentMove.CanConvertPlayerInputToMove(playerInput) == false)
            {
                game.ConsoleWriter.PrintOutput(game.Message.InvalidInput());
                return false;
            }

            if (game.CurrentMove.ValidateMoveWithinRange() == false)
            {
                game.ConsoleWriter.PrintOutput(game.Message.OutOfBounds());
                return false;
            }
            game.CurrentMove.ConvertToPosition();
            return true;
        }
        public void ChangePlayer()
        {
            game.CurrentPlayer = (game.CurrentPlayer == "X") ? "O" : "X";
        }
        public bool PromptForNewGame()
        {
            game.ConsoleWriter.PrintOutput(game.Message.PromptForNewGame());
            var playAgain = game.ConsoleReader.GetInput();
            return playAgain.ToLower().Contains("Y".ToLower());
        }
    }
}