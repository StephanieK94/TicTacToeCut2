using static System.String;

namespace TicTacToe.Lib
{
    public class Board
    {
        public string[] Layout { get; set; }

        public Board(string[] layout)
        {
            Layout = layout;
        }

        public void PlayMoveOnBoard(string currentPlayer, int currentMove)
        {
            this.Layout[currentMove] = currentPlayer;
        }

        public bool ValidatePositionIsEmpty(int currentMove)
        {
            return this.Layout[currentMove] == Empty;
        }
    }
}