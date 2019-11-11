using System;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleMove
    {
        private int _row;
        private int _column;
        public int Row
        {
            set { _row = value - 1; } get { return _row; }
        }

        public int Column
        {
             set { _column = value - 1; } get { return _column; }
        }
        public int Position { get; set; }
        
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
