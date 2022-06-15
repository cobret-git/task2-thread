using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Task2_Thread
{
    internal class Program
    {
        public static List<DataSource> Sources = new List<DataSource>()
        {
            new DataSource(5000, ConsoleColor.DarkRed, 0),
            new DataSource(5000, ConsoleColor.Green, 1),
            new DataSource(5000, ConsoleColor.Blue, 2),
            new DataSource(5000, ConsoleColor.DarkMagenta, 3)
        };

        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Hello World!");
            Console.WriteLine("\"D\" For start, \"Q\" For Stop");

            Thread checkConsoleThread = new Thread(new ThreadStart(CheckConsoleKey));

            checkConsoleThread.Start();
        }
        static void UpdateValue(DataRequest v)
        {
            DataTracker.RequestStack.Add(v);
        }
        
        static void CheckConsoleKey()
        {
            DataTracker calculationThread = new DataTracker();
            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D)
                {
                    calculationThread.Start();
                    Console.WriteLine("STARTED");
                    foreach (var source in Sources)
                    {
                        if (source.IsBusy) continue;
                        source.ValueChanged += UpdateValue;
                        source.Start();
                    }
                }
                else if(key == ConsoleKey.Q)
                {
                    if (!calculationThread.IsBusy) continue;
                    calculationThread.Stop();
                    Console.WriteLine("\rSTOPED");
                    foreach (var source in Sources)
                    {
                        source.Stop();
                        source.ValueChanged -= UpdateValue;
                    }
                }
            }
        }
    }
}
