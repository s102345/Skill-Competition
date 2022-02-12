using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            textBox4.Clear();
            textBox1.Text = output(1);
            textBox2.Text = output(8);
            textBox3.Text = output(23);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            double S, E=0;
            double M=1;
            string buf;
            S = Convert.ToInt32(textBox1.Text);
            buf = textBox2.Text;
            for(int i = 0; i < 8; i++)
            {
                E += (buf[i]-'0') * Math.Pow(2, (7-i));
            }
            E -= 127;         
            buf = textBox3.Text;
            for(int i = 0; i < 23; i++)
            {
                M += (buf[i]-'0') * Math.Pow(0.5, i+1);
            }
            if (S == 1) M *=-1;
            M *= Math.Pow(2, E);
            textBox4.Text = M+"";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public string output(int length)
        {
            string str = "";
            Random rnd = new Random();
            for (int i = 0; i < length; i++)
            {
                str += Convert.ToString(rnd.Next(0, 2));
            }
            return str;
        }
    }
}
