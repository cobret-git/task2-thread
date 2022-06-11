using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task2_Thread
{
    internal class DataSource : IDataSource
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
        public bool IsBusy { get; set; }
        public ConsoleColor Color { get; set; }
        public int Index { get; set; }

        public event IDataSource._ValueChanged ValueChanged;

        public void Start()
        {
            Thread thread = new Thread(new ThreadStart( () =>
            {
                Random rnd = new Random();
                IsBusy = true;
                while (IsBusy)
                {
                    Value = (rnd.Next(1, 8) * 100);
                    ValueChanged?.Invoke(new DataAnswer(Index, Color, Value));
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
