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
            var resultModel = new GameResultModel()
            {
                Board = game.Board,
                Players = new List<string>() { game.Player, "O"},
                State = "New Game",
            };
            return resultModel;
        }

        public GameResultModel PlayMove(GameInputModel inputGame)
        {
            var positionInArray = inputGame.Move - 1;
            var gameResult = NewGame();

            gameResult.Board = inputGame.Board;
            gameResult.CurrentPlayer = inputGame.Player;

            if(ValidateEmptyPosition(inputGame.Board[positionInArray]) == false)
            {
                gameResult.State = "Invalid Move";
                return gameResult;
            }

            gameResult.Board[positionInArray] = gameResult.CurrentPlayer;
            

            if(GameIsWon(gameResult) == true)
            {
                gameResult.State = $"{gameResult.CurrentPlayer} won!";
            }
            else 
            {
                gameResult.CurrentPlayer = ChangePlayer(inputGame);
                gameResult.State = $"{gameResult.CurrentPlayer}'s turn";
            }

            return gameResult;
        }

        public bool GameIsWon(GameResultModel game)
        {
            WinCalculator winCalcuator = new WinCalculator();
            winCalcuator.CalculateWinner(game.Board);

            if(winCalcuator.IsWinner == true) return true;
            return false;
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
