namespace TicTacToe.ConsoleApplication
{
    public class MessageList
    {
        public string Welcome()
        {
            return "Welcome to Tic Tac Toe!Here's the current board:";
        }

        public string PromptForMove()
        {
            return "Please enter a coordinate x y to place your piece: ";
        }

        public string AcceptedMove ()
        {
            return "Move accepted here's the current board:";
        }
        public string InvalidMove ()
        {
            return "Oh no...a piece is already in this place! Try again...";
        }
        public string InvalidInput ()
        {
            return "Oh no...invalid coordinates. Try entering two numbers for where you would like to play, like this: `1,1`";
        }
        public string ReturnWinner (string player)
        {
            return $"{player} won the game!";
        }
        public string ReturnDraw ()
        {
            return "It was a Draw! Better luck next time.";
        }

        public string OutOfBounds()
        {
            return "Oh no...your coordinates were out of the acceptable range. Rows and Columns are 1 - 3 based on the board. Try again...";
        }

        public string PromptForNewGame()
        {
            return "Would you like to play again? Y / N:";
        }
    }
}