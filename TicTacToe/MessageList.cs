using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Messages
    {
        public string Welcome = new string( "Welcome to Tic Tac Toe!\n" + "Here's the current board:\n" );

        public string ResultWasDraw = new string( "\nIt was a Draw! Better luck next time. \n" );

        public string AcceptedMove = new string( "\nMove accepted, here's the current board:\n" );

        public string OutOfBoundMessage = new string( "\nOh no, your coordinates were out of the acceptable range." + "\nRows and Columns are 1,2, or 3 based on the board. Try again...\n" );

        public string InvalidMoveMessage = new string( "\nOh no, a piece is already in this place! Try again...\n" );

        public string PromptForNewGame = new string( "\nWould you like to play again? Y / N: " );

        public string PromptForMove(Player currentPlayer)
        {
            return  new string( $"\nPlayer {(int) currentPlayer.Character} enter a coord x,y to place your {currentPlayer.Character}: " );
        }

        public string PrintWinner(Player player)
        {
            return new string( $"\nWell done {player.Character}, you won the game!\n" );
        }

    }
}
