using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02
{
    public class BusStop
    {
        public delegate void CurrentCount(int a);

        public event CurrentCount OnCurrentCount;

        private int _currentCountPeople;

        private object _locker;

        public BusStop()
        {
            _locker = new object();
        }

        public int CurrentCountPeople
        {
            get
            {
                return _currentCountPeople;
            }

            set
            {
                lock (_locker)
                {
                    _currentCountPeople = value;

                    OnCurrentCount(value);
                }
            }
        }

        public void OnFlowHandler(int number)
        {
            CurrentCountPeople += number;
        }

        public void OnPickUpPeople(int a, int number)
        {
            CurrentCountPeople -= number;
        }

        public void HowPeople(int x)
        {
            CurrentCountPeople = x;
        }
    }
}
