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

        private void Form1_Load(object sender, EventArgs e)
        {
            test();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            test();
            label5.Visible=false; label6.Visible = false; label7.Visible = false; label8.Visible = false; label9.Visible = false; label10.Visible = false;
        }
        private void Button1_Click(object sender, EventArgs e)
        {
            if(Convert.ToInt32(textBox1.Text)* Convert.ToInt32(textBox2.Text)==Convert.ToInt32(textBox3.Text))
            {
                label5.Visible = true;
            }
            else
            {
                label6.Visible = true; label7.Visible = true; label8.Visible = true; label9.Visible = true; label10.Visible = true;
                StupidMethod();
            }
        }
        private void test()
        {
            Random rnd = new Random();
            switch (rnd.Next(0, 2))
            {
                case 0:
                    textBox1.Text = rnd.Next(11, 20) + "";
                    textBox2.Text = rnd.Next(11, 20) + "";
                    break;
                case 1:
                    textBox1.Text = rnd.Next(21, 30) + "";
                    textBox2.Text = rnd.Next(21, 30) + "";
                    break;
            }
        }
        private void StupidMethod()
        {
            int m, n,w;
            m = Convert.ToInt32(textBox1.Text);
            n = Convert.ToInt32(textBox2.Text);
            if (m > 20) w = 20;
            else w = 10;
            label7.Text = "(1)" + m + "+" + n % 10 + "=" + (m + n % 10);
            label8.Text = "(2)" + (m + n % 10) + "X" + w + "=" + (m + n % 10)*w;
            label9.Text = "(3)" + (m  % 10) + "X" + (n % 10) + "=" + (m % 10) * (n % 10);
            label10.Text = "(4)" + (m + n % 10) * w + "X" + (m % 10) * (n % 10) + "=" + ((m + n % 10) * w + (m % 10) * (n % 10));
        }
    }
}
