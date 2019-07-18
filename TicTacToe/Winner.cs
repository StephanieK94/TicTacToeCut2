using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class WinCalculator
    {
        public bool WinRow { get; set; }
        public bool WinColumn { get; set; }
        public bool WinDiagonal { get; set; }
        public bool WinRevDiagonal { get; set; }

        public bool IsWinner { get; set; }

        public void WinnerCalculator ( Player player , BoardPiece[,] board, Move lastMove )
        {
            WinRow = true;
            WinColumn = true;
            WinDiagonal = true;
            WinRevDiagonal = true;
            IsWinner = false;

            for ( var i = 0 ; i <= 2 ; i++ )
            {
                if ( board[lastMove.Row , i] != player.Character ) this.WinRow = false;
                if ( board[i , lastMove.Column] != player.Character ) this.WinColumn = false;
                if ( board[i , i] != player.Character ) this.WinDiagonal = false;
                if ( board[i , ( 3 - 1 - i )] != player.Character ) this.WinRevDiagonal = false;
            }

            this.IsWinner = ( WinRow || WinColumn || WinDiagonal || WinRevDiagonal );
        }
    }
}
