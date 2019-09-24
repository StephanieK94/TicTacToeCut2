namespace TicTacToe.Lib
{
    public class WinCalculator
    {
        public BoardPiece[,] Board { get; set; }

        private bool WinRow { get; set; }
        private bool WinColumn { get; set; }
        private bool WinDiagonal { get; set; }
        private bool WinRevDiagonal { get; set; }

        public bool IsWinner { get; set; }

        public void WinnerCalculator ( BoardPiece[,] currentBoard )
        {
            Board = currentBoard;

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
                var middleField = Board[row , 1];
                if ( middleField == BoardPiece.None ) continue;

                if ( Board[row , 0] == middleField && Board[row , 2] == middleField )
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
                var middleField = Board[1, column];
                if ( middleField == BoardPiece.None ) continue;

                if ( Board[0, column] == middleField && Board[2, column] == middleField )
                {
                    WinColumn = true;
                    break;
                }
            }
        }

        private void CheckDiagonals ( )
        {
            var middleField = Board[1 , 1];
            if ( middleField != BoardPiece.None )
            {
                if ( Board[0 , 0] == middleField && Board[2 , 2] == middleField )
                {
                    WinDiagonal = true;
                }
                else if ( Board[0 , 2] == middleField && Board[2 , 0] == middleField )
                {
                    WinDiagonal = true;
                }
            }
        }
    }
}
