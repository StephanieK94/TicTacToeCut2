using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;

namespace TicTacTestLibrary
{
    public class GameTests
    {
        [Fact]
        public void GivenNewGame_ReturnsEmptyGameboard()
        {
            Game game = new TicTacToe.Game();
            var expectedGameboard = new string[,] { { "", "", "" }, { "", "", "" }, { "", "", "" }};

            Assert.Equal(expectedGameboard, game.board);
        }
    }
}
