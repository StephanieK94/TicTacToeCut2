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
        public WebGame GetNewGame ()
        {
            return new WebGame();

        }

        // GET api/tictactoe/players
        [HttpGet( "/players" )]
        public ActionResult<IEnumerable<PlayerModel>> GetPlayersList ()
        {
            var webGame = new WebGame();
            return webGame.Model.Players;
        }

        // POST api/tictactoe/players/X/1
        [HttpPost( "/players/{player}/{move}" )]
        public WebGame PlayMove ( WebGame game , string playerPiece , int move )
        {
            move = move - 1;
            if ( game.Model.Board[move] != null )
            { 
                game.Model.State = "Invalid Move";

                return game;
            }
            game.Model.Board[move] = playerPiece;
            var nextPlayer = playerPiece == game.Model.Players[0].Piece ? game.Model.Players[1].Piece : game.Model.Players[0].Piece;
            //game.Model.State = new string($"{0}'s turn", nextPlayer);

            return game;
        }
    }
}