using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Thread
{
    internal interface IDataAnswer
    {
        public int Index { get; set; }
        public ConsoleColor Color { get; set; }
        public int Value { get; set; }
    }
}
