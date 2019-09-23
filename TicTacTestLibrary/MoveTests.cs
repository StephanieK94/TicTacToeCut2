using TicTacToe.ConsoleApplication.Games;
using Xunit;

namespace TicTacToe.ConsoleApplication.Test
{
    public class MoveTests
    {
        private readonly Move _nextMove;
        private readonly ConsoleGame _game;

        public MoveTests()
        {
            _nextMove = new Move();
            _game = new ConsoleGame();
        }

        [Theory]
        [InlineData( 1 , 1 , true )]
        [InlineData( 2 , 2 , true )]
        [InlineData( 3 , 3 , true )]
        [InlineData( 0 , 0 , false )]
        [InlineData( 4 , 4 , false )]
        [InlineData( -1 , -1 , false )]
        public void GivenInput_WhenValidationForRangeCalled_ReturnsExpectedResult(int row, int column, bool expectedResult)
        {
            _nextMove.Row = row;
            _nextMove.Column = column;

            var actual = _game.ValidateMoveWithinRange( _nextMove );

            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData( "q1,2" , true )]
        [InlineData( "1,2", false)]
        [InlineData( "1,Q2", true)]
        [InlineData( "1,P", false)]
        public void GivenInput_WhenCheckForForfeit_ReturnsExpectedOutput(string input, bool output)
        {
            var playerForfeits = _game.CurrentMove.CheckForForfeit( input );

            Assert.Equal( output, playerForfeits );
        }

        [Fact]
        public void GivenInvalidInput_WhenTriesToConvertMove_CatchesExceptionAndReturnsFalse()
        {
            var input = ",1";

            var isValidInput = _game.CurrentMove.ConvertPlayerInputToMove( input );

            Assert.False( isValidInput );
        }
    }
}
