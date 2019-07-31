using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;

namespace TicTacTestLibrary
{
    public class PlayerTests
    {
        private readonly Player player;

        public PlayerTests()
        {
            player = new Player();
        }

        [Fact]
        public void GivenNewPlayer_ReturnsDefaultCharacterAsX()
        {
            Assert.Equal(BoardPiece.X, player.Character);
        }

        [Theory]
        [InlineData(BoardPiece.X, BoardPiece.O)]
        [InlineData(BoardPiece.O, BoardPiece.X)]
        [InlineData(BoardPiece.Empty, BoardPiece.X)]
        public void GivenCurrentPlayer_WhenChangedPlayerCalled_ReturnExpectedPlayer(BoardPiece currentPlayer, BoardPiece expectedPlayer)
        {
            player.Character = currentPlayer;
            player.ChangePlayer();

            Assert.Equal(expectedPlayer, player.Character);
        }
    }
}
