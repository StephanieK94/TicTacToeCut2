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

        [Fact(Skip = "Haven't gotten passing yet")]
        public void GameController_WhenPlaysMoveOf1_ReturnsChangedBoard()
        {
            var expected = new GameResultModel()
            {
                Board = new string[9] ,
                Players = new List<PlayerModel>
                {
                    new PlayerModel{ Piece = "X" },
                    new PlayerModel{ Piece = "O" }
                } ,
                GameState = "New Game"
            };

            var move = 1;

            //var result = _controller.PlayMove(expected.Players[0].Piece, move);
        }
    }
}
