using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;
using System;

namespace TicTacTestLibrary
{
    public class GameTests
    {
        private readonly NewGame _newGame;

        public GameTests()
        {
            _newGame = new NewGame();
        }

        [Fact]
        public void GivenANewGame_ReturnsEmptyGameBoard ()
        {
            var expectedGameBoard = new BoardPiece[,] {
                { BoardPiece.None, BoardPiece.None, BoardPiece.None } ,
                { BoardPiece.None , BoardPiece.None , BoardPiece.None } ,
                { BoardPiece.None , BoardPiece.None , BoardPiece.None } };

            Assert.Equal( expectedGameBoard , _newGame.Board.Layout );
        }

        [Fact]
        public void GivenANewGame_ReturnsTheCurrentPlayerAsX()
        {
            var expectedStartPlayer = BoardPiece.X;

            Assert.Equal( expectedStartPlayer , _newGame.Player.Character );
        }
    }
}
