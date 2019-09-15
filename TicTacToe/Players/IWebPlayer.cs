namespace TicTacToe.Players
{
    public interface IWebPlayer
    {
        string Piece { get; set; }
        void ChangePlayer();
    }
}