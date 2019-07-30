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
            NewGame game = new NewGame();

            var expectedMsg = "\nPlayer 1 enter a coord x,y to place your X: ";
            var actualMsg = game.messages.PromptForMove( game.currentPlayer );

            Assert.Equal( expectedMsg , actualMsg );
        }

        [Fact]
        public void GivenNewGame_WhenPrintWinnerCalled_PrintsXAsWinner()
        {
            NewGame game = new NewGame();

            var actual = game.messages.PrintWinner( game.currentPlayer );
            var expectedString = "\nWell done X, you won the game!\n";

            Assert.Equal( expectedString , actual );
        }
    }
}
