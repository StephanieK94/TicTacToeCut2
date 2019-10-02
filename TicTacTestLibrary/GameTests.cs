using System;
using TicTacToe.ConsoleApplication;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class GameTests
    {
        private readonly ConsoleGame _newGame;

        public GameTests()
        {
            var service = new TicTacService();
            _newGame = service.NewGame();
        }

        [Fact]
        public void GivenANewGame_ReturnsEmptyGameBoard ()
        {
            var expectedGameBoard = new string[9]{ "", "" , "" , "" , "" , "" , "" , "" , "" };

            Assert.Equal( expectedGameBoard , _newGame.Board.Layout );
        }

        [Fact]
        public void GivenANewGame_ReturnsTheCurrentPlayerAsX()
        {
            Assert.Equal( "X" , _newGame.CurrentPlayer );
        }
    }
}
