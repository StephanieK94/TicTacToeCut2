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

        public static void GetNewGame()
        {
            //using (var client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri("http://localhost:44355/");  // add on api/Game?
            //    client.DefaultRequestHeaders.Accept.Clear();
            //    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); 
            //                                                                                // that we will get json back

            //    Console.WriteLine("GET");
            //    HttpResponseMessage response = await client.GetAsync("api/game");

            //    if (response.IsSuccessStatusCode)
            //    {
            //        GameResultModel game = await response.Content.ReadAsAsync<GameResultModel>();
            //        Console.WriteLine("{0},{1},{2}", game.Board[0], game.Board[1] , game.Board[2] );
            //        Console.WriteLine("{0},{1},{2}", game.Players[0], game.Players[1], game.State );
            //    }
            //}

            //using (var client = new WebClient())
            //{
            //    client.Headers.Add("Content-Type", "application/json");
            //    client.Headers.Add("Accept","application/json");

            //    var result = client.DownloadString("http://localhost:44355/api/Game");
            //    Console.WriteLine(result);
            //}
        }
    }
}
