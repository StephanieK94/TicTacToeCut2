using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using NUnit.Framework.Constraints;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleGame
    {
        public int TurnCount { get; set; }
        public ConsoleBoard Board { get; set; }
        public string CurrentPlayer { get; set; }
        public ConsoleMove Move { get; set; }

        // here are the console specific methods
        public ConsoleWinCalculator WinCalculator { get; set; }

        public ConsoleGame()
        {
            WinCalculator = new ConsoleWinCalculator();
        }

        public bool PlayMove(int currentMove)
        {
            if (this.Board.Layout[currentMove] != "") return false;
            this.Board.Layout[currentMove] = this.CurrentPlayer;
            return true;

        }
        public void StartGame ()
        {
            // Message.PrintToConsole(Message.PrintWelcome());
            // PrintBoard(Board.Layout);
        }
        public bool GetValidMove ()
        {
            //Message.PrintToConsole( Message.PromptForMove( Player.Character ) );
            var input = Move.GetInput();
            return ValidateInput( input );
        }

        public bool ValidateInput ( string playerInput )
        {
            if ( Move.CheckForForfeit( playerInput ) == true )
            {
                ChangePlayer();
                this.WinCalculator.IsWinner = true;
                return true;
            }

            if ( Move.CanConvertPlayerInputToMove( playerInput ) == false )
            {
                // Message.PrintToConsole( Message.MsgDictionary["InvalidInput"] );
                return false;
            }

            if ( ValidateMoveWithinRange( Move ) == false )
            {
                // Message.PrintToConsole( Message.MsgDictionary["OutOfBound"] );
                return false;
            }
            return true;
        }

        public bool ValidateMoveWithinRange ( ConsoleMove userInput )
        {
            return userInput.Position >= 0 && userInput.Position <= 9;
        }

        public bool PromptForNewGame ()
        {
            //Message.PrintToConsole( Message.MsgDictionary["PromptForNewGame"] );
            var playAgain = Move.GetInput();
            return playAgain.ToLower().Contains( "Y".ToLower() );
        }

        public void ChangePlayer()
        {
            this.CurrentPlayer = ( this.CurrentPlayer == "X") ? CurrentPlayer = "O" : CurrentPlayer = "X";
        }
    }
}
