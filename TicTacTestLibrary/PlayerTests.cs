using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;

namespace TicTacTestLibrary
{
    public class PlayerTests
    {
        private readonly Player _player;

        public PlayerTests()
        {
            _player = new Player();
        }

        [Fact]
        public void GivenNewPlayer_ReturnsDefaultCharacterAsX()
        {
            Assert.Equal(BoardPiece.X, _player.Character);
        }

        [Theory]
        [InlineData(BoardPiece.X, BoardPiece.O)]
        [InlineData(BoardPiece.O, BoardPiece.X)]
        [InlineData(BoardPiece.None, BoardPiece.X)]
        public void GivenCurrentPlayer_WhenChangedPlayerCalled_ReturnExpectedPlayer(BoardPiece currentPlayer, BoardPiece expectedPlayer)
        {
            _player.Character = currentPlayer;
            _player.ChangePlayer();

            Assert.Equal(expectedPlayer, _player.Character);
        }
    }
}
