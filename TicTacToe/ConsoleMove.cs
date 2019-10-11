using System;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleMove
    {
        private int _row;
        private int _column;

        public int Position { get; set; }

        public bool CheckForForfeit ( string userInput )
        {
            return userInput.Contains( "Q" ) || userInput.Contains( "q" );
        }

        public bool CanConvertPlayerInputToMove ( string userString )
        {
            try
            {
                var input = userString.Split( ',' );

                this._row = Convert.ToInt32( input[0] ) -1;
                this._column = Convert.ToInt32( input[1] ) -1;

                return true;
            }
            catch ( FormatException )
            {
                return false;
            }
        }

        public bool ValidateMoveWithinRange ()
        {
            if ( _row < 0 || _row > 2 ) return false;
            return _column >= 0 && _column <= 2;
        }

        public void ConvertToPosition()
        {
            switch (this._row)
            {
                case 0:
                    switch (this._column)
                    {
                        case 0:
                            Position = 0;
                            break;
                        case 1:
                            Position = 1;
                            break;

                        case 2:
                            Position = 2;
                            break;
                    }
                    break;
                case 1:
                    switch ( this._column )
                    {
                        case 0:
                            Position = 3;
                            break;
                        case 1:
                            Position = 4;
                            break;
                        case 2:
                            Position = 5;
                            break;
                    }
                    break;
                case 2:
                    switch ( this._column )
                    {
                        case 0:
                            Position = 6;
                            break;
                        case 1:
                            Position = 7;
                            break;
                        case 2:
                            Position = 8;
                            break;
                    }
                    break;
            }
        }
    }
}
