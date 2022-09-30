using System;
using System.Threading;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public class Human
    {
        public int PreferredNumber;

        public Human()
        {
            PreferredNumber = new Random().Next(100, 110);

            Thread.Sleep(10);
        }
    }
}
