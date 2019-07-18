﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe
{
    public class Player
    {
        private BoardPiece _character;

        public BoardPiece Character { get { return _character; } set { _character = value; } }

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
