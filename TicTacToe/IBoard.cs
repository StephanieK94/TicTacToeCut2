namespace TicTacToe
{
    public interface IBoard
    {
        void PlayMoveOnBoard(Player currentPlayer, Move currentMove);
        bool ValidatePositionIsEmpty(Move currentMove);
    }
}