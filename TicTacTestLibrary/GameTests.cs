using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;

namespace TicTacTestLibrary
{
    public class GameTests
    {
        private readonly NewGame newGame;

        public GameTests()
        {
            newGame = new NewGame();
        }

        [Fact]
        public void GivenANewGame_ReturnsEmptyGameboard ()
        {
            var expectedGameboard = new BoardPiece[,] {
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } };

            Assert.Equal( expectedGameboard , newGame.board.layout );
        }

        [Fact]
        public void GivenANewGame_ReturnsTheCurrentPlayerAsX()
        {
            var expectedStartPlayer = BoardPiece.X;

            Assert.Equal( expectedStartPlayer , newGame.currentPlayer.Character );
        }

        [Fact]
        public void GivenANewGame_ReturnsTheNextMoveSetToZero()
        {
            Assert.Equal( 0 , newGame.nextMove.Row );
            Assert.Equal( 0 , newGame.nextMove.Column );
        }
    }
}
