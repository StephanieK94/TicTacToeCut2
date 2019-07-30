using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Messages
    {
        public Dictionary<string , string> dictionary = new Dictionary<string , string>()
        {
            { "Welcome", "Welcome to Tic Tac Toe!\n" + "Here's the current board:\n" },
            { "ResultWasDraw", "\nIt was a Draw! Better luck next time. \n" },
            { "AcceptedMove", "\nMove accepted, here's the current board:\n" },
            { "OutOfBound", "\nOh no, your coordinates were out of the acceptable range. \nRows and Columns are 1,2, or 3 based on the board. Try again...\n"},
            { "InvalidMove",  "\nOh no, a piece is already in this place! Try again...\n" },
            { "InvalidInput", "\nOh no, invalid coordinates. Try entering two numbers for where you would like to play, like this: 1,1\n" },
            { "PromptForNewGame", "\nWould you like to play again? Y / N: " }
        };

        public string PromptForMove(Player currentPlayer)
        {
            return new string( $"\nPlayer {(int) currentPlayer.Character} enter a coord x,y to place your {currentPlayer.Character}: " );
        }

        public string PrintWinner(Player player)
        {
            return new string( $"\nWell done {player.Character}, you won the game!\n" );
        }

        public void PrintToConsole(string message)
        {
            Console.WriteLine( message );
        }
    }
}
