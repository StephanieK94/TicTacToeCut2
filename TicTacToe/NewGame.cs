using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class NewGame
    {
        private int _turnCount;
        public int turnCount
        {
            get { return _turnCount; }
            set { _turnCount = value; }
        }

        public Board board = new Board();
        public Player player = new Player();
        public Messages messages = new Messages();

        public void StartGame() 
        {
            messages.PrintToConsole(messages.dictionary["Welcome"]);
            board.PrintBoard();

            Prompt:
            messages.PrintToConsole( messages.PromptForMove( player ) );

            var playerInput = GetInput();
            WinCalculator winCal = new WinCalculator();

            if ( player.LastMove.CheckForForfeit( playerInput ) == true )
            {
                player.ChangePlayer();
                winCal.IsWinner = true;
                goto EndGame;
            }

            if ( player.LastMove.ConvertPlayerInputToMove( playerInput ) == false )
            {
                messages.PrintToConsole( messages.dictionary["InvalidInput"] );
                goto Prompt;
            }

            if ( player.LastMove.ValidatePlayerMoves( player.LastMove ) == false)
            {
                messages.PrintToConsole( messages.dictionary["OutOfBound"] );
                goto Prompt;
            }

            switch( board.VaidatePositionIsEmpty( player.LastMove ) )
            {
                case true:
                    board.PlayMoveOnBoard( player , player.LastMove );
                    messages.PrintToConsole( messages.dictionary["AcceptedMove"] );
                    board.PrintBoard();
                    break;
                default:
                    messages.PrintToConsole( messages.dictionary["InvalidMove"] );
                    goto Prompt;
            }

            winCal.WinnerCalculator( board.layout);
            turnCount++;

            if(winCal.IsWinner == false && turnCount < 9)
            {
                player.ChangePlayer();
                goto Prompt;
            }

            EndGame:
            if ( winCal.IsWinner == false ) messages.PrintToConsole( messages.dictionary["ResultWasDraw"]);
            else messages.PrintToConsole( messages.ReturnWinner( player )) ;
        }

        public bool PromptForNewGame ()
        {
            messages.PrintToConsole( messages.dictionary["PromptForNewGame"] );

            var playAgain = GetInput();

            if ( playAgain.Contains( "Y".ToLower() )) return true;
            return false;
        }

        public string GetInput()
        {
            return Console.ReadLine();
        }
    }
}
