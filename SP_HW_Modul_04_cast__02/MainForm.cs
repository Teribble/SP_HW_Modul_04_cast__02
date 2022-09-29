using System;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02.Task2
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            new Task1Form().Show();
        }

        private void OnButton2Click(object sender, EventArgs e)
        {
            new Task2().Show();
        }
    }
}
