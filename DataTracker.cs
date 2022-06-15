using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Task2_Thread
{
    internal class DataTracker : ISpecialThread
    {
        public static List<DataRequest> RequestStack = new List<DataRequest>();
        public static DataRequest[] RequestArray = new DataRequest[Program.Sources.Count];

        static int Summ = 0;
        const int LimitSumm = 10000;
        static void Calculate()
        {
            if (RequestStack.Count == 0) return;
            DataRequest item = RequestStack[0];
            if (item == null) return;
            Summ += item.Value;
            RequestArray[item.Index] = item;

            DisplayCurrentItem(item);
            DisplayMinMax();
            DisplaySumm();

            Console.WriteLine();
            RequestStack?.RemoveAt(0);

            if (Summ >= LimitSumm)
            {
                Console.WriteLine("\nSUMM WAS REACHED\n");
                Summ = 0;
            }
        }
        private static void DisplayCurrentItem(DataRequest item)
        {
            Console.Write($"\r NOW: ");
            Console.BackgroundColor = item.Color;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write($" {item.Index}-THREAD: {item.Value.ToString()}; ");
        }
        private static void DisplayMinMax()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;

            DataRequest min = new DataRequest(0, int.MaxValue, ConsoleColor.Black);
            DataRequest max = new DataRequest(0, int.MinValue, ConsoleColor.Black);

            for (int i = 0; i < RequestArray.Length; i++)
            {
                if (RequestArray[i] != null)
                {
                    Console.Write($"[{i}]:{RequestArray[i].Value.ToString().PadRight(5)}");

                    if (max.Value < RequestArray[i].Value) max = RequestArray[i];
                    if (min.Value > RequestArray[i].Value) min = RequestArray[i];
                }
                else Console.Write($"[{i}]:null ");
            }
            Console.Write($" ||| [{max.Index}]: Max; [{min.Index}]: Min;");
        }
        private static void DisplaySumm()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Console.Write($" SUMM: {Summ}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
        public void Start()
        {
            Thread thread = new Thread(new ThreadStart(() =>
            {
                IsBusy = true;
                while (IsBusy) Calculate();
            }));
            thread.Start();
        }
        public void Stop()
        {
            IsBusy = false;
        }
        public bool IsBusy { get; set; }
    }
}
