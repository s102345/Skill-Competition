using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace 試題6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            if(textBox1.Text=="")MessageBox.Show("未輸入欲尋找的字串", this.Text);
            else
            {
                int i=0;
                string target = textBox1.Text;
                int ticks = 0;
                richTextBox1.Select(0, richTextBox1.Text.Length);
                richTextBox1.SelectionBackColor = Color.White;
                while (i< richTextBox1.Text.LastIndexOf(target))
                {
                    i = richTextBox1.Text.IndexOf(target,i);
                    richTextBox1.Select(i, target.Length);
                    richTextBox1.SelectionBackColor = Color.Yellow;
                    i++;
                    ticks++;
                }
                label3.Text = ticks+"";
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                StreamReader sr = fi.OpenText();
                while (sr.Peek() > 0)
                {
                    richTextBox1.Text += sr.ReadLine()+'\n';
                }
            }
        }
    }
}
