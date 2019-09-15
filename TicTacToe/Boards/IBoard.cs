using TicTacToe.Players;

namespace TicTacToe.Boards
{
    public interface IBoard
    {
        void PlayMoveOnBoard(Player currentPlayer, Move currentMove);
        bool ValidatePositionIsEmpty(Move currentMove);
    }
}