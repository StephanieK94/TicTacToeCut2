using TicTacToe.ConsoleApplication.Players;
using System;
using TicTacToe.ConsoleApplication.Messages;

namespace TicTacToe.ConsoleApplication.Boards
{
    public class Board
    {
        public BoardPiece[,] Layout { get; set; }

        public Board ()
        {
            Layout = new BoardPiece[,] {
                { BoardPiece.None, BoardPiece.None, BoardPiece.None } ,
                { BoardPiece.None , BoardPiece.None , BoardPiece.None } ,
                { BoardPiece.None , BoardPiece.None , BoardPiece.None } };
        }

        public void PlayMoveOnBoard(Player currentPlayer, Move currentMove)
        {
            this.Layout[currentMove.Row , currentMove.Column] = currentPlayer.Character;
        }

        public bool ValidatePositionIsEmpty(Move currentMove)
        {
            if ( this.Layout[currentMove.Row, currentMove.Column] == BoardPiece.None ) return true;
            return false;
        }

        public void PrintBoard ( )
        {
            for ( var row = 0 ; row < 3 ; row++ )
            {
                Console.WriteLine( "" );

                for ( var column = 0 ; column < 3 ; column++ )
                {
                   Console.Write(this.Layout[row, column] == BoardPiece.None
                        ? " * "
                        : $" {this.Layout[row, column]} ");
                }

                Console.WriteLine( "" );
            }
        }
    }
}