namespace TicTacToe.Lib.Converters
{
    public class BoardConverter
    {
        public BoardPiece[,] ConvertWebApiBoardToConsoleBoard(string[] webBoard)
        {
            var consoleBoard = new BoardPiece[3,3];
            var z = 0;

            for (var x = 0; x <= 2; x++)
            {
                for (var y = 0; y <= 2; y++)
                {
                    consoleBoard[x, y] = ConvertToEnum(webBoard[z++]);
                }
            }
            return consoleBoard;
        }

        public string[] ConvertConsoleBoardToWebApiBoard(BoardPiece[,] board)
        {
            var webBoard = new string[9];
            var z = 0;

            for ( var x = 0 ; x <= 2 ; x++ )
            {
                for ( var y = 0 ; y <= 2 ; y++ )
                {
                    webBoard[z++] = ConvertEnumToString(board[x, y]);
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
