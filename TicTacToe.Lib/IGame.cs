namespace TicTacToe.Lib
{
    public interface IGame
    {
        string[] Board { get; set; }
        int CurrentMove { get; set; }
        string Player { get; set; }
        IWinCalculator WinCalculator { get; set; }
    }
}