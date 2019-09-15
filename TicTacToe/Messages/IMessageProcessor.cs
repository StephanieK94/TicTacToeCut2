namespace TicTacToe.Messages
{
    public interface IMessageProcessor
    {
        string PrintWelcome();
        string ReturnWinner(string player);
        string ReturnDraw();
    }
}