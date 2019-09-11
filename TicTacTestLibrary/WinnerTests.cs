using System;
using TicTacToe;
using Xunit;

namespace TicTacTestLibrary
{
    public class WinnerTests
    {
        private readonly Player _player;
        private readonly Move _nextMove;
        private readonly WinCalculator _winCal;

        public WinnerTests()
        {
            _player = new Player();
            _nextMove = new Move();
            _winCal = new WinCalculator();
        }

        [Fact]
        public void GivenColumnWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.X, BoardPiece.None, BoardPiece.None }
            };

            _winCal.WinnerCalculator(currentBoard  );

            Assert.True( _winCal.IsWinner );
        }

        [Fact]
        public void GivenRowWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.X, BoardPiece.X },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None }
            };

            _winCal.WinnerCalculator(currentBoard);

            Assert.True( _winCal.IsWinner );
        }

        [Fact]
        public void GivenDiagonalWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.X, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.X }
            };

            _winCal.WinnerCalculator( currentBoard  );

            Assert.True( _winCal.IsWinner );
        }

        [Fact]
        public void GivenReverseDiagonalWin_ReturnWinnerTrue ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.O, BoardPiece.X },
                { BoardPiece.O, BoardPiece.X, BoardPiece.O },
                { BoardPiece.X, BoardPiece.None, BoardPiece.O }
            };

            _winCal.WinnerCalculator( currentBoard );

            Assert.True( _winCal.IsWinner );
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

            _winCal.WinnerCalculator(currentBoard );

            Assert.False( _winCal.IsWinner );
        }

        [Fact]
        public void GivenSingleMove_ReturnWinnerIsEqualToFalse ()
        {
            var currentBoard = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None }
            };

            _winCal.WinnerCalculator(currentBoard );

            Assert.False( _winCal.IsWinner );
        }
    }
}
