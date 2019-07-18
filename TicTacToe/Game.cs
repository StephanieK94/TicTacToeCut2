using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Game
    {
        public Board board = new Board();
        public Player currentPlayer = new Player();
        public Move nextMove = new Move();
        public MessageList msg = new MessageList();
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


            EndGame:
            Console.WriteLine( msg.PrintWinner( currentPlayer )) ;
        }
    }
}
