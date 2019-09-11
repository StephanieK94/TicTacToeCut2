using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class MessageProcessor
    {
        public Dictionary<string , string> Dictionary = new Dictionary<string , string>()
        {
            { "Welcome", "Welcome to Tic Tac Toe!\n" + "Here's the current board:\n" },
            { "ResultWasDraw", "\nIt was a Draw! Better luck next time. \n" },
            { "AcceptedMove", "\nMove accepted, here's the current board:\n" },
            { "OutOfBound", "\nOh no, your coordinates were out of the acceptable range. \nRows and Columns are 1,2, or 3 based on the board. Try again...\n"},
            { "InvalidMove",  "\nOh no, a piece is already in this place! Try again...\n" },
            { "InvalidInput", "\nOh no, invalid coordinates. Try entering two numbers for where you would like to play, like this: 1,1\n" },
            { "PromptForNewGame", "\nWould you like to play again? Y / N: " }
        };

        public string PromptForMove(BoardPiece player)
        {
            return new string( $"\nPlayer {player} enter a coordinate x,y to place your {player}: " );
        }

        public string ReturnWinner(BoardPiece player)
        {
            return new string( $"\nWell done {player}, you won the game!\n" );
        }

        public void PrintToConsole(string message)
        {
            Console.WriteLine( message );
        }
    }
}
