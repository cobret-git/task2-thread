using System;

namespace Task2_Thread
{
    internal interface IDataSource
    {
        public void Stop();
        public void Start();
        public int Frequence { get; set; }
        public int Value { get; set; }
        public bool IsBusy { get; set; }
        public int Index { get; set; }
        public ConsoleColor Color { get; set; }

        public delegate void _ValueChanged(IDataAnswer newValue);
        public event _ValueChanged ValueChanged;
    }
}
