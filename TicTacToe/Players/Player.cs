﻿namespace TicTacToe.Players
{
    public class Player : IPlayer
    {
        public BoardPiece Character { get; set; }

        public Move LastMove { get; set; }

        // Default constructor for Player to be an X when the game starts
        public Player()
        {
            Character = BoardPiece.X;
        }

        public void ChangePlayer()
        {
            this.Character = (this.Character == BoardPiece.X) ? BoardPiece.O : BoardPiece.X;
        }
    }
}