namespace TicTacToe.Lib
{
    public class Board
    {
        public string[] Layout { get; set; }

        public Board ()
        {
            Layout = new string[] {};
        }

        public void PlayMoveOnBoard(string currentPlayer, int currentMove)
        {
            this.Layout[currentMove] = currentPlayer;
        }

        public bool ValidatePositionIsEmpty(int currentMove)
        {
            return this.Layout[currentMove] == "";
        }
    }
}