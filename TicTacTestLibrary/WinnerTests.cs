using TicTacToe.ConsoleApplication;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class WinnerTests
    {
        private readonly ConsoleGameModel _game;
        private TicTacService _service;
        private ConsoleWinCalculator _winCalculator;

        public WinnerTests()
        {
            _service = new TicTacService();
            _game = _service.NewGame();
            _winCalculator = Factory.CreateConsoleWinCalculator();
        }

        [Fact]
        public void GivenColumnWin_ReturnWinnerTrue ()
        {
            _game.Board = new string[9]
            {
                "X" , "" , "" ,
                "X" , "" , "" ,
                "X" , "" , ""
            };

            _winCalculator.CalculateWinner(_game.Board);

            Assert.True( _winCalculator.IsWinner );
        }

        [Fact]
        public void GivenRowWin_ReturnWinnerTrue ()
        {
            _game.Board = new string[9]
            {
                "X", "X", "X",
                "", "", "",
                "", "", ""
            };

            _winCalculator.CalculateWinner( _game.Board );

            Assert.True( _winCalculator.IsWinner );
        }

        [Fact]
        public void GivenDiagonalWin_ReturnWinnerTrue ()
        {
            _game.Board = new string[9]
            {
                "X", "", "",
                "", "X", "",
                "", "", "X"
            };

            _winCalculator.CalculateWinner(_game.Board);

            Assert.True( _winCalculator.IsWinner );
        }

        [Fact]
        public void GivenReverseDiagonalWin_ReturnWinnerTrue ()
        {
            _game.Board = new string[9]
            {
                "X", "O", "X",
                "O", "X", "O",
                "X", "", "O"
            };

            _winCalculator.CalculateWinner( _game.Board );

            Assert.True( _winCalculator.IsWinner );
        }

        [Fact]
        public void GivenFullBoard_WhenNoWinner_ReturnWinnerIsEqualToFalse ()
        {
            _game.Board = new string[9]
            {
                "X", "X", "O",
                "O", "O", "X",
                "X", "O", "X"
            };

            _winCalculator.CalculateWinner(_game.Board);

            Assert.False( _winCalculator.IsWinner );
        }

        [Fact]
        public void GivenSingleMove_ReturnWinnerIsEqualToFalse ()
        {
            _game.Board = new string[9]
            {
                "X", "", "",
                "", "", "",
                "", "", ""
            };

            _winCalculator.CalculateWinner( _game.Board );

            Assert.False( _winCalculator.IsWinner );
        }

       
        [Fact]
        public void GivenNoWin_ReturnDrawTrue ()
        {
            _game.Board = new string[9]
            {
                "O", "O", "X",
                "X", "X", "O",
                "O", "X", "X"
            };

            _winCalculator.CalculateWinner( _game.Board );

            Assert.False( _winCalculator.IsWinner );
        }
    }
}
