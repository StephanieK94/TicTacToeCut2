using System;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleBoard
    {
        public string[] Layout { get; set; }

        public void PlayMoveOnBoard ( string currentPlayer , int currentMove )
        {
            this.Layout[currentMove] = currentPlayer;
        }

        public bool ValidatePositionIsEmpty ( int currentMove )
        {
            return this.Layout[currentMove] == "";
        }

        public void PrintBoard ()
        {
            var k = 0;
            for ( var row = 0 ; row < 3 ; row++ )
            {
                Console.WriteLine( "" );

                for ( var column = 0 ; column < 3 ; column++ )
                {
                    Console.Write( this.Layout[k] == ""
                        ? " * "
                        : $" {this.Layout[k]} " );
                    k++;
                }

                Console.WriteLine( "" );
            }
        }
    }
}