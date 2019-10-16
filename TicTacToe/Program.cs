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
            Console.Clear();
            var service = new TicTacService();
            var game = service.NewGame();

            service.Play(game);

            if (service.PromptForNewGame() == true)
                goto StartNewGame;
        }
    }
}
