using System;
using TicTacToe;
using Xunit;

namespace TicTacTestLibrary
{
    public class WinnerTests
    {
        [Fact]
        public void GivenColumnWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty }
            };

            var player = new Player() { Character = BoardPiece.X };
            var nextMove = new Move() { Row = 1 , Column = 1 };

            Game game = new Game();
            game.winCal.GetWinner( player , currentBoard , nextMove );

            Assert.True( game.winCal.IsWinner );
        }

        [Fact]
        public void GivenRowWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.X, BoardPiece.X },
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty }
            };

            var player = new Player() { Character = BoardPiece.X };
            var nextMove = new Move() { Row = 1 , Column = 1 };

            Game game = new Game();
            game.winCal.GetWinner( player , currentBoard , nextMove );

            Assert.True( game.winCal.IsWinner );
        }

        [Fact]
        public void GivenDiagonalWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.Empty, BoardPiece.X, BoardPiece.Empty },
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.X }
            };

            var player = new Player() { Character = BoardPiece.X };
            var nextMove = new Move() { Row = 1 , Column = 1 };

            Game game = new Game();
            game.winCal.GetWinner( player , currentBoard , nextMove );

            Assert.True( game.winCal.IsWinner );
        }

        [Fact]
        public void GivenReverseDiagonalWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.O, BoardPiece.X },
                { BoardPiece.O, BoardPiece.X, BoardPiece.O },
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.O }
            };

            var player = new Player() { Character = BoardPiece.X };
            var nextMove = new Move() { Row = 1 , Column = 1 };

            Game game = new Game();
            game.winCal.GetWinner( player , currentBoard , nextMove );

            Assert.True( game.winCal.IsWinner );
        }

        [Fact]
        public void GivenFullBoard_ReturnWinnerIsEqualToFalse ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.X, BoardPiece.O },
                { BoardPiece.O, BoardPiece.O, BoardPiece.X },
                { BoardPiece.X, BoardPiece.O, BoardPiece.X }
            };

            var player = new Player() { Character = BoardPiece.X };
            var nextMove = new Move() { Row = 1 , Column = 1 };

            Game game = new Game();
            game.winCal.GetWinner( player , currentBoard , nextMove );

            Assert.False( game.winCal.IsWinner );
        }

        [Fact]
        public void GivenSingleMove_ReturnWinnerIsEqualToFalse ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.Empty, BoardPiece.Empty, BoardPiece.Empty }
            };

            var player = new Player() { Character = BoardPiece.X };
            var nextMove = new Move() { Row = 1 , Column = 1 };

            Game game = new Game();
            game.winCal.GetWinner( player , currentBoard , nextMove );

            Assert.False( game.winCal.IsWinner );
        }
    }
}
