using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Mvc;
using TicTacToe;
using TicTacToeCut2.Api;
using TicTacToeCut2.Api.Models;
using System.Web.Http.Results;

namespace TicTacToeCut2.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class GameController : ControllerBase
    {
        // GET api/tictactoe
        [HttpGet]
        public GameResultModel GetNewGame ()
        {
            var service = new TicTacService();
            return service.NewGame();
        }

        // GET api/tictactoe/players
        [HttpGet( "/players" )]
        public ActionResult<IEnumerable<string>> GetPlayersList ()
        {
            var service = new TicTacService();
            var webGame = service.NewGame();
            return webGame.Players;
        }

        // POST api/tictactoe/players/X/1
        [HttpPost( "/players/{player}/{move}" )]
        public GameResultModel PlayMove ( GameResultModel game , string player , int move )
        {
            var service = new TicTacService();
            var newGame = service.PlayMove(game, player, move);
            return newGame;
        }
    }
}