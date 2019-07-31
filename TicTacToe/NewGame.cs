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
        public Player currentPlayer = new Player();
        public Move nextMove = new Move();
        public Messages messages = new Messages();

        public void StartGame() 
        {
            messages.PrintToConsole(messages.dictionary["Welcome"]);
            board.PrintBoard();

            Prompt:
            messages.PrintToConsole( messages.PromptForMove( currentPlayer ) );

            var playerInput = GetInput();
            WinCalculator winCal = new WinCalculator();

            if ( nextMove.CheckForForfeit( playerInput ) == true )
            {
                currentPlayer.ChangePlayer();
                winCal.IsWinner = true;
                goto EndGame;
            }

            if ( nextMove.ConvertPlayerInputToMove( playerInput ) == false )
            {
                messages.PrintToConsole( messages.dictionary["InvalidInput"] );
                goto Prompt;
            }

            if ( nextMove.ValidatePlayerMoves( nextMove ) == false)
            {
                messages.PrintToConsole( messages.dictionary["OutOfBound"] );
                goto Prompt;
            }

            switch( board.VaidatePositionIsEmpty(nextMove))
            {
                case true:
                    board.PlayMoveOnBoard( currentPlayer , nextMove );
                    messages.PrintToConsole( messages.dictionary["AcceptedMove"] );
                    board.PrintBoard();
                    break;
                default:
                    messages.PrintToConsole( messages.dictionary["InvalidMove"] );
                    goto Prompt;
            }

            winCal.WinnerCalculator( currentPlayer , board.layout , nextMove );
            turnCount++;

            if(winCal.IsWinner == false && turnCount < 9)
            {
                currentPlayer.ChangePlayer();
                goto Prompt;
            }

            EndGame:
            if ( winCal.IsWinner == false ) messages.PrintToConsole( messages.dictionary["ResultWasDraw"]);
            else messages.PrintToConsole( messages.PrintWinner( currentPlayer )) ;
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
