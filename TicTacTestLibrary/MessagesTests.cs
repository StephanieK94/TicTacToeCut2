using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;
using Xunit;

namespace TicTacTestLibrary
{
    public class MessagesTests
    {
        private readonly NewGame _game;

        public MessagesTests()
        {
            _game = new NewGame();
        }

        [Fact]
        public void GivenPlayerSetAsX_WhenPromptForMoveCalled_ReturnsXAsNumberAndCharacterInMessage ()
        {
            var expectedMessage = "\nPlayer 1 enter a coordinate x,y to place your X: ";
            var actualMessage = _game.Message.PromptForMove( _game.Player.Character );

            Assert.Equal( expectedMessage , actualMessage );
        }

        [Fact]
        public void GivenANewGame_WhenPrintWinnerIsCalled_ReturnsXAsWinner()
        {
            var actualMessage = _game.Message.ReturnWinner( _game.Player.Character.ToString() );
            var expectedMessage = "\nWell done X, you won the game!\n";

            Assert.Equal( expectedMessage , actualMessage );
        }
    }
}
