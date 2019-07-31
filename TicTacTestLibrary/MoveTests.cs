using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;

namespace TicTacTestLibrary
{
    public class MoveTests
    {
        private readonly Move nextMove;

        public MoveTests()
        {
            nextMove = new Move();
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
            nextMove.Row = row;
            nextMove.Column = column;

            var actual = nextMove.ValidatePlayerMoves( nextMove );

            Assert.Equal(expectedResult, actual);
        }

        [Theory]
        [InlineData( "q1,2" , true )]
        [InlineData( "1,2", false)]
        [InlineData( "1,Q2", true)]
        [InlineData( "1,P", false)]
        public void GivenInput_WhenCheckForForfeit_ReturnsExpectedOutput(string input, bool output)
        {
            bool playerForfeits = nextMove.CheckForForfeit( input );

            Assert.Equal( output, playerForfeits );
        }

        [Fact]
        public void GivenInvalidInput_WhenTriesToConvertMove_CatchesExceptionAndReturnsFalse()
        {
            var input = ",1";

            var isValidInput = nextMove.ConvertPlayerInputToMove( input );

            Assert.False( isValidInput );
        }
    }
}
