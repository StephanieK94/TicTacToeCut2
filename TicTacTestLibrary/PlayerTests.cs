using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;

namespace TicTacTestLibrary
{
    public class PlayerTests
    {
        [Fact]
        public void GivenNewPlayer_ReturnsXForCharacter()
        {
            Player player1 = new Player();

            Assert.Equal("X", player1.Character);
        }
    }
}
