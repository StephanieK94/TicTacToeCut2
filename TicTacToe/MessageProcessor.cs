using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace TicTacToe.ConsoleApplication
{
    public class MessageProcessor
    {

        private readonly string _filePath;

        public Dictionary<string, string> ConsoleMessages { get; set; }

        public MessageProcessor()
        {
            _filePath = Path.GetDirectoryName( System.AppDomain.CurrentDomain.BaseDirectory );
            _filePath = Directory.GetParent( Directory.GetParent( _filePath ).FullName ).FullName;
            _filePath = Directory.GetParent( Directory.GetParent( _filePath ).FullName ).FullName;

            ConsoleMessages = ReadMessagesFromFile(_filePath);
        }

        public Dictionary<string , string> ReadMessagesFromFile (string filePath)
        {
            var messageFilePath = filePath += "\\TicTacToe\\ConsoleMessages.csv";

            return File.ReadLines( messageFilePath )
                .Select( line => line.Split( ',' ) )
                .ToDictionary( line => line[0] , line => line[1] );
        }
    }
}
