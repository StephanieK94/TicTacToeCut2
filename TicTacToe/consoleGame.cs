using System;
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
        public ConsoleMove CurrentMove { get; set; }

        // here are the console specific methods
        public ConsoleWinCalculator WinCalculator { get; set; }
        public ConsoleWriter ConsoleWriter { get; set; }

        public ConsoleGame()
        {
            TurnCount = 0;
            Board = Factory.CreateConsoleBoard();
            CurrentPlayer = "";
            CurrentMove = Factory.CreateNewConsoleMove();
            WinCalculator = new ConsoleWinCalculator(); // TODO: Factory this
            ConsoleWriter = new ConsoleWriter();
        }

        public bool PlayMove(int currentMove)
        {
            if (this.Board.Layout[currentMove] != "") return false;
            this.Board.Layout[currentMove] = this.CurrentPlayer;
            return true;
            // TODO: Remove this. ?
        }
        public void StartGame ()
        {
            // Message.PrintToConsole(Message.PrintWelcome());
            // PrintBoard(Board.Layout);
        }

        public bool ValidateInput ( string playerInput )
        {
            if ( CurrentMove.CheckForForfeit( playerInput ) == true )
            {
                ChangePlayer();
                this.WinCalculator.IsWinner = true;
                return true;
            }

            if ( CurrentMove.CanConvertPlayerInputToMove( playerInput ) == false )
            {
                // Message.PrintToConsole( Message.MsgDictionary["InvalidInput"] );
                return false;
            }

            if ( CurrentMove.ValidateMoveWithinRange() == false )
            {
                // Message.PrintToConsole( Message.MsgDictionary["OutOfBound"] );
                return false;
            }
            CurrentMove.ConvertToPosition();
            return true;
        }

       

        public bool PromptForNewGame ()
        {
            //Message.PrintToConsole( Message.MsgDictionary["PromptForNewGame"] );
            var playAgain = CurrentMove.GetInput();
            return playAgain.ToLower().Contains( "Y".ToLower() );
        }

        public void ChangePlayer()
        {
            this.CurrentPlayer = ( this.CurrentPlayer == "X") ? CurrentPlayer = "O" : CurrentPlayer = "X";
        }
    }

    public class ConsoleWriter
    {
        public void WriteToConsole(string text)
        {
            Console.WriteLine(text);
        }
    }
}
