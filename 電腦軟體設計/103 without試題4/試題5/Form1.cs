using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (textBox1.Text == "" && textBox2.Text == "") B();
            else A();
        }
        private void B()
        {
            int t = 0;
            string[] sn = textBox3.Text.Split(new char[2] { ',', ' ' });
            for(int i=0;i<sn.Length;i++)
            {
                System.Diagnostics.Debug.Print(sn[i]);
                if (sn[i] == "") continue;
                richTextBox1.Text += getC(sn[i]) + "@antu.edu.tw";
                if (i!=sn.Length-1) richTextBox1.Text += ";";
                t++;
                if (t == 3)
                {
                    t = 0;
                    richTextBox1.Text += '\n';
                }
            }
        }
        private void A()
        {
            int Min, Max;
            int t=0;
            Min = Convert.ToInt32(textBox1.Text);
            Max = Convert.ToInt32(textBox2.Text);
            for(int i = Min; i <= Max; i++)
            {
                richTextBox1.Text += getC(Convert.ToString(i))+"@antu.edu.tw";
                if (i != Max) richTextBox1.Text += ";";
                t++;
                if (t ==3)
                {
                    t = 0;
                    richTextBox1.Text+='\n';
                }
                
            }
        }
        private string getC(string N)
        {
            int[] table = new int[] { 0, 7, 4, 1, 8, 5, 2, 9, 6, 3 };
            int sum=0;
            for(int i = 0; i < 8; i++)
            {
                sum += (N[i] - '0') * (i + 1);
            }
            N += Convert.ToString(table[sum % 10]);
            return N;
        }
    }
}
