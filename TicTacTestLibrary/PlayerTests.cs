using TicTacToe.ConsoleApplication;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class PlayerTests
    {
        private readonly ConsoleGame _game;

        public PlayerTests()
        {
            var service = new TicTacService();
            _game = service.NewGame();
        }

        [Fact]
        public void GivenNewPlayer_ReturnsDefaultCharacterAsX()
        {
            Assert.Equal("X", _game.CurrentPlayer);
        }

        [Theory]
        [InlineData("X", "O")]
        [InlineData("O", "X")]
        [InlineData("", "X")]
        public void GivenCurrentPlayer_WhenChangedPlayerCalled_ReturnExpectedPlayer(string currentPlayer, string expectedPlayer)
        {
            _game.CurrentPlayer = currentPlayer;
            _game.ChangePlayer();

            Assert.Equal(expectedPlayer, _game.CurrentPlayer);
        }
    }
}
