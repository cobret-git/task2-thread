using System;
using System.Collections.Generic;
using System.Text;

namespace Task2_Thread
{
    internal interface ISpecialThread
    {
        public bool IsBusy { get; set; }
        public void Start();
        public void Stop();
    }
}
