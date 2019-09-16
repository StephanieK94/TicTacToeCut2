using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicTacToe;
using TicTacToe.Games;
using TicTacToeCut2.Api;

namespace TicTacToeCut2.Api.Controllers
{
    [Route( "api/[controller]" )]
    [ApiController]
    public class GameController : ControllerBase
    {
        public GameResultModel Get ()
        {
            var game = new ConsoleGame();

            game.StartGame();

            return new GameResultModel();
        }
    }
}