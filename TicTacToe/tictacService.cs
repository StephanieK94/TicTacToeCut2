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
            // Passing over whatever game needed (could be a new game or a resumed game)
            // sets the private game for service as this game
            game = _game;
            StartGame();

            MovePrompt:
            game.ConsoleWriter.PrintOutput(game.Message.PromptForMove());
            var input = game.ConsoleReader.GetInput();

            if ( ValidateInput( input ) == false ) goto MovePrompt;
            SetMove(input);

            if (ValidateMoveWithinRange(game.CurrentMove) == false)
            {
                game.ConsoleWriter.PrintOutput(game.Message.OutOfBounds());
                goto MovePrompt;
            }
            game.CurrentMove.ConvertToPosition();

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
            var isForfeit = CheckForForfeit(playerInput);
            if (isForfeit == true)
            {
                ChangePlayer();
                game.WinCalculator.IsWinner = true;
                return true;
            }

            var isConvertable = CanConvertPlayerInputToMove(playerInput);
            if (isConvertable == false)
            {
                game.ConsoleWriter.PrintOutput(game.Message.InvalidInput());
                return false;
            }

            return true;
        }


        public void ChangePlayer()
        {
            game.CurrentPlayer = (game.CurrentPlayer == "X") ? "O" : "X";
        }

        public bool CheckForForfeit(string userInput)
        {
            if (userInput.Contains("Q") || userInput.Contains("q")) return true;
            return false;
        }

        public bool ValidateMoveWithinRange(ConsoleMove currentMove)
        {
            if (currentMove.Row < 0 || currentMove.Row > 2) return false;
            return currentMove.Column >= 0 && currentMove.Column <= 2;
        }

        public bool CanConvertPlayerInputToMove(string userString)
        {
            try
            {
                var input = userString.Split(',');
                int row;
                int col;

                var rowSuccess = int.TryParse(input[0], out row);
                var colSuccess = int.TryParse(input[1], out col);

                if (rowSuccess != true || colSuccess != true) return false;
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }

        private void SetMove(string userInput)
        {
            var input = userInput.Split(',');
            game.CurrentMove.Row = Convert.ToInt32(input[0]);
            game.CurrentMove.Column = Convert.ToInt32(input[1]);
        }

        public bool PromptForNewGame()
        {
            game.ConsoleWriter.PrintOutput(game.Message.PromptForNewGame());
            var playAgain = game.ConsoleReader.GetInput();
            return playAgain.ToLower().Contains("Y".ToLower());
        }
    }
}