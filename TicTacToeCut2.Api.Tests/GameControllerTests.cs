using FluentAssertions;
using System;
using System.Collections.Generic;
using TicTacToeCut2.Api.Controllers;
using TicTacToeCut2.Api.Models;
using Xunit;

namespace TicTacToeCut2.Api.Tests
{
    public class GameControllerTests
    {
        readonly GameController _controller = new GameController();

        [Fact]
        public void GameController_ReturnsNewGame ()
        {
            var result = _controller.GetNewGame();

            var expected = new GameResultModel()
            {
                Board = new string[9],
                Players = new List<PlayerModel>
                {
                    new PlayerModel{ Piece = "X" },
                    new PlayerModel{ Piece = "O" }
                },
                GameState = "New Game"
            };

            result.Should().BeEquivalentTo(expected);
        }

        [Fact]
        public void GameController_WhenPlaysMoveOf1_ReturnsChangedBoard()
        {
            var webGame = new WebGame();
            var result = _controller.PlayMove(webGame, "X" , 1);
            var expected = new string[9]{"X",null, null , null , null , null , null , null , null};
            Assert.Equal(expected,result.Game.Board);
        }
    }
}
