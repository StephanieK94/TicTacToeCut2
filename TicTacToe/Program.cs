using System;
using System.Net;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Formatting;

namespace TicTacToe.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
            StartNewGame:
            var service = new TictacService();
            var game = service.NewGame();

            game.StartGame();

            MovePrompt:
            if( game.GetValidMove() == false ) goto MovePrompt; 
            if( game.WinCalculator.IsWinner == true ) goto EndGame; 
            if( game.PlayMove( game.Move.Position ) == false ) goto MovePrompt; 

            game.WinCalculator.CalculateWinner(game.Board.Layout);
            game.TurnCount++;

            if ( game.WinCalculator.IsWinner == false && game.TurnCount < 9 )
            {
                game.ChangePlayer();
                goto MovePrompt;
            }

            EndGame:
            //game.Message.PrintToConsole(game.WinCalculator.IsWinner == false
                //? game.Message.ReturnDraw()
                //: game.Message.ReturnWinner(game.Player.Character.ToString()));

            if ( game.PromptForNewGame() == true )
                goto StartNewGame;

        }
    }
}
