using System;

namespace TicTacToe
{
    public class Board
    {
        private BoardPiece[,] _board;

        public BoardPiece[,] board
        {
            get { return _board; }
            set { _board = value; }
        }

        public Board ()
        {
            board = new BoardPiece[,] {
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } };
        }

        public void PlayMoveOnBoard(Player currentPlayer, Move currentMove)
        {
            this.board[currentMove.Row , currentMove.Column] = currentPlayer.Character;
        }

        public bool VaidatePositionIsEmpty(Move currentMiove)
        {
            if ( this.board[currentMiove.Row, currentMiove.Column] == BoardPiece.Empty ) return true;
            return false;
        }

        public void PrintBoard ( )
        {
            for ( var row = 0 ; row < 3 ; row++ )
            {
                Console.WriteLine( "" );

                for ( var column = 0 ; column < 3 ; column++ )
                {
                    if ( this.board[row , column] == BoardPiece.Empty ) Console.Write( " * " );
                    else Console.Write( $" {this.board[row , column]} " );
                }

                Console.WriteLine( "" );
            }
        }
    }
}