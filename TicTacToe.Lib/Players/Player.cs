namespace TicTacToe.Lib.Players
{
    public class Player
    {
        public BoardPiece Character { get; set; }

        // Default constructor for Player to be an X when the game starts
        public Player()
        {
            Character = BoardPiece.X;
        }
    }
}
