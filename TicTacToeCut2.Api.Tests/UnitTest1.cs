using FluentAssertions;
using System;
using System.Collections.Generic;
using TicTacToeCut2.Api.Controllers;
using Xunit;

namespace TicTacToeCut2.Api.Tests
{
    public class UnitTest1
    {
        
        [Fact(Skip = "Haven't got to pass yet")]
        public void GameController_ReturnsNewGame ()
        {
            var controller = new GameController();

            var result = controller.Get();
            var expected = new GameResultModel()
            {
                board = new string[9],
                players = new List<PlayerModel>
                {
                    new PlayerModel{ piece = "x" },
                    new PlayerModel{piece = "o"}
                },
                gameState = "New Game"
            };

            result.Should().BeEquivalentTo( expected );
        }
    }
}
