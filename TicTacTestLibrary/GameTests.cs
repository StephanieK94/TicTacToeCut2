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
            Game game = new Game();
            var expectedGameboard = new BoardPiece[,] {
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } };

            Assert.Equal(expectedGameboard, game.board.board);
        }

        [Fact]
        public void GivenNameGame_WinnerAsCurrentPlayerExpectedX()
        {
            Game game = new Game();
            var expectedWinner = BoardPiece.X;

            game.StartGame();
            Assert.Equal( expectedWinner , game.currentPlayer.Character );
        }
    }
}
