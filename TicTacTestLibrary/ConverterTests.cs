using TicTacToe.ConsoleApplication.Boards;
using TicTacToe.ConsoleApplication.Converters;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class ConverterTests
    {
        readonly BoardConverter _converter = new BoardConverter();

        [Fact]
        public void GivenAConsoleBoard_WillReturn_AStringArray()
        {
            var consoleBoard = new Board();
            var apiBoard = _converter.ConvertConsoleBoardToWebApiBoard(consoleBoard.Layout);
            var expected = new string[9]{"", "" , "" , "" , "" , "" , "" , "" , ""};
            Assert.Equal(expected,apiBoard);
        }

        [Fact]
        public void GivenAWebApiBoard_WhenConverted_ReturnsABoardPieceBoard()
        {
            var apiBoard = new string[9] {"", "", "", "", "", "", "", "", ""};
            var consoleBoard = _converter.ConvertWebApiBoardToConsoleBoard(apiBoard);
            var expected = new Board();
            Assert.Equal(expected.Layout, consoleBoard);
        }
    }
}
