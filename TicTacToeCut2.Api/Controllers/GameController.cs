using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
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

        // POST api/tictactoe/players/{player}
        [HttpPost( "/players/{player}/{move}" )]
        public WebGame PlayMove ( WebGame game , string playerPiece , int move )
        {
            move = move - 1;
            if (game.Game.Board[move] != null)
            {
                game.Game.GameState = "Invalid Move";

                //Response = the 400 response and the gameState changes

                return game;
            }
            //Response = the 200 response and the board changes
            game.Game.Board[move] = playerPiece;
            return game;
        }
    }
}