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
            return new ConsoleBoard(CreateConsoleBoardLayout());
        }

        public static MessageProcessor CreateConsoleMsgProcessor()
        {
            return new MessageProcessor();
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
    }
}
