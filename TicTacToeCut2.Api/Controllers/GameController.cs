﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe;
using TicTacToe.Games;
using TicTacToeCut2.Api;
using TicTacToeCut2.Api.Models;

namespace TicTacToeCut2.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET api/values
        [HttpGet]
        public GameResultModel GetNewGame ()
        {
            var webGame = new WebGame();
            return webGame.Game;
        }

        // GET api/tictactoe/players
        [HttpGet( "/players" )]
        public List<PlayerModel> GetPlayersList ()
        {
            var webGame = new WebGame();
            return webGame.Game.Players;
        }

        //// POST api/tictactoe/players/{player}
        //[HttpPost("/players/{player}/{move}")]
        //public WebGame PlayMove(string[] board, string playerPiece, int move)
        //{

        //}
    }
}