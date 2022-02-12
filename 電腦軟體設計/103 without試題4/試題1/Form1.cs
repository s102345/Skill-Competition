using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double x, y, z, a, b, c;
        private void Button1_Click(object sender, EventArgs e)
        {
            label19.Text = "";
            Initialize();
            if (label19.Text == "無解") return;

            label19.Text = "在台北市的上班族遲到機率為：" + (a * x + b * y + c * z);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            label19.Text = "";
            Initialize();
            if (label19.Text == "無解") return;
            label19.Text = "如果已知有一個人上班遲到，那他是自己開車的機率為："+(c /(a * x + b * y + c * z)*z/(x+y+z));
        }
        private void Initialize()
        {
            x = Convert.ToDouble(textBox1.Text);
            if (x > 1 || x < 0) label19.Text = "無解";
            y = Convert.ToDouble(textBox2.Text);
            if (y > 1 || y < 0) label19.Text = "無解";
            z = Convert.ToDouble(textBox3.Text);
            if (z > 1 || z < 0) label19.Text = "無解";
            a = Convert.ToDouble(textBox4.Text);
            if (a > 1 || a < 0) label19.Text = "無解";
            b = Convert.ToDouble(textBox5.Text);
            if (b > 1 || b < 0) label19.Text = "無解";
            c = Convert.ToDouble(textBox6.Text);
            if (c > 1 || c < 0) label19.Text = "無解";
        }
        private void Button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
