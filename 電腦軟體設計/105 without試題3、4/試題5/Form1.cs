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
            Random rnd = new Random();
            textBox1.Text = Convert.ToChar(rnd.Next('a', 'z'))+"";
            textBox2.Text = Convert.ToChar(rnd.Next('a', 'z')) + "";
            textBox3.Text = Convert.ToChar(rnd.Next('a', 'z')) + "";
            textBox4.Text = Convert.ToChar(rnd.Next('a', 'z')) + "";
            textBox5.Text = rnd.Next(1,999) + "";
            textBox6.Text = rnd.Next(1, 999) + "";
            textBox7.Text = rnd.Next(1, 999) + ""; 
            textBox8.Text = rnd.Next(1, 999) + "";
            textBox10.Clear(); textBox12.Clear(); textBox13.Clear();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            int[] times = { Convert.ToInt32(textBox5.Text), Convert.ToInt32(textBox6.Text), Convert.ToInt32(textBox7.Text), Convert.ToInt32(textBox8.Text) };
            double sum1=0, sum2=0;
            sum1 =times.Sum()*2;
            textBox12.Text = sum1+"";
            Array.Sort(times);
            sum2 += 3 * times[0] + 3 * times[1] + 2 * times[2] + 1 * times[3];
            textBox10.Text = sum2 + "";
            textBox13.Text = Math.Round(sum1 / sum2,4) + "";
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
