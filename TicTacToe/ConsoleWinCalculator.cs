using System;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleWinCalculator : IWinCalculator
    {
        public string[] Board { get; set; }
        private bool TopCnr { get; set; }
        private bool BottomCnr { get; set; }
        private bool Middle { get; set; }


        private void CheckTopLeftCorner ()
        {
            TopCnr = Board[0] != "" && 
                     (Board[0] == Board[1] && Board[0] == Board[2]
                      || Board[0] == Board[3] && Board[0] == Board[6]);
        }
        private void CheckBottomLeftCorner ()
        {
            BottomCnr = Board[8] != "" &&
                        ( Board[8] == Board[6] && Board[8] == Board[7]
                        || Board[8] == Board[2] && Board[8] == Board[5] );
        }
        private void CheckMiddlePoint ()
        {
            Middle = Board[4] != "" &&
                          (Board[4] == Board[0] && Board[4] == Board[8]
                           || Board[4] == Board[2] && Board[4] == Board[6]
                           || Board[4] == Board[1] && Board[4] == Board[7]
                           || Board[4] == Board[3] && Board[4] == Board[5]);
        }
        
        // From the interface
        public bool IsWinner { get; set; }
        public void CalculateWinner (string[] layout )
        {
            this.Board = layout;

            IsWinner = false;

            TopCnr = false;
            BottomCnr = false;
            Middle = false;

            CheckTopLeftCorner();
            CheckBottomLeftCorner();
            CheckMiddlePoint();

            this.IsWinner = TopCnr || BottomCnr || Middle;
        }
    }
}
