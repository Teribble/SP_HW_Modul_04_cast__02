using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public class BusStation
    {
        /// <summary>
        /// Событие, возникающее при изменении конекретного количества людей
        /// </summary>
        public event Action<List<Human>> OnCurrentPeople;

        public event Action<List<Human>> OnClarification;

        private object _locker;

        /// <summary>
        /// Автобусная остановка
        /// </summary>
        public BusStation()
        {
            _locker = new object();

            CurrentPeople = new List<Human>();
        }
        /// <summary>
        /// Конкретное количество людей
        /// </summary>
        public List<Human> CurrentPeople;
        /// <summary>
        /// Приходящие люди
        /// </summary>
        /// <param name="number">Кол-во людей, которые пришли на остановку</param>
        public void NewCurrentPeople(List<Human> people)
        {
            lock (_locker)
            {
                CurrentPeople.AddRange(people);

                OnCurrentPeople(CurrentPeople);
            }
        }
        /// <summary>
        /// Уточнение сколько людей по факту стоит на остановке
        /// </summary>
        public void Clarification()
        {
            OnClarification(CurrentPeople);
        }
        /// <summary>
        /// Автобус забрал людей
        /// </summary>
        /// <param name="number">Сколько людей забрал</param>
        /// <param name="BusNumber">Номер автобуса</param>
        public void TakeBus(List<Human> people, int BusNumber)
        {
            lock (_locker)
            {
                CurrentPeople.RemoveAll(n => n.PreferredNumber == BusNumber);

                OnCurrentPeople(CurrentPeople);
            }
        }
    }
}
