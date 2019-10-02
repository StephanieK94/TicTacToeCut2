using TicTacToe.ConsoleApplication;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class MessagesTests
    {
        private readonly ConsoleGame _game;

        public MessagesTests()
        {
            var service = new TicTacService();
            _game = service.NewGame();
        }

        [Fact]
        public void WhenWelcomeMessageCalled_ReturnsExpectedString()
        {
            var dict = _game.Message.ConsoleMessages;
            var actual = dict["AcceptedMove"];
        
            Assert.Equal( "Move accepted here's the current board:", actual);
        }
    }
}
