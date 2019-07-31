using System;
using TicTacToe;
using Xunit;

namespace TicTacTestLibrary
{
    public class WinnerTests
    {
        private readonly Player player;
        private readonly Move nextMove;
        private readonly WinCalculator winCal;

        public WinnerTests()
        {
            player = new Player();
            nextMove = new Move();
            winCal = new WinCalculator();
        }

        [Fact]
        public void GivenColumnWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty },
                { BoardPiece.X, BoardPiece.Empty, BoardPiece.Empty }
            };

            winCal.WinnerCalculator(currentBoard  );

            Assert.True( winCal.IsWinner );
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

            winCal.WinnerCalculator(currentBoard);

            Assert.True( winCal.IsWinner );
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

            winCal.WinnerCalculator( currentBoard  );

            Assert.True( winCal.IsWinner );
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

            winCal.WinnerCalculator( currentBoard );

            Assert.True( winCal.IsWinner );
        }

        [Fact]
        public void GivenFullBoard_WhenNoWinner_ReturnWinnerIsEqualToFalse ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.X, BoardPiece.O },
                { BoardPiece.O, BoardPiece.O, BoardPiece.X },
                { BoardPiece.X, BoardPiece.O, BoardPiece.X }
            };

            winCal.WinnerCalculator(currentBoard );

            Assert.False( winCal.IsWinner );
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

            winCal.WinnerCalculator(currentBoard );

            Assert.False( winCal.IsWinner );
        }
    }
}
