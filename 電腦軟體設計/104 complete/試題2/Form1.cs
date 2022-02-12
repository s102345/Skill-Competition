using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox2.Clear();
            
            foreach(string s in richTextBox1.Lines)
            {
                richTextBox2.Text+=Encode(s)+'\n';
            }
        }
        public string Encode(string s)
        {
            int[] table = new int[] { 0, 1, 2, 3, 0, 1, 2, 0, 0, 2, 2, 4, 5, 5, 0, 1, 2, 6, 2, 3, 0, 1, 0, 2, 0, 2 };
            int last,tick=0;
            string result="";
            result += s[0];
            last = table[s[0] - 'A'];
            for (int i = 1; i < s.Length; i++)
            {
                if (table[s[i] - 'A'] == 0)
                {
                    last = 0;
                    continue;
                }
                else
                {
                    if (table[s[i] - 'A'] != last)
                    {
                        result += table[s[i] - 'A'];
                        last = table[s[i] - 'A'];
                        tick++;                       
                    }
                }
                if (tick == 3) break;
            }
            if (tick < 3)
            {
                for(int i = tick; i < 3; i++)
                {
                    result += "0";
                }
            }
            return result;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }
    }
}
