using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public interface INewGame
    {
        void StartGame();
    }

    public class NewGame : INewGame
    {
        public int TurnCount { get; set; }

        public Board Board = new Board();
        public Player Player = new Player();
        public MessageProcessor Message = new MessageProcessor();

        public void StartGame() 
        {
            Message.PrintToConsole(Message.MsgDictionary["Welcome"]);
            Board.PrintBoard();

            Prompt:
            Message.PrintToConsole( Message.PromptForMove( Player.Character ) );

            var playerInput = GetInput();
            var winCal = new WinCalculator();

            if ( Player.LastMove.CheckForForfeit( playerInput ) == true )
            {
                Player.ChangePlayer();
                winCal.IsWinner = true;
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

            winCal.WinnerCalculator( Board.Layout);
            TurnCount++;

            if(winCal.IsWinner == false && TurnCount < 9)
            {
                Player.ChangePlayer();
                goto Prompt;
            }

            EndGame:
            Message.PrintToConsole(winCal.IsWinner == false
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
