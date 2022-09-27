using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public partial class Task2Form : Form
    {
        FlowOfPeople _flowOfPeople;

        BusStop _busStop;

        Bus _bus;

        public Task2Form()
        {
            InitializeComponent();

            _flowOfPeople = new FlowOfPeople();

            _busStop = new BusStop();

            _bus = new Bus(01525, 70);

            _flowOfPeople.OnNewPeople += _busStop.OnFlowHandler;

            _flowOfPeople.OnNewPeople += Hand;

            _bus.OnTake += _busStop.OnPickUpPeople;

            _bus.OnTake += Hand1;

            _busStop.OnCurrentCount += _flowOfPeople.HowPeople;

            _busStop.OnCurrentCount += _bus.HowPeople;

            _flowOfPeople.Start();

            _bus.Start(_busStop.CurrentCountPeople);
        }

        private void Hand(int x)
        {
            listBox1.Invoke(new Action(() =>
            {
                listBox1.Items.Add("");

                listBox1.Items.Add($"На остановку пришло {x} новых людей");

                listBox1.Items.Add($"Общее количество {_busStop.CurrentCountPeople}");

                listBox1.Items.Add("");
            }));
        }

        private void Hand1(int x, int a)
        {
            listBox1.Invoke(new Action(() =>
            {
                listBox1.Items.Add("");

                listBox1.Items.Add($"Атобус {x} забрал {a} пассажиров");

                listBox1.Items.Add($"Общее количество {_busStop.CurrentCountPeople}");

                listBox1.Items.Add("");
            }));
        }
    }
}
