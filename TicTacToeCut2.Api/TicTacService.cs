using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe.Lib;
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

        public GameResultModel PlayMove(GameInputModel game)
        {
            var positionInArray = game.Move - 1;
            var gameResult = NewGame();

            gameResult.Board = game.Board;
            gameResult.CurrentPlayer = game.Player;

            if(ValidateEmptyPosition(game.Board[positionInArray]) == false)
            {
                gameResult.State = "Invalid Move";
                return gameResult;
            }

            gameResult.Board[positionInArray] = gameResult.CurrentPlayer;
            gameResult.CurrentPlayer = ChangePlayer(game);
            gameResult.State = $"{gameResult.CurrentPlayer}'s turn";

            return gameResult;
        }

        private bool ValidateEmptyPosition(string value)
        {
            return value == "";
        }

        private static string ChangePlayer(GameInputModel game)
        {
            return game.Player == "X" ? "O" : "X";
        }
    }
}
