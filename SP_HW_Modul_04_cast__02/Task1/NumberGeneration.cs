using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02
{
    public class NumberGeneration
    {
        private object _obj;

        public delegate void Generation(string path);

        public event Generation OnGenerate;

        public NumberGeneration()
        {
            _obj = new object();
        }

        public void Generate(int length, ListBox listbox)
        {
            lock (_obj)
            {
                string folderPath = @"..\..\FolderTask1";

                string filePath = $"{folderPath}\\Generate.txt";

                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                if (!File.Exists(filePath))
                {
                    File.Create(filePath).Close();
                }

                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    listbox.Items.Clear();

                    for (int i = 0; i < length; i++)
                    {
                        int a = GiveNumber(0, 10);

                        int b = GiveNumber(0, 10);

                        listbox.Items.Add(a + " " + b);

                        sw.WriteLine(a + " " + b);
                    }
                }

                OnGenerate(filePath);
            }
        }

        public int GiveNumber(int min, int max)
        {
            Thread.Sleep(10);

            return new Random().Next(min, max);
        }
    }
}
