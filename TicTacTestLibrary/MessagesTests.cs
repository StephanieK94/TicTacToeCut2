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

        // TODO: add tests for when way to process messages is decided
    }
}
