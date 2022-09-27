using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SP_HW_Modul_04_cast__02
{
    public class FindTheAmount
    {
        private object _obj = new object();

        public delegate void Find(string message);

        public event Find OnFinding;

        public void Search(string path, ListBox listbox)
        {
            listbox.Items.Clear();

            string buffer = string.Empty;

            string newPath = path + nameof(FindTheAmount);

            lock (_obj)
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    buffer = sr.ReadToEnd();
                }
            }

            if (!File.Exists(newPath))
            {
                File.Create(newPath).Close();
            }

            using (StreamWriter sw = new StreamWriter(newPath))
            {
                var list = buffer.Split('\n').ToList();

                foreach (var str in list)
                {
                    if (str != "")
                    {
                        var newStr = str.Split(' ');

                        int a = Int32.Parse(newStr[0]);

                        int b = Int32.Parse(newStr[1]);

                        sw.WriteLine(a + b);

                        listbox.Items.Add(a + b);
                    }
                }
            }

            OnFinding(newPath);
        }
    }
}
