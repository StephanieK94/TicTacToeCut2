using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
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
        public Messages msg = new Messages();

        public void StartGame() // public Game() instead?
        {
            Console.WriteLine( msg.Welcome );
            board.PrintBoard();

            Prompt:
            Console.WriteLine( msg.PromptForMove( currentPlayer ) );

            var playerInput = Console.ReadLine();
            WinCalculator winCal = new WinCalculator();

            if ( nextMove.CheckForForfeit( playerInput ) == true )
            {
                currentPlayer.ChangePlayer();
                winCal.IsWinner = true;
                goto EndGame;
            }

            if ( nextMove.ConvertPlayerInputToMove( playerInput ) == false )
            {
                Console.WriteLine( msg.InvalidInputMessage );
                goto Prompt;
            }

            if ( nextMove.ValidatePlayerMoves( nextMove ) == false)
            {
                Console.WriteLine( msg.OutOfBoundMessage );
                goto Prompt;
            }

            switch( board.VaidatePositionIsEmpty(nextMove))
            {
                case true:
                    board.PlayMoveOnBoard( currentPlayer , nextMove );
                    Console.WriteLine( msg.AcceptedMove );
                    board.PrintBoard();
                    break;
                default:
                    Console.WriteLine( msg.InvalidMoveMessage );
                    goto Prompt;
            }

            winCal.WinnerCalculator( currentPlayer , board.board , nextMove );
            turnCount++;

            if(winCal.IsWinner == false && turnCount < 9)
            {
                currentPlayer.ChangePlayer();
                goto Prompt;
            }

            EndGame:
            if ( winCal.IsWinner == false ) Console.WriteLine(msg.ResultWasDraw);
            else Console.WriteLine( msg.PrintWinner( currentPlayer )) ;
        }

        public bool PromptForNewGame ()
        {
            Console.WriteLine( msg.PromptForNewGame );
            var playAgain = Console.ReadLine();

            if ( playAgain.Contains( "Y".ToLower() )) return true;
            return false;
        }
    }
}
