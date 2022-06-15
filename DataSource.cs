using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task2_Thread
{
    internal class DataSource : ISpecialThread
    {
        public int Frequence
        {
            get;
            set;
        }
        public int Value
        {
            get;
            set;
        }
        public ConsoleColor Color { get; set; }
        public int Index { get; set; }
        public bool IsBusy { get; set; }

        public delegate void _ValueChanged(DataRequest request);
        public event DataSource._ValueChanged ValueChanged;

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                IsBusy = true;
                while (IsBusy)
                {
                    Random rnd = new Random();
                    Value = (rnd.Next(1, 8) * 100);
                    ValueChanged?.Invoke(new DataRequest(Index, Value, Color));
                    Thread.Sleep(Frequence);
                }
            }));
            thread.Start();
        }
        public void Stop()
        {
            IsBusy = false;
        }

        public DataSource(int frequence, ConsoleColor color, int index)
        {
            this.Frequence = frequence;
            this.Color = color;
            this.Index = index;
        }
    }
}
