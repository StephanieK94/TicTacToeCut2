using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Boards;
using TicTacToe.Messages;
using TicTacToe.Players;

namespace TicTacToe
{
    public class Factory
    {
        public static Player CreateConsolePlayer()
        {
            return new Player();
        }

        public static Board CreateConsoleBoard()
        {
            return new Board();
        }

        public static MessageProcessor CreateConsoleMsgProcessor()
        {
            return new MessageProcessor();
        }

        public static WinCalculator CreateConsoleWinCalculator()
        {
            return new WinCalculator();
        }
    }
}
