using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
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
                State = "New Model"
            };

            result.Value.Should().BeEquivalentTo(expected);
        }


        [Fact]
        public void GameController_WhenPlaysMoveOf1_ReturnsChangedBoard ()
        {
            var webGame = new WebGame();
            var result = _controller.PlayMove( webGame , "X" , 1 );
            var expected = new string[9] { "X" , null , null , null , null , null , null , null , null };

            Assert.Equal( expected , result.Model.Board );
        }

        // Should I add into the GameResultModel an extra player of the CurrentPlayer?
        // How will I keep track of the Board and the current player?
        //
        [Fact( Skip = "Haven't decided how to note the current player or if need to switch them" )]
        public void GameController_WhenPlaysMoveOf1_ReturnsChangedStateAndPlayer ()
        {
            var webGame = new WebGame();
            var result = _controller.PlayMove( webGame , "X" , 1 );
            var expected = new string[9] { "X" , null , null , null , null , null , null , null , null };

            Assert.Equal( expected , result.Model.Board );
        }

        [Fact]
        public void WhenInvalidMovePlayed_ReturnsGameStateAsInvalid ()
        {
            var webGame = new WebGame
            {
                Model = {Board = new string[9] {"X", null, null, null, null, null, null, null, null}}
            };

            var result = _controller.PlayMove( webGame , "X" , 1 );

            Assert.Equal(webGame, result);
            Assert.Equal("Invalid Move", result.Model.State);
        }
    }
}
