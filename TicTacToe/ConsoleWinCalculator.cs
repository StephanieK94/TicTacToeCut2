using System;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleWinCalculator : IWinCalculator
    {
        public string[] Board { get; set; }
        private bool WinRow { get; set; }
        private bool WinColumn { get; set; }
        private bool WinDiagonal { get; set; }


        private void CheckRows ()
        {
            WinRow = Board[0] == Board[1] && Board[0] == Board[2]
                     || Board[0] == Board[3] && Board[0] == Board[6];
        }
        private void CheckColumns ()
        {
            WinColumn = Board[8] == Board[6] && Board[8] == Board[7] 
                        || Board[8] == Board[2] && Board[8] == Board[5];
        }
        private void CheckDiagonals ()
        {
            WinDiagonal = Board[4] == Board[0] && Board[4] == Board[8]
                          || Board[4] == Board[2] && Board[4] == Board[6]
                          || Board[4] == Board[1] && Board[4] == Board[7]
                          || Board[4] == Board[3] && Board[4] == Board[5];
        }
        
        // From the interface
        public bool IsWinner { get; set; } = false;
        public void CalculateWinner (string[] layout )
        {
            this.Board = layout;

            WinRow = false;
            WinColumn = false;
            WinDiagonal = false;

            CheckRows();
            CheckColumns();
            CheckDiagonals();

            // TODO: Refactor this to just check the winner, remove all other stuff

            this.IsWinner = ( WinRow || WinColumn || WinDiagonal );
        }
    }
}
