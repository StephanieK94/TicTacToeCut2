﻿using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.ConsoleApplication
{
    class GameResultModel
    {
        public string[] Board { get; set; }
        public List<PlayerModel> Players { get; set; }
        public string State { get; set; }

        public GameResultModel ()
        {
            Board = new string[9];
            Players = new List<PlayerModel>()
            {
                new PlayerModel(){Piece = "X"},
                new PlayerModel(){Piece = "O"},
            };
            State = "New Model";
        }
    }
}
