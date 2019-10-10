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
            var webGame = service.NewGame();

            var result = service.PlayMove( webGame , "X" , 1 );

            Assert.Equal("X" , result.Board[0] );
        }

        // Should I add into the GameResultModel an extra player of the CurrentPlayer?
        // How will I keep track of the Board and the current player?

        [Fact]
        public void WhenInvalidMovePlayed_ReturnsGameStateAsInvalid ()
        {
            var webGame = service.NewGame();
            webGame.Board[0] = "X";

            var result = service.PlayMove( webGame , "O" , 1 );

            Assert.Equal(webGame, result);
            Assert.Equal("Invalid Move", result.State);
        }
    }
}
