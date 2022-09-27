using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02
{
    public partial class Task1Form : Form
    {
        private string _path;

        private string _pathOne;

        private string _pathTwo;

        private string _pathThree;

        private NumberGeneration _number;

        private FindTheAmount _findTheAmount;

        private FindAPiece _findAPiece;

        public Task1Form()
        {
            InitializeComponent();

            _number = new NumberGeneration();

            _findTheAmount = new FindTheAmount();

            _findAPiece = new FindAPiece();

            _number.OnGenerate += OnPathOneHandler;

            _findTheAmount.OnFinding += OnPathTwoHandler;

            _findAPiece.OnFinding += OnPathThreeHandler;

            _path = @"..\..\FolderTask1";
        }

        private void OnButton1Click(object sender, EventArgs e)
        {
            _number.Generate(10, listBox1);

            button2.Enabled = true;

            _findTheAmount.Search(_pathOne, listBox2);

            _findAPiece.Search(_pathOne, listBox3);
        }

        private void OnPathOneHandler(string message)
        {
            _pathOne = message;
        }

        private void OnPathTwoHandler(string message)
        {
            _pathTwo = message;
        }

        private void OnPathThreeHandler(string message)
        {
            _pathThree = message;
        }

        private void OnButton2Click(object sender, EventArgs e)
        {
            Process.Start("explorer", _path);
        }

        private void OnButton3Click(object sender, EventArgs e)
        {
            Process.Start(_pathOne);
        }

        private void OnButton4Click(object sender, EventArgs e)
        {
            Process.Start(_pathTwo);
        }

        private void OnButton5Click(object sender, EventArgs e)
        {
            Process.Start(_pathThree);
        }
    }
}
