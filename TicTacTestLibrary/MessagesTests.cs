using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe;
using Xunit;

namespace TicTacTestLibrary
{
    public class MessagesTests
    {
        [Fact]
        public void GivenPlayerX_WhenPromptForMoveCalled_ReturnsPlayerXEnumInMsg ()
        {
            Game game = new Game();

            var expectedMsg = "\nPlayer 1 enter a coord x,y to place your X: ";
            var actualMsg = game.msg.PromptForMove( game.currentPlayer );

            Assert.Equal( expectedMsg , actualMsg );
        }

        [Fact]
        public void GivenNewGame_WhenPrintWinnerCalled_PrintsXAsWinner()
        {
            Game game = new Game();

            var actual = game.msg.PrintWinner( game.currentPlayer );
            var expectedString = "\nWell done X, you won the game!\n";

            Assert.Equal( expectedString , actual );
        }
    }
}
