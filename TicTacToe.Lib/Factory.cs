using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Lib
{
    public class Factory
    {
        public static Board CreateNewGameBoard()
        {
            return new Board( NewGameBoardLayout() );
        }

        public static string[] NewGameBoardLayout()
        {
            return new string[9] {"", "", "", "", "", "", "", "", ""};
        }
    }
}
