namespace TicTacToe.Lib
{
    public class Game
    {
        public int TurnCount { get; set; }
        public Board Board { get; set; }
        public string Player { get; set; }
        public int CurrentMove { get; set; }
        public IWinCalculator WinCalculator { get; set; }

        public Game()
        {
            TurnCount = 0;
            Player = "X";
            CurrentMove = 0;
            Board = Factory.CreateNewGameBoard();
            // Then it is instantiated here specific to this Game, and keeps the Board as a decoupled version? 
            // Same for WinCalculator = Factory.NewGameWinCalculator(); ?? Keeps it more to do with the interface?
        }
    }
}
