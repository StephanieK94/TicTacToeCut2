using TicTacToe.ConsoleApplication;
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
            var expectedGameBoard = new string[]{};

            Assert.Equal( expectedGameBoard , _newGame.Board.Layout );
        }

        [Fact]
        public void GivenANewGame_ReturnsTheCurrentPlayerAsX()
        {
            var expectedStartPlayer = "X";

            Assert.Equal( expectedStartPlayer , _newGame.CurrentPlayer );
        }
    }
}
