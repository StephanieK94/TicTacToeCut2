using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework.Constraints;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleGame
    {
        public int TurnCount { get; set; }
        public ConsoleBoard Board { get; set; }
        public string CurrentPlayer { get; set; }
        public ConsoleMove CurrentMove { get; set; }

        public ConsoleWinCalculator WinCalculator { get; set; }
        public ConsoleWriter ConsoleWriter { get; set; }
        //public MessageProcessor Message { get; set; }
        public MessageList Message { get; set; }
        public ConsoleReader ConsoleReader { get; set; }

        // TODO: Remove this into the service?
        public ConsoleGame ()
        {
            TurnCount = 0;
            Board = Factory.CreateConsoleBoard();
            CurrentPlayer = "";
            CurrentMove = Factory.CreateNewConsoleMove();
            WinCalculator = Factory.CreateConsoleWinCalculator(); 
            ConsoleWriter = Factory.CreateConsoleWriter();
            ConsoleReader = Factory.CreateConsoleReader();
            Message = Factory.CreateMessageList();
        }

        public bool PlayMove(int currentMove)
        {
            if (Board.Layout[currentMove] != "") return false;
            Board.Layout[currentMove] = CurrentPlayer;
            return true;
        }
        public void StartGame ()
        {
            ConsoleWriter.PrintOutput(Message.Welcome());
            ConsoleWriter.PrintBoard(Board.Layout);
        }

        public bool ValidateInput ( string playerInput )
        {
            if ( CurrentMove.CheckForForfeit( playerInput ) == true )
            {
                ChangePlayer();
                WinCalculator.IsWinner = true;
                return true;
            }

            if ( CurrentMove.CanConvertPlayerInputToMove( playerInput ) == false )
            {
                ConsoleWriter.PrintOutput( Message.InvalidInput());
                return false;
            }

            if ( CurrentMove.ValidateMoveWithinRange() == false )
            {
                ConsoleWriter.PrintOutput( Message.OutOfBounds() );
                return false;
            }
            CurrentMove.ConvertToPosition();
            return true;
        }

        // TODO: Remove this and refactor so a part of the tic tac toe service?
        public bool PromptForNewGame ()
        {
            ConsoleWriter.PrintOutput( Message.PromptForNewGame() );
            var playAgain = ConsoleReader.GetInput();
            return playAgain.ToLower().Contains( "Y".ToLower() );
        }

        public void ChangePlayer()
        {
            CurrentPlayer = ( CurrentPlayer == "X") ? CurrentPlayer = "O" : CurrentPlayer = "X";
        }
    }
}
