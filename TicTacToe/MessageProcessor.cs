using System;
using System.Collections.Generic;

namespace TicTacToe.ConsoleApplication
{
    public class MessageProcessor 
    {
        // TODO: Refactor these into text files
        public Dictionary<string , string> MsgDictionary = new Dictionary<string , string>()
        {
            { "AcceptedMove", "\nMove accepted, here's the current board:\n" },
            { "OutOfBound", "\nOh no, your coordinates were out of the acceptable range. \nRows and Columns are 1,2, or 3 based on the board. Try again...\n"},
            { "InvalidMove",  "\nOh no, a piece is already in this place! Try again...\n" },
            { "InvalidInput", "\nOh no, invalid coordinates. Try entering two numbers for where you would like to play, like this: 1,1\n" },
            { "PromptForNewGame", "\nWould you like to play again? Y / N: " }
        };

        public string PromptForMove(string player)
        {
            return $"\nPlease enter a coordinate x,y to place your {player}: ";
        }

        public string PrintWelcome()
        {
            return "Welcome to Tic Tac Toe!\n" + "Here's the current board:\n";
        }

        public string ReturnWinner(string player)
        {
            return $"\nWell done {player}, you won the game!\n";
        }

        public string ReturnDraw()
        {
           return "\nIt was a Draw! Better luck next time. \n";
        }

        public void PrintToConsole(string message)
        {
            Console.WriteLine( message );
        }
    }
}
