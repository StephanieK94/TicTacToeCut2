using TicTacToe.ConsoleApplication;
using TicTacToe.ConsoleApplication.Games;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class MessagesTests
    {
        private readonly ConsoleGame _game;

        public MessagesTests()
        {
            _game = new ConsoleGame();
        }

        [Fact]
        public void GivenPlayerSetAsX_WhenPromptForMoveCalled_ReturnsXAsNumberAndCharacterInMessage ()
        {
            var expectedMessage = "\nPlayer 1 enter a coordinate x,y to place your X: ";
            var actualMessage = _game.Message.PromptForMove( Factory.CreateConsolePlayer().Character );

            Assert.Equal( expectedMessage , actualMessage );
        }

        [Fact]
        public void GivenANewGame_WhenPrintWinnerIsCalled_ReturnsXAsWinner()
        {
            var actualMessage = _game.Message.ReturnWinner( Factory.CreateConsolePlayer().Character.ToString() );
            var expectedMessage = "\nWell done X, you won the game!\n";

            Assert.Equal( expectedMessage , actualMessage );
        }
    }
}
