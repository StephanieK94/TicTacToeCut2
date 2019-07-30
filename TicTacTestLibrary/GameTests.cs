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
        public void GivenNewGame_ReturnsEmptyGameboard ()
        {
            NewGame game = new NewGame();
            var expectedGameboard = new BoardPiece[,] {
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } ,
                { BoardPiece.Empty , BoardPiece.Empty , BoardPiece.Empty } };

            Assert.Equal( expectedGameboard , game.board.board );
        }

        [Fact]
        public void GivenNewGame_ReturnsCurrentPlayerX()
        {
            NewGame game = new NewGame();
            var expectedStartPlayer = BoardPiece.X;

            Assert.Equal( expectedStartPlayer , game.currentPlayer.Character );
        }

        [Fact]
        public void GivenNewGame_ReturnsnextMoveAsZero()
        {
            NewGame game = new NewGame();

            Assert.Equal( 0 , game.nextMove.Row );
            Assert.Equal( 0 , game.nextMove.Column );
        }
    }
}
