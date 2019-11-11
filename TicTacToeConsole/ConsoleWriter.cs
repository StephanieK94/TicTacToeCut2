using System;

namespace TicTacToe.ConsoleApplication
{
    public class ConsoleWriter
    {
        public void PrintOutput(string text)
        {
            Console.WriteLine("\n" + text + "\n");
        }

        public void PrintBoard(string[] board)
        {
            var k = 0;
            for (var row = 0; row < 3; row++)
            {
                Console.WriteLine("");

                for (var column = 0; column < 3; column++)
                {
                    Console.Write(board[k] == ""
                        ? " * "
                        : $" {board[k]} ");
                    k++;
                }

                Console.WriteLine("");
            }
        }
    }
}