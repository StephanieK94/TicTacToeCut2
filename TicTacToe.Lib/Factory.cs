using TicTacToe.Lib.Boards;
using TicTacToe.Lib.Messages;
using TicTacToe.Lib.Players;

namespace TicTacToe.Lib
{
    public class Factory
    {
        public static Move CreateNewMove()
        {
            return new Move();
        }

        public static Player CreateConsolePlayer()
        {
            return new Player();
        }

        public static Board CreateConsoleBoard()
        {
            return new Board();
        }

        public static MessageProcessor CreateConsoleMsgProcessor()
        {
            return new MessageProcessor();
        }

        public static WinCalculator CreateConsoleWinCalculator()
        {
            return new WinCalculator();
        }

        public static string[] CreateWebBoard()
        {
            return new string[9];
        }
    }
}
