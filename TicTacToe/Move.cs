using System;

namespace TicTacToe.ConsoleApplication
{
    public class Move
    {
        private int _row;
        private int _column;
        public int Row
        {
            get => _row;
            set => _row = value - 1;
        }

        public int Column
        {
            get => _column;
            set => _column = value - 1;
        }

        public string GetInput ()
        {
            var input = System.Console.ReadLine();
            return input;
        }

        public bool CheckForForfeit ( string userInput )
        {
            return userInput.Contains( "Q" ) || userInput.Contains( "q" );
        }

        public bool ConvertPlayerInputToMove ( string userString )
        {
            try
            {
                var input = userString.Split( ',' );

                this._row = Convert.ToInt32( input[0] );
                this._column = Convert.ToInt32( input[1] );

                return true;
            }
            catch ( FormatException )
            {
                return false;
            }
        }
    }
}
