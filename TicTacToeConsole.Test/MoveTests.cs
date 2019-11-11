using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class MoveTests
    {
        private readonly ConsoleGameModel _game;
        private TicTacService service;
        public MoveTests()
        {
            service = new TicTacService();
            _game = service.NewGame();
        }

        [Theory]
        [InlineData(1,1 , true )]
        [InlineData(2,2 , true )]
        [InlineData(3,3, true )]
        [InlineData(0,0 , false )]
        [InlineData(4,4 , false )]
        [InlineData(-1,-1 , false )]
        public void GivenInput_WhenValidateMoveWithinRangeCalled_ReturnsExpectedResult(int row, int column, bool expectedResult)
        {
            _game.CurrentMove.Row = row;
            _game.CurrentMove.Column = column;
            var actual = service.ValidateMoveWithinRange( _game.CurrentMove );

            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData( "q1,2" , true )]
        [InlineData( "1,2", false)]
        [InlineData( "1,Q2", true)]
        [InlineData( "1,P", false)]
        public void GivenInput_WhenCheckForForfeit_ReturnsExpectedOutput(string input, bool output)
        {
            var playerForfeits = service.CheckForForfeit( input );

            Assert.Equal( output, playerForfeits );
        }

        [Fact]
        public void GivenInvalidInput_WhenTriesToConvertMove_CatchesExceptionAndReturnsFalse()
        {
            var input = ",1";

            var isValidInput = service.CanConvertPlayerInputToMove( input );

            Assert.False( isValidInput );
        }
    }
}
