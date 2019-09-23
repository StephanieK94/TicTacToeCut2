using TicTacToe.ConsoleApplication.Games;

namespace TicTacToe.ConsoleApplication
{
    public class Program
    {
        static void Main(string[] args)
        {
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
    }
}
