using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class WinCalculator
    {
        private BoardPiece[,] _board;
        public BoardPiece[,] board
        {
            get { return _board; }
            set { _board = value; }
        }

        private bool WinRow { get; set; }
        private bool WinColumn { get; set; }
        private bool WinDiagonal { get; set; }
        private bool WinRevDiagonal { get; set; }

        public bool IsWinner { get; set; }

        public void WinnerCalculator ( BoardPiece[,] currentBoard )
        {
            board = currentBoard;

            WinRow = false;
            WinColumn = false;
            WinDiagonal = false;

            this.IsWinner = false;

            CheckRows();
            CheckColumns();
            CheckDiagonals();

            this.IsWinner = ( WinRow || WinColumn || WinDiagonal );
        }


        private void CheckRows ( )
        {
            for(var row =0 ; row <=2 ; row++ )
            {
                var middleField = board[row , 1];
                if ( middleField == BoardPiece.Empty ) continue;

                if ( board[row , 0] == middleField && board[row , 2] == middleField )
                {
                    WinRow = true;
                    break;
                }
            }
        }

        private void CheckColumns ( )
        {
            for ( var column = 0 ; column <= 2 ; column++ )
            {
                var middleField = board[1, column];
                if ( middleField == BoardPiece.Empty ) continue;

                if ( board[0, column] == middleField && board[2, column] == middleField )
                {
                    WinColumn = true;
                    break;
                }
            }
        }

        private void CheckDiagonals ( )
        {
            var middleField = board[1 , 1];
            if ( middleField != BoardPiece.Empty )
            {
                if ( board[1 , 1] == middleField && board[2 , 2] == middleField )
                {
                    WinDiagonal = true;
                }
                else if ( board[0 , 2] == middleField && board[2 , 0] == middleField )
                {
                    WinDiagonal = true;
                }
            }
        }
    }
}
