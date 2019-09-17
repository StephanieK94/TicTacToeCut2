using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicTacToe;
using TicTacToe.Boards;

namespace TicTacToeCut2.Api.Converters
{
    public class BoardConverter
    {
        public Board ConvertWebApiBoardToConsoleBoard(string[] webBoard)
        {
            var consoleBoard = new Board();
            var z = 0;

            for (var x = 0; x < 2; x++)
            {
                for (var y = 0; y < 2; y++)
                {
                    consoleBoard.Layout[x, y] = ConvertToEnum(webBoard[z++]);
                }
            }
            return consoleBoard;
        }

        public string[] ConvertConsoleBoardToWebApiBoard(Board board)
        {
            var webBoard = new string[9];
            var z = 0;

            for ( var x = 0 ; x < 2 ; x++ )
            {
                for ( var y = 0 ; y < 2 ; y++ )
                {
                    webBoard[z++] = ConvertEnumToString(board.Layout[x, y]);
                }
            }
            return webBoard;
        }

        private string ConvertEnumToString(BoardPiece boardPiece)
        {
            switch (boardPiece)
            {
                case BoardPiece.X:
                    return "X";
                case BoardPiece.O:
                    return "O";
                default:
                    return "";
            }
        }

        private BoardPiece ConvertToEnum ( string piece )
        {
            switch ( piece )
            {
                case "X":
                    return BoardPiece.X;
                case "O":
                    return BoardPiece.O;
                default:
                    return BoardPiece.None;
            }
        }
    }
}
