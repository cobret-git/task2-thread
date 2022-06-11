using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Thread
{
    internal class DataAnswer : IDataAnswer
    {
        public int Index { get; set; }
        public ConsoleColor Color { get; set; }
        public int Value { get; set; }
        public DataAnswer(int index, ConsoleColor color, int value)
        {
            this.Index = index;
            this.Color = color;
            this.Value = value;
        }
    }
}
