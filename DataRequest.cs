using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Thread
{
    internal class DataRequest
    {
        public int Index { get; set; }
        public int Value { get; set; }
        public ConsoleColor Color { get; set; }
        public DataRequest(int index, int value, ConsoleColor color)
        {
            Index = index;
            Value = value;
            Color = color;
        }

    }
}
