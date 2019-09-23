using TicTacToe.ConsoleApplication;
using TicTacToe.ConsoleApplication.Boards;
using TicTacToe.ConsoleApplication.Messages;
using TicTacToe.ConsoleApplication.Players;

namespace TicTacToe.ConsoleApplication
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
