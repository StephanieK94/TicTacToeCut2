namespace TicTacToe.Lib
{
    public interface IWinCalculator
    {
        bool IsWinner { get; set; }
        void CalculateWinner(string[] layout);
    }
}