using System;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleBoard
    {
        public string[] Layout { get; set; }

        public ConsoleBoard(string[] layout)
        {
            Layout = layout;
        }

        public void PlayMoveOnBoard ( string currentPlayer , int currentMove )
        {
            this.Layout[currentMove] = currentPlayer;
        }

        public bool ValidatePositionIsEmpty ( int currentMove )
        {
            return this.Layout[currentMove] == "";
        }
    }
}