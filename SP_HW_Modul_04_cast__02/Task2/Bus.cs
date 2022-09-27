using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public class Bus
    {
        private int currentPeopleBusStop;

        public delegate void BusDelegate(int id, int number);

        public event BusDelegate OnTake;

        public int Bus_Id { get; set; }

        public int Capacity { get; set; }

        private bool isGo;

        private object _locker;

        public Bus(int id, int capacity)
        {
            Bus_Id = id;

            Capacity = capacity;

            isGo = false;

            _locker = new object();
        }

        public void Start(int current)
        {
            isGo = true;

            Take();
        }

        public void Stop()
        {
            isGo = false;
        }

        public void Take()
        {
            Task.Run(new Action(() =>
            {
                if (isGo)
                {
                    while (true)
                    {
                        Thread.Sleep(10);

                        Thread.Sleep(new Random().Next(5000, 10000));

                        lock (_locker)
                        {
                            if (currentPeopleBusStop > Capacity)
                            {
                                currentPeopleBusStop -= Capacity;

                                OnTake(Bus_Id, currentPeopleBusStop);
                            }
                            else if (currentPeopleBusStop < Capacity)
                            {
                                int buffer = Capacity - currentPeopleBusStop;

                                currentPeopleBusStop -= buffer;

                                OnTake(Bus_Id, currentPeopleBusStop);
                            }
                            else
                            {
                                OnTake(Bus_Id, 0);
                            }
                        }
                    }

                }

            }));
        }

        public void HowPeople(int x)
        {
            currentPeopleBusStop = x;
        }
    }
}
