using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Players
{
    public class WebPlayer : IWebPlayer
    {
        public string Piece { get; set; }

        public WebPlayer()
        {
            Piece = "X";
        }

        public void ChangePlayer()
        {
            this.Piece = this.Piece == "X" ? "O" : "X";
        }
    }
}
