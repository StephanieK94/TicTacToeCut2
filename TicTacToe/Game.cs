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
        public Winner winCal = new Winner();


        public void StartGame() // public Game() instead?
        {
            Console.WriteLine( msg.Welcome );

            Prompt:
            Console.WriteLine( msg.PromptForMove( currentPlayer ) );

            var playerInput = Console.ReadLine();

            if ( nextMove.CheckForForfeit( playerInput ) == true )
            {
                currentPlayer.ChangePlayer();
                goto EndGame;
            }

            nextMove.ConvertPlayerInputToMove( playerInput );

            if ( nextMove.ValidatePlayerMoves( nextMove ) == false)
            {
                Console.WriteLine( msg.OutOfBoundMessage );
                goto Prompt;
            }

            switch( board.VaidatePositionIsEmpty(nextMove))
            {
                case true:
                    Console.WriteLine( msg.AcceptedMove );
                    board.PlayMoveOnBoard( currentPlayer, nextMove );
                    break;
                default:
                    Console.WriteLine( msg.InvalidMoveMessage );
                    goto Prompt;
            }

            winCal.GetWinner(currentPlayer, board.board, nextMove);
            turnCount++;

            if(winCal.IsWinner != true && turnCount != 9)
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
