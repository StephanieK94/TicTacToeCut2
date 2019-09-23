using TicTacToe.ConsoleApplication;
using TicTacToe.ConsoleApplication.Games;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class WinnerTests
    {
        private readonly ConsoleGame _game;

        public WinnerTests()
        {
            _game = new ConsoleGame();
        }

        [Fact]
        public void GivenColumnWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.X, BoardPiece.None, BoardPiece.None }
            };

            _game.WinCal.WinnerCalculator( _game.Board.Layout );

            Assert.True( _game.WinCal.IsWinner );
        }

        [Fact]
        public void GivenRowWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.X, BoardPiece.X },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None }
            };

            _game.WinCal.WinnerCalculator( _game.Board.Layout );

            Assert.True( _game.WinCal.IsWinner );
        }

        [Fact]
        public void GivenDiagonalWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.X, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.X }
            };

            _game.WinCal.WinnerCalculator( _game.Board.Layout );

            Assert.True( _game.WinCal.IsWinner );
        }

        [Fact]
        public void GivenReverseDiagonalWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.O, BoardPiece.X },
                { BoardPiece.O, BoardPiece.X, BoardPiece.O },
                { BoardPiece.X, BoardPiece.None, BoardPiece.O }
            };

            _game.WinCal.WinnerCalculator( _game.Board.Layout );

            Assert.True( _game.WinCal.IsWinner );
        }

        [Fact]
        public void GivenFullBoard_WhenNoWinner_ReturnWinnerIsEqualToFalse ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.X, BoardPiece.O },
                { BoardPiece.O, BoardPiece.O, BoardPiece.X },
                { BoardPiece.X, BoardPiece.O, BoardPiece.X }
            };

            _game.WinCal.WinnerCalculator( _game.Board.Layout );

            Assert.False( _game.WinCal.IsWinner );
        }

        [Fact]
        public void GivenSingleMove_ReturnWinnerIsEqualToFalse ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None },
                { BoardPiece.None, BoardPiece.None, BoardPiece.None }
            };

            _game.WinCal.WinnerCalculator(_game.Board.Layout );

            Assert.False( _game.WinCal.IsWinner );
        }

        [Fact]
        public void GivenNoWin_WhenPlaysSecondToLastMove_ReturnDrawTrue ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.X, BoardPiece.X, BoardPiece.O },
                { BoardPiece.O, BoardPiece.O, BoardPiece.X },
                { BoardPiece.X, BoardPiece.None, BoardPiece.None }
            };

            var nextMove = new Move(){Row = 3, Column = 3};
            
            _game.Player.Character = BoardPiece.O;

            _game.PlayMove(nextMove);
            _game.WinCal.WinnerCalculator( _game.Board.Layout );

            Assert.False( _game.WinCal.IsWinner );
        }
        [Fact]
        public void GivenNoWin_WhenPlaysLastMove_ReturnDrawTrue ()
        {
            _game.Board.Layout = new BoardPiece[,]
            {
                { BoardPiece.O, BoardPiece.O, BoardPiece.X },
                { BoardPiece.X, BoardPiece.X, BoardPiece.O },
                { BoardPiece.O, BoardPiece.X, BoardPiece.None }
            };

            var nextMove = new Move() { Row = 3 , Column = 3 };

            _game.Player.Character = BoardPiece.X;

            _game.PlayMove( nextMove );
            _game.WinCal.WinnerCalculator( _game.Board.Layout );

            Assert.False( _game.WinCal.IsWinner );
        }
    }
}
