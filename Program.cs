using System;
using System.Collections.Generic;
using System.Threading;

namespace Task2_Thread
{
    internal class Program
    {
        static List<DataSource> sources = new List<DataSource>()
        {
            new DataSource(50, ConsoleColor.DarkRed, 0),
            new DataSource(50, ConsoleColor.Green, 1),
            new DataSource(100, ConsoleColor.Blue, 2),
            new DataSource(100, ConsoleColor.DarkMagenta, 3)
        };
        static List<IDataAnswer> answerStack = new List<IDataAnswer>();
        static int Summ = 0;
        const int LimitSumm = 10000;

        static void Main(string[] args)
        {

            Console.BackgroundColor = ConsoleColor.Black;
            Console.WriteLine("Hello World!");
            Console.WriteLine("Press D to start");



            while (true)
            {
                ConsoleKey key = Console.ReadKey(true).Key;
                if (key == ConsoleKey.D)
                {
                    foreach (var item in sources)
                    {
                        if (item.IsBusy) continue;
                        item.ValueChanged += UpdateValue;
                        item.Start();
                    }
                    Calculate();
                }
            }
        }
        static void UpdateValue(IDataAnswer v)
        {
            answerStack.Add(v);
        }
        static void Calculate()
        {
            while (true)
            {
                if (answerStack.Count == 0) continue;
                IDataAnswer item = answerStack[0];
                if (item == null) continue;
                Summ += item.Value;
                Console.Write($"\r NOW: ");
                Console.BackgroundColor = item.Color;
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write($" {item.Index}-THREAD: {item.Value.ToString().PadLeft(4)};");

                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Write($" SUMM: {Summ}");
                Console.ForegroundColor = ConsoleColor.White;
                Console.BackgroundColor = ConsoleColor.Black;
                Console.WriteLine();
                answerStack.RemoveAt(0);

                if (Summ >= LimitSumm)
                {
                    Console.WriteLine("\nSUMM WAS REACHED\n");
                    Summ = 0;
                }

                if (Console.KeyAvailable)
                {
                    ConsoleKey key = Console.ReadKey(true).Key;
                    if (key == ConsoleKey.Q)
                    {
                        foreach (var source in sources) source.Stop();
                        Summ = 0;
                        answerStack = new List<IDataAnswer>();
                    }
                    else
                    {
                        continue;
                    }
                }
            }
        }
    }
}
