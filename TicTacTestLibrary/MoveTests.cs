using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using TicTacToe;

namespace TicTacTestLibrary
{
    public class MoveTests
    {
         [Fact]
        public void GivenInput_ReturnMove()
        {
            int row = 1;
            int column = 1;

            Move nextMove = new Move();
            nextMove.Row = row;
            nextMove.Column = column;

            Assert.Equal(0, nextMove.Row);
            Assert.Equal(0, nextMove.Column);
        }

        [Theory]
        [InlineData( "q1,2" , true )]
        [InlineData( "1,2", false)]
        [InlineData( "1,Q2", true)]
        public void GivenInput_WhenCheckForForfeit_ReturnsExpectedOutput(string input, bool output)
        {
            Move nextMove = new Move();

            bool playerForfeits = nextMove.CheckForForfeit( input );

            Assert.Equal( output, playerForfeits );
        }
    }
}
