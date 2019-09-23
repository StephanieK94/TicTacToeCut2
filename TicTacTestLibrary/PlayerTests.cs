using TicTacToe.ConsoleApplication;
using TicTacToe.ConsoleApplication.Games;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class PlayerTests
    {
        private readonly ConsoleGame _game;

        public PlayerTests()
        {
            _game = new ConsoleGame();
        }

        [Fact]
        public void GivenNewPlayer_ReturnsDefaultCharacterAsX()
        {
            Assert.Equal(BoardPiece.X, _game.Player.Character);
        }

        [Theory]
        [InlineData(BoardPiece.X, BoardPiece.O)]
        [InlineData(BoardPiece.O, BoardPiece.X)]
        [InlineData(BoardPiece.None, BoardPiece.X)]
        public void GivenCurrentPlayer_WhenChangedPlayerCalled_ReturnExpectedPlayer(BoardPiece currentPlayer, BoardPiece expectedPlayer)
        {
            _game.Player.Character = currentPlayer;
            _game.ChangePlayer();

            Assert.Equal(expectedPlayer, _game.Player.Character);
        }
    }
}
