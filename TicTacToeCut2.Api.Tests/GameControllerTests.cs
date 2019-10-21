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
        private readonly TicTacService service;
        private readonly GameInputModel inputModel;
        private readonly GameResultModel gameResult;
        private readonly WinCalculator winCalculator;

        public GameControllerTests()
        {
            service = new TicTacService();
            gameResult = service.NewGame();
            inputModel = new GameInputModel()
            {
                Board = new string[9] { "", "", "", "", "", "", "", "", "" },
                Player = "X",
            };
            winCalculator = new WinCalculator();
        }

        [Fact]
        public void Service_NewGame_ReturnsNewWebGame ()
        {
            var expected = new GameResultModel()
            {
                Board = new string[9] { "","","", "" , "" , "" , "" , "" , "" } ,
                Players = new List<string>
                {
                    "X","O"
                } ,
                State = "New Game"
            };

            gameResult.Should().BeEquivalentTo( expected );
        }


        [Fact]
        public void GameController_WhenPlaysMoveOf1_ReturnsChangedBoard ()
        {
            inputModel.Move = 1;
            var result = service.PlayMove( inputModel);

            Assert.Equal("X" , result.Board[0] );
            Assert.Equal("O's turn", result.State);
        }

        [Fact]
        public void WhenInvalidMovePlayed_ReturnsGameStateAsInvalid ()
        {
            inputModel.Board[0] = "X";
            inputModel.Player = "O";
            inputModel.Move = 1;

            var result = service.PlayMove( inputModel );

            Assert.Equal(inputModel.Board, result.Board);
            Assert.Equal("Invalid Move", result.State);
        }

        [Fact]
        public void WhenBoardHasRowWin_WinCalculator_ReturnsIsWinnerIsTrue()
        {
            gameResult.Board = new string[9] { "X", "X", "X", "O", "O", "", "", "", "" };

            Assert.True(service.GameIsWon(gameResult));
        }
    }
}
