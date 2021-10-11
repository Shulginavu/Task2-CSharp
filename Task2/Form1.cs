using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = openFileDialog1.FileName;
            string fileText = System.IO.File.ReadAllText(filename);
            richTextBox1.Text = fileText;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
                richTextBox2.Text = find(richTextBox1.Text, Int32.Parse(textBox1.Text));
        }
        static string find(string text, int number)
        {
            string s = "";
            int k = 0;
            for (int i = 0; i < text.Length; i++)
                if (number + '0' == text[i] && text[i + 1] == '.' && Regex.IsMatch(text[i+2].ToString(), @"\s"))
                {
                    k = i;
                    break;
                }

            for (; k < text.Length; k++)
            {
                if (text[k] == (number + 1 + '0') && text[k + 1] == '.' && Regex.IsMatch(text[k + 2].ToString(), @"\s")) break;
                else
                {
                    s += text[k];
                }
            }
            return s;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = saveFileDialog1.FileName;
            // сохраняем текст в файл
            System.IO.File.WriteAllText(filename, richTextBox2.Text);
        }
    }
}
