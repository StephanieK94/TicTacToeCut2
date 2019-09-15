namespace TicTacToe
{
    public interface IPlayer
    {
        BoardPiece Character { get; set; }
        void ChangePlayer();
    }
}