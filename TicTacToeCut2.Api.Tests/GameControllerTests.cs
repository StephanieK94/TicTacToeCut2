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
        private readonly TicTacService service = new TicTacService();

        // TODO: refactor these to test the logic implemented within rather than the service, so extract the logic out from the service itself.
        // And just call it from the service?

        [Fact]
        public void Service_NewGame_ReturnsNewWebGame ()
        {
            var result = service.NewGame();

            var expected = new GameResultModel()
            {
                Board = new string[9] { "","","", "" , "" , "" , "" , "" , "" } ,
                Players = new List<string>
                {
                    "X","O"
                } ,
                State = "New Game"
            };

            result.Should().BeEquivalentTo( expected );
        }


        [Fact]
        public void GameController_WhenPlaysMoveOf1_ReturnsChangedBoard ()
        {
            var gameInput = new GameInputModel()
            {
                Board = new string[9] { "", "", "", "", "", "", "", "", "" },
                Player = "X",
                Move = 1,
            };

            var result = service.PlayMove( gameInput);

            Assert.Equal("X" , result.Board[0] );
            Assert.Equal("O's turn", result.State);
        }

        [Fact]
        public void WhenInvalidMovePlayed_ReturnsGameStateAsInvalid ()
        {
            var gameInput = new GameInputModel()
            {
                Board = new string[9] { "X", "", "", "", "", "", "", "", "" },
                Player = "O",
                Move = 1,
            };

            var result = service.PlayMove( gameInput );

            Assert.Equal(gameInput.Board, result.Board);
            Assert.Equal("Invalid Move", result.State);
        }
    }
}
