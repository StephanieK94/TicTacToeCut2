using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks.Dataflow;
using NUnit.Framework.Constraints;
using TicTacToe.Lib;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleGame
    {
        public int TurnCount { get; set; }
        public string[] Board { get; set; }
        public string CurrentPlayer { get; set; }
        public ConsoleMove CurrentMove { get; set; }
        public ConsoleWinCalculator WinCalculator { get; set; }
        public ConsoleWriter ConsoleWriter { get; set; }
        public Messages Message { get; set; }
        public ConsoleReader ConsoleReader { get; set; }
    }
}
