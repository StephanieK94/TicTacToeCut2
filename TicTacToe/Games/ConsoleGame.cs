using System;
using TicTacToe.Boards;
using TicTacToe.Messages;
using TicTacToe.Players;

namespace TicTacToe.Games
{
    public class ConsoleGame
    {
        public int TurnCount { get; set; } = 0;
        public Board Board = Factory.CreateConsoleBoard();
        public Player Player = Factory.CreateConsolePlayer();
        public MessageProcessor Message = Factory.CreateConsoleMsgProcessor();
        public WinCalculator WinCal = Factory.CreateConsoleWinCalculator();

        public void StartGame() 
        {
            Message.PrintToConsole(Message.MsgDictionary["Welcome"]);
            Board.PrintBoard();

            Prompt:
            Message.PrintToConsole( Message.PromptForMove( Player.Character ) );

            var playerInput = GetInput();

            if ( Player.LastMove.CheckForForfeit( playerInput ) == true )
            {
                Player.ChangePlayer();
                WinCal.IsWinner = true;
                goto EndGame;
            }

            if ( Player.LastMove.ConvertPlayerInputToMove( playerInput ) == false )
            {
                Message.PrintToConsole( Message.MsgDictionary["InvalidInput"] );
                goto Prompt;
            }

            if ( Player.LastMove.ValidatePlayerMoves( Player.LastMove ) == false)
            {
                Message.PrintToConsole( Message.MsgDictionary["OutOfBound"] );
                goto Prompt;
            }

            switch( Board.ValidatePositionIsEmpty( Player.LastMove ) )
            {
                case true:
                    Board.PlayMoveOnBoard( Player , Player.LastMove );
                    Message.PrintToConsole( Message.MsgDictionary["AcceptedMove"] );
                    Board.PrintBoard();
                    break;
                default:
                    Message.PrintToConsole( Message.MsgDictionary["InvalidMove"] );
                    goto Prompt;
            }

            WinCal.WinnerCalculator( Board.Layout);
            TurnCount++;

            if(WinCal.IsWinner == false && TurnCount < 9)
            {
                Player.ChangePlayer();
                goto Prompt;
            }

            EndGame:
            Message.PrintToConsole(WinCal.IsWinner == false
                ? Message.MsgDictionary["ResultWasDraw"]
                : Message.ReturnWinner(Player.Character.ToString()));
        }

        public bool PromptForNewGame ()
        {
            Message.PrintToConsole( Message.MsgDictionary["PromptForNewGame"] );

            var playAgain = GetInput();

            return playAgain.Contains( "Y".ToLower() );
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
