using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Lib;

namespace TicTacToeCut2.Api.Models
{
    public class WinCalculator : IWinCalculator
    {
        public bool IsWinner { get ; set; }

        public void CalculateWinner(string[] layout)
        {
            IsWinner = false;

            if (CheckTopLeftCorner(layout) == true ||
                CheckMiddlePoint(layout) == true ||
                CheckBottomLeftCorner(layout) == true) IsWinner = true;
        }

        private bool CheckTopLeftCorner(string[] board)
        {
            return ( board[0] != "" &&
                     (board[0] == board[1] && board[0] == board[2]
                      || board[0] == board[3] && board[0] == board[6]));
        }
        private bool CheckBottomLeftCorner(string[] board)
        {
            return ( board[8] != "" &&
                        (board[8] == board[6] && board[8] == board[7]
                        || board[8] == board[2] && board[8] == board[5]));
        }
        private bool CheckMiddlePoint(string[] board)
        {
            return ( board[4] != "" &&
                          (board[4] == board[0] && board[4] == board[8]
                           || board[4] == board[2] && board[4] == board[6]
                           || board[4] == board[1] && board[4] == board[7]
                           || board[4] == board[3] && board[4] == board[5]));
        }
    }
}
