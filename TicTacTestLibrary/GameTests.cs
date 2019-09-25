using TicTacToe.ConsoleApplication;
using TicTacToe.ConsoleApplication.Games;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class GameTests
    {
        private readonly ConsoleGame _newGame;

        public GameTests()
        {
            _newGame = new ConsoleGame();
        }

        [Fact]
        public void GivenANewGame_ReturnsEmptyGameBoard ()
        {
            var expectedGameBoard = new BoardPiece[,] {
                { BoardPiece.None, BoardPiece.None, BoardPiece.None } ,
                { BoardPiece.None , BoardPiece.None , BoardPiece.None } ,
                { BoardPiece.None , BoardPiece.None , BoardPiece.None } };

            Assert.Equal( expectedGameBoard , _newGame.Board.Layout );
        }

        [Fact]
        public void GivenANewGame_ReturnsTheCurrentPlayerAsX()
        {
            var expectedStartPlayer = BoardPiece.X;

            Assert.Equal( expectedStartPlayer , Factory.CreateConsolePlayer().Character );
        }
    }
}
