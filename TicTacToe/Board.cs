using System;

namespace TicTacToe
{
    public class Board
    {
        private BoardPiece[,] _board;

        public BoardPiece[,] layout
        {
            get { return _board; }
            set { _board = value; }
        }

        public Board ()
        {
            layout = new BoardPiece[,] {
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } };
        }

        public void PlayMoveOnBoard(Player currentPlayer, Move currentMove)
        {
            this.layout[currentMove.Row , currentMove.Column] = currentPlayer.Character;
        }

        public bool VaidatePositionIsEmpty(Move currentMove)
        {
            if ( this.layout[currentMove.Row, currentMove.Column] == BoardPiece.Empty ) return true;
            return false;
        }

        public void PrintBoard ( )
        {
            for ( var row = 0 ; row < 3 ; row++ )
            {
                Console.WriteLine( "" );

                for ( var column = 0 ; column < 3 ; column++ )
                {
                    if ( this.layout[row , column] == BoardPiece.Empty ) Console.Write( " * " );
                    else Console.Write( $" {this.layout[row , column]} " );
                }

                Console.WriteLine( "" );
            }
        }
    }
}