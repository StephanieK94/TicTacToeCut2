using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class Factory
    {
        public static ConsoleMove CreateNewConsoleMove()
        {
            return new ConsoleMove();
        }

        public static ConsoleWinCalculator CreateConsoleWinCalculator()
        {
            return new ConsoleWinCalculator();
        }

        public static string[] CreateConsoleBoardLayout()
        {
            return new string[9] { "" , "" , "" , "" , "" , "" , "" , "" , "" };
        }

        public static ConsoleWriter CreateConsoleWriter()
        {
            return new ConsoleWriter();
        }

        public static ConsoleReader CreateConsoleReader()
        {
            return new ConsoleReader();
        }

        public static Messages CreateMessageList()
        {
            return new Messages();
        }
    }
}
