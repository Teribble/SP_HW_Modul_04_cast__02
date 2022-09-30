using System;
using System.Collections.Generic;
using System.Threading;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public class Bus
    {
        /// <summary>
        /// Возникает при заборе пассажир с остановки
        /// </summary>
        public event Action<List<Human>, int> OnTake;

        /// <summary>
        /// Возникает при заборе пассажир с остановки для уточнения, сколько именно пассажир на остановке
        /// </summary>
        public event Action OnHowPeople;
        /// <summary>
        /// Размер автобуса
        /// </summary>
        public int Capasity { get; set; }

        /// <summary>
        /// Номер автобуса
        /// </summary>
        public int NumberBus { get; set; }

        /// <summary>
        /// Время езды автобуса
        /// </summary>
        private int _second;

        /// <summary>
        /// Поток
        /// </summary>
        private Thread _thread;

        /// <summary>
        /// Едет ли автобус
        /// </summary>
        private bool _isStarted;

        /// <summary>
        /// Текущее кол-во пассажиров на остановке
        /// </summary>
        private List<Human> _currentPeople;

        private object _locker;

        /// <summary>
        /// Автобус
        /// </summary>
        /// <param name="capasity">Вместимость автобуса</param>
        /// <param name="numberBus">Номер автобуса</param>
        /// <param name="second">Время, через которое приезжает автобус на остановку</param>
        public Bus(int capasity, int numberBus, int second)
        {
            Capasity = capasity;

            NumberBus = numberBus;

            _isStarted = false;

            _second = second * 1000;

            _thread = new Thread(Take);

            _locker = new object();
        }

        /// <summary>
        /// Забор пассажир
        /// </summary>
        private void Take()
        {
            lock (_locker)
            {
                while (_isStarted)
                {
                    OnHowPeople();

                    int _currentHumansInBus = new Random().Next(0, Capasity);

                    List<Human> list = new List<Human>();

                    foreach (var people in _currentPeople)
                    {
                        if (people.PreferredNumber == NumberBus && list.Count <= (Capasity - _currentHumansInBus))
                        {
                            list.Add(people);
                        }
                    }

                    OnTake(list, NumberBus);

                    Thread.Sleep(_second);
                }
            }
        }

        /// <summary>
        /// Сколько пассажиров на остновке
        /// </summary>
        /// <param name="number"></param>
        public void HowCurrentPeople(List<Human> people)
        {
            _currentPeople = people;
        }

        /// <summary>
        /// Пустить автобус на маршрут
        /// </summary>
        public void BusStart()
        {
            if (!_isStarted)
            {
                _isStarted = true;

                _thread.Start();
            }
        }

        /// <summary>
        /// Снять автобус с маршрута
        /// </summary>
        public void BusStop()
        {
            _thread.Abort();
        }
    }
}
