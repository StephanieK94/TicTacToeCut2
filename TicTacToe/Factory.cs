using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class Factory
    {
        public static ConsoleMove CreateNewConsoleMove()
        {
            return new ConsoleMove();
        }

        public static ConsoleBoard CreateConsoleBoard()
        {
            return new ConsoleBoard();
        }

        public static MessageProcessor CreateConsoleMsgProcessor()
        {
            return new MessageProcessor();
        }

        public static ConsoleWinCalculator CreateConsoleWinCalculator()
        {
            return new ConsoleWinCalculator();
        }
    }
}
