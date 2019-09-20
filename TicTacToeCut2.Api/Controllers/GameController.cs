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
        // GET api/tictactoe
        [HttpGet]
        public GameResultModel GetNewGame ()
        {
            var webGame = new WebGame();
            return webGame.Model;
        }

        // GET api/tictactoe/players
        [HttpGet( "/players" )]
        public List<PlayerModel> GetPlayersList ()
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
                //Response = the 400 response and the gameState changes
                game.Model.State = "Invalid Move";
                return game;
            }
            //Response = the 200 response and the board and state changes changes
            game.Model.Board[move] = playerPiece;
            //game.Model.State = "Player O's turn"

            return game;
        }
    }
}