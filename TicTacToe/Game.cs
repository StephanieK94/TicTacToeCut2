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

        public void StartGame()
        {
            Console.WriteLine( msg.Welcome );

            Prompt:
            Console.WriteLine( msg.PromptForMove( currentPlayer ) );
            nextMove.ConvertPlayerInputToMove( Console.ReadLine() );

            switch ( nextMove.ValidateUserMoves( nextMove ) )
            {
                case true:
                    nextMove.SetPosition( nextMove );
                    break;
                default:
                    Console.WriteLine( msg.OutOfBoundMessage );
                    goto Prompt;
            }

            switch( board.VaidatePosition(nextMove))
            {
                case true:
                    board.PlayMoveOnBoard( currentPlayer, nextMove );
                    break;
                default:
                    Console.WriteLine( msg.InvalidMoveMessage );
                    goto Prompt;
            }



            Console.WriteLine( msg.PrintWinner( currentPlayer )) ;
        }
    }
}
