using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public class Passenger
    {
        /// <summary>
        /// Событие, возникает при новой волне людей
        /// </summary>
        public event Action<int> OnGenerate;
        // Время, через которое будут приходить новые люди
        private int _second;

        public int Second => _second;

        // Запущен ли процесс прихода людей
        private bool _isGenerate;

        // Поток
        private Thread _thread;

        /// <summary>
        /// Пассажир
        /// </summary>
        /// <param name="sec">Укажите время через которое будут приходить новые люди</param>
        public Passenger(int sec)
        {
            _second = sec * 1000;

            _isGenerate = false;

            _thread = new Thread(Gen);
        }
        /// <summary>
        /// Запустить поток людей
        /// </summary>
        public void StartGenerate()
        {
            _isGenerate = true;

            _thread.Start();
        }

        private void Gen()
        {
            while (_isGenerate)
            {
                var buffer = new Random().Next(0, 100);

                OnGenerate(buffer);

                Thread.Sleep(_second);
            }
        }
        /// <summary>
        /// Остановить поток людей
        /// </summary>
        public void StopGenerate()
        {
            _thread.Abort();
        }
    }
}
