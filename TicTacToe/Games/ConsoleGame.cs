using TicTacToe.ConsoleApplication.Boards;
using TicTacToe.ConsoleApplication.Messages;
using TicTacToe.ConsoleApplication.Players;
using System;

namespace TicTacToe.ConsoleApplication.Games
{
    public class ConsoleGame
    {
        public int TurnCount { get; set; } = 0;
        public Board Board = Factory.CreateConsoleBoard();
        public Player Player = Factory.CreateConsolePlayer();
        public MessageProcessor Message = Factory.CreateConsoleMsgProcessor();
        public WinCalculator WinCal = Factory.CreateConsoleWinCalculator();
        // decoupled from Player when better refactored for Main() to follow the flow, was found to be unneeded for the Player, coupled too tightly
        public Move CurrentMove = Factory.CreateNewMove();

        public void StartGame() 
        {
            Message.PrintToConsole(Message.PrintWelcome());
            Board.PrintBoard();
        }
        public bool GetValidMove()
        {
            Message.PrintToConsole(Message.PromptForMove( Player.Character ));
            var input = CurrentMove.GetInput();
            return ValidateInput(input);
        }
        public bool ValidateInput(string playerInput)
        {
            if ( CurrentMove.CheckForForfeit( playerInput ) == true )
            {
                ChangePlayer();
                this.WinCal.IsWinner = true;
                return true;
            }

            if ( CurrentMove.ConvertPlayerInputToMove( playerInput ) == false )
            {
                Message.PrintToConsole( Message.MsgDictionary["InvalidInput"] );
                return false;
            }

            if ( ValidateMoveWithinRange( CurrentMove ) == false )
            {
                Message.PrintToConsole( Message.MsgDictionary["OutOfBound"] );
                return false;
            }
            return true;
        }
        public bool ValidateMoveWithinRange ( Move userInput )
        {
            if ( userInput.Row < 0 || userInput.Row > 2 ) return false;
            if ( userInput.Column < 0 || userInput.Column > 2 ) return false;
            return true;
        }
        public bool PlayMove(Move gameCurrentMove)
        {
            switch ( this.Board.ValidatePositionIsEmpty( gameCurrentMove ) )
            {
                case true:
                    this.Board.PlayMoveOnBoard( this.Player , gameCurrentMove );
                    Message.PrintToConsole( Message.MsgDictionary["AcceptedMove"] );
                    this.Board.PrintBoard();
                    return true;
                default:
                    Message.PrintToConsole( Message.MsgDictionary["InvalidMove"] );
                    return false;
            }
        }
        public void ChangePlayer ()
        {
            this.Player.Character = ( this.Player.Character == BoardPiece.X ) ? BoardPiece.O : BoardPiece.X;
        }
        public bool PromptForNewGame ()
        {
            Message.PrintToConsole( Message.MsgDictionary["PromptForNewGame"] );
            var playAgain = CurrentMove.GetInput();
            return playAgain.Contains( "Y".ToLower() );
        }
    }
}
