using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02
{
    public class FlowOfPeople
    {
        private int currentPeopleBusStop;

        public delegate void NewPeople(int number);

        public event NewPeople OnNewPeople;

        private bool _isGo;

        public FlowOfPeople()
        {
            _isGo = false;
        }

        private void GeneratePepople()
        {
            Task.Run(() =>
            {
                if (_isGo)
                {
                    while (true)
                    {
                        Thread.Sleep(30);

                        Thread.Sleep(new Random().Next(3000, 10000));

                        OnNewPeople(new Random().Next(1, 100));
                    }
                }
            });
        }

        public void Start()
        {
            _isGo = true;

            GeneratePepople();
        }

        public void Stop()
        {
            _isGo = false;
        }

        public void HowPeople(int x)
        {
            currentPeopleBusStop = x;
        }
    }
}
