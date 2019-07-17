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
        public void GivenNewPlayer_ReturnsXForDefaultCharacter()
        {
            Player player1 = new Player();

            Assert.Equal(BoardPiece.X, player1.Character);
        }

        [Theory]
        [InlineData(BoardPiece.X, BoardPiece.O)]
        [InlineData(BoardPiece.O, BoardPiece.X)]
        [InlineData(BoardPiece.Empty, BoardPiece.X)]
        public void GivenCurrentPlayer_WhenChangedPlayerCalled_ReturnOtherPlayer(BoardPiece current, BoardPiece expected)
        {
            Player player = new Player();

            player.Character = current;

            player.ChangePlayer();

            Assert.Equal(expected, player.Character);
        }
    }
}
