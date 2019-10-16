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
        private readonly TicTacService service = new TicTacService();

        // GET api/tictactoe
        [HttpGet]
        public GameResultModel Get ()
        {
            return service.NewGame();
        }

        // POST api/tictactoe/players/X/1
        [HttpPost( "/play/{game}" )]
        public GameResultModel Play ( GameInputModel game)
        {
            var newGame = service.PlayMove(game);
            return newGame;
        }
    }
}