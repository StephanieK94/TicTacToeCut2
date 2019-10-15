using TicTacToe.ConsoleApplication;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class WinnerTests
    {
        private readonly consoleGame _game;

        public WinnerTests()
        {
            var service = new TicTacService();
            _game = service.NewGame();
        }

        [Fact]
        public void GivenColumnWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new string[9]
            {
                "X" , "" , "" ,
                "X" , "" , "" ,
                "X" , "" , ""
            };

            _game.WinCalculator.CalculateWinner(_game.Board.Layout);

            Assert.True( _game.WinCalculator.IsWinner );
        }

        [Fact]
        public void GivenRowWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new string[9]
            {
                "X", "X", "X",
                "", "", "",
                "", "", ""
            };

            _game.WinCalculator.CalculateWinner( _game.Board.Layout );

            Assert.True( _game.WinCalculator.IsWinner );
        }

        [Fact]
        public void GivenDiagonalWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new string[9]
            {
                "X", "", "",
                "", "X", "",
                "", "", "X"
            };

            _game.WinCalculator.CalculateWinner(_game.Board.Layout);

            Assert.True( _game.WinCalculator.IsWinner );
        }

        [Fact]
        public void GivenReverseDiagonalWin_ReturnWinnerTrue ()
        {
            _game.Board.Layout = new string[9]
            {
                "X", "O", "X",
                "O", "X", "O",
                "X", "", "O"
            };

            _game.WinCalculator.CalculateWinner( _game.Board.Layout );

            Assert.True( _game.WinCalculator.IsWinner );
        }

        [Fact]
        public void GivenFullBoard_WhenNoWinner_ReturnWinnerIsEqualToFalse ()
        {
            _game.Board.Layout = new string[9]
            {
                "X", "X", "O",
                "O", "O", "X",
                "X", "O", "X"
            };

            _game.WinCalculator.CalculateWinner(_game.Board.Layout);

            Assert.False( _game.WinCalculator.IsWinner );
        }

        [Fact]
        public void GivenSingleMove_ReturnWinnerIsEqualToFalse ()
        {
            _game.Board.Layout = new string[9]
            {
                "X", "", "",
                "", "", "",
                "", "", ""
            };

            _game.WinCalculator.CalculateWinner( _game.Board.Layout );

            Assert.False( _game.WinCalculator.IsWinner );
        }

        [Fact]
        public void GivenNoWin_WhenPlaysSecondToLastMove_ReturnDrawTrue ()
        {
            _game.Board.Layout = new string[]
            {
                "X" ,"X", "O",
                "O", "O", "X",
                "X", "", ""
            };

            var nextMove = new ConsoleMove(){Position = 8};
            
            _game.CurrentPlayer = "O";

            _game.PlayMove(nextMove.Position);
            _game.WinCalculator.CalculateWinner( _game.Board.Layout );

            Assert.False( _game.WinCalculator.IsWinner );
        }
        [Fact]
        public void GivenNoWin_WhenPlaysLastMove_ReturnDrawTrue ()
        {
            _game.Board.Layout = new string[9]
            {
                "O", "O", "X",
                "X", "X", "O",
                "O", "X", ""
            };

            var nextMove = new ConsoleMove(){Position = 8};

            _game.CurrentPlayer = "X";

            _game.PlayMove( nextMove.Position );
            _game.WinCalculator.CalculateWinner( _game.Board.Layout );

            Assert.False( _game.WinCalculator.IsWinner );
        }
    }
}
