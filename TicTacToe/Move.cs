using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Move
    {
        private int _row;
        private int _column;
        public int Row
        {
            get { return _row; }
            set { _row = value - 1; }
        }

        public int Column
        {
            get { return _column; }
            set { _column = value - 1; }
        }

        public void SetPosition(Move newMove)
        {
            this.Row = newMove.Row;
            this.Column = newMove.Column;
        }

        public void ConvertPlayerInputToMove(string userString)
        {
            var input = userString.Split( ',' );

            this.Row = Convert.ToInt32( input[0] );
            this.Column = Convert.ToInt32( input[1] );
        }

        public bool ValidatePlayerMoves(Move userInput)
        {
            if ( userInput.Row < 0 || userInput.Row > 2 ) return false;
            if ( userInput.Column < 0 || userInput.Column > 2 ) return false;
            return true;
        }

        public bool CheckForForfeit(string userInput)
        {
            if ( userInput.Contains( "Q" ) || userInput.Contains( "q" ) ) return true;
            return false;
        }
    }
}
