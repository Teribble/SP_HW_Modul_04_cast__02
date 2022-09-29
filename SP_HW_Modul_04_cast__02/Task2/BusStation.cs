using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

///РАЗОБРАТЬСЯ ПОЧЕМУ ПОСЛЕ ДОБАВЛЕНИЯ АВТОБУСА, ИЗ-ЗА НОВОГО ПОТОКА ПРЕДЫДУЩИЙ ОТРАБАТЫВАЕТ ДВА РАЗА

namespace SP_HW_Modul_04_cast__02.Task2
{
    public class BusStation
    {
        /// <summary>
        /// Событие, возникающее при изменении конекретного количества людей
        /// </summary>
        public event Action<int> OnCurrentPeople;

        public event Action<int> OnClarification;
        private object _locker;
        /// <summary>
        /// Конкретное количество людей
        /// </summary>
        private int _currentPeople;

        /// <summary>
        /// Автобусная остановка
        /// </summary>
        public BusStation()
        {
            _locker = new object();
        }
        /// <summary>
        /// Конкретное количество людей
        /// </summary>
        public int CurrentPeople
        {
            get
            {
                return _currentPeople;
            }

            set
            {
                _currentPeople = value;
            }
        }
        /// <summary>
        /// Приходящие люди
        /// </summary>
        /// <param name="number">Кол-во людей, которые пришли на остановку</param>
        public void NewCurrentPeople(int number)
        {
            CurrentPeople += number;

            OnCurrentPeople(CurrentPeople);
        }
        /// <summary>
        /// Уточнение сколько людей по факту стоит на остановке
        /// </summary>
        public void Clarification()
        {
            OnClarification(_currentPeople);
        }
        /// <summary>
        /// Автобус забрал людей
        /// </summary>
        /// <param name="number">Сколько людей забрал</param>
        /// <param name="BusNumber">Номер автобуса</param>
        public void TakeBus(int number, int BusNumber)
        {
            CurrentPeople -= number;

            OnCurrentPeople(CurrentPeople);
        }
    }
}
