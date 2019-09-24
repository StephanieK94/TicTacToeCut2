using System;
using System.Net;
using TicTacToe.ConsoleApplication.Games;
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
            //GetNewGame();

            StartNewGame:
            var game = new ConsoleGame();

            game.StartGame();

            MovePrompt:
            if( game.GetValidMove() == false ) goto MovePrompt; 
            if( game.WinCal.IsWinner == true ) goto EndGame; 
            if( game.PlayMove( game.CurrentMove ) == false ) goto MovePrompt; 

            game.WinCal.WinnerCalculator( game.Board.Layout );
            game.TurnCount++;

            if ( game.WinCal.IsWinner == false && game.TurnCount < 9 )
            {
                game.ChangePlayer();
                goto MovePrompt;
            }

            EndGame:
            game.Message.PrintToConsole(game.WinCal.IsWinner == false
                ? game.Message.ReturnDraw()
                : game.Message.ReturnWinner(game.Player.Character.ToString()));

            if ( game.PromptForNewGame() == true )
                goto StartNewGame;

        }

        // Is this really necessary?
        // Or would it be more needed for the post
        // What's the whole idea about getting the Web Api Game and converting it, when all the validation etc gets done in console
        // Is this to do with when adding some sort of way of storing the past/current game in the web api somehow?
        static async Task<ConsoleGame> GetNewGame()
        {
            using ( var client = new HttpClient() )
            {
                client.BaseAddress = new Uri( "http://localhost:44355/" );  // add on api/Game?
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add( new MediaTypeWithQualityHeaderValue( "application/json" ) );

                HttpResponseMessage response = await client.GetAsync( "api/game" );     // or is it api/values still? how change?

                if ( response.IsSuccessStatusCode )
                {
                    // to get a game back 
                    // to convert the game into the game that the console uses?

                    // does this really need to be done for the starting of a game?
                    // would it be more useful to do this for post etc
                    // Or keep this for when have storage and id # for the game etc?
                }
                return new ConsoleGame();
            }
        }
    }
}
