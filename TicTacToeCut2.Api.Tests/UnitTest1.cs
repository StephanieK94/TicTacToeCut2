using FluentAssertions;
using System;
using System.Collections.Generic;
using TicTacToeCut2.Api.Controllers;
using TicTacToeCut2.Api.Models;
using Xunit;

namespace TicTacToeCut2.Api.Tests
{
    public class UnitTest1
    {
        
        [Fact]
        public void GameController_ReturnsNewGame ()
        {
            var controller = new GameController();
            var result = controller.Get();

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
    }
}
