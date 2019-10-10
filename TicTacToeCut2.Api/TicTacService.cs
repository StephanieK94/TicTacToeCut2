using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Lib;
//using TicTacToe;
using TicTacToeCut2.Api.Models;

namespace TicTacToeCut2.Api
{
    public class TicTacService
    {
        public GameResultModel NewGame()
        {
            var game = new Game();
            var webModel = new GameResultModel()
            {
                Board = game.Board.Layout,
                Players = new List<string>() { "X", "O"},
                State = "New Game",
            };
            return webModel;
        }

        public GameResultModel PlayMove(GameResultModel game, string player, int move)
        {
            move = move - 1;

            if ( game.Board[move] != "" )
            {
                game.State = "Invalid Move";

                return game;
            }
            game.Board[move] = player;
            var nextPlayer = player == game.Players[0] ? game.Players[1] : game.Players[0];

            game.State = $"{nextPlayer}'s turn";

            return game;
        }
    }
}
