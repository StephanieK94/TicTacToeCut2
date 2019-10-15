using TicTacToe.ConsoleApplication;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class MessagesTests
    {
        private readonly consoleGame _game;

        public MessagesTests()
        {
            var service = new TicTacService();
            _game = service.NewGame();
        }

        [Fact]
        public void WhenWelcomeMessageCalled_ReturnsExpectedString()
        {
            var msg = _game.Message.AcceptedMove();
        
            Assert.Equal( "Move accepted here's the current board:", msg);
        }
    }
}
