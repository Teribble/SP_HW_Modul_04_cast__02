using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public partial class Task2 : Form
    {
        //Список "потоков" людей
        private List<Passenger> _passengers;

        // Автобусна остановка
        private BusStation _busStation;

        //Списое автобусов на маршруте
        private List<Bus> _buses;

        //Кол-во автобусов на маршруте
        private int _busCount;

        /// <summary>
        /// Конструктор формы второго задания
        /// </summary>
        public Task2()
        {
            InitializeComponent();

            Initial();

            Subscribe();
        }

        /// <summary>
        /// Метод упрощения инициализации полей класса, а так же элементов интерфейса
        /// </summary>
        private void Initial()
        {
            _passengers = new List<Passenger>();

            _busStation = new BusStation();

            _buses = new List<Bus>();

            label2.Text = Convert.ToString(_busStation.CurrentPeople);

            label3.Text = $"Время потока каждые 3 секунды";
        }


        private void PassegerHandle(int count)
        {
            listBox1.Invoke(new Action(() =>{
                listBox1.Items.Add($"На остановку пришли новые люди в количестве {count}");
                listBox1.Items.Add($"- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            }));
        }

        private void BusHandler(int count, int BusNumber)
        {
            listBox1.Invoke(new Action(() => {
                listBox1.Items.Add($"Автобус {BusNumber} забрал {count} пассажир");
                listBox1.Items.Add($"- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -");
            }));
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            var passenger = new Passenger(3);

            passenger.OnGenerate += PassegerHandle;

            passenger.OnGenerate += _busStation.NewCurrentPeople;

            _passengers.Add(passenger);

            _passengers.Last().StartGenerate();
        }

        private void OnButton2Click(object sender, EventArgs e)
        {
            foreach (var passenger in _passengers)
            {
                passenger.StopGenerate();
            }
        }

        private void OnButton3Click(object sender, EventArgs e)
        {
            label5.Text = Convert.ToString(_busCount++);

            var newBus = new Bus(70, new Random().Next(0, 200), 3);

            newBus.OnHowPeople += _busStation.Clarification;

            newBus.OnTake += _busStation.TakeBus;

            newBus.OnTake += BusHandler;

            _busStation.OnClarification += newBus.HowCurrentPeople;

            _buses.Add(newBus);

            _buses.Last().BusStart();
        }

        private void OnButton4Click(object sender, EventArgs e)
        {
            foreach (var bus in _buses)
            {
                bus.BusStop();
            }
        }

        private void Subscribe()
        {
            _busStation.OnCurrentPeople += CurrentPeopleHandler;
        }

        private void OnFormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (var passenger in _passengers)
            {
                passenger.StopGenerate();
            }

            foreach (var bus in _buses)
            {
                bus.BusStop();
            }
        }

        private void CurrentPeopleHandler(int number)
        {
            label2.Invoke(new Action(() =>
            {
                label2.Text = Convert.ToString(number);
            }));
        }
    }
}
