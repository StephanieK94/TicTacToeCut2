using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;
using System;
using TicTacToe.Games;
using TicTacToe.Players;

namespace TicTacTestLibrary
{
    public class GameTests
    {
        private readonly ConsoleGame _newGame;

        public GameTests()
        {
            _newGame = new ConsoleGame();
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

            Assert.Equal( expectedStartPlayer , Factory.CreateConsolePlayer().Character );
        }
    }
}
