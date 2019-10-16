using TicTacToe.ConsoleApplication;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class MessagesTests
    {
        private readonly ConsoleGameModel _game;
        private TicTacService service ;

        public MessagesTests()
        {
            service = new TicTacService();
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
