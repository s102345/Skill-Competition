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


namespace 試題4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        double[] n1 = new double[10];
        double[] n2 = new double[10];
        double[] n3 = new double[10];
        private void 選取資料ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for(int i = 0; i < 10; i++)
            {
                n1[i] = -1.0;
                n2[i] = -1.0;
                n3[i] = -1.0;
            }
            if (openFileDialog1.ShowDialog()== DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                StreamReader sr = fi.OpenText();
                string str;
                richTextBox1.Clear();
                while (sr.Peek()>0)
                {
                    str = sr.ReadLine();
                    string[] buf = str.Split(' ');
                    richTextBox1.Text += str + '\n';
                    switch (buf[0])
                    {
                        case "麵[1]:":
                            for(int i=1;i<buf.Length;i++)
                            {
                                n1[i - 1] = Convert.ToDouble(buf[i]);
                            }
                            break;
                        case "麵[2]:":
                            for (int i = 1; i < buf.Length; i++)
                            {
                                n2[i - 1] = Convert.ToDouble(buf[i]);
                            }
                            break;
                        case "麵[3]:":
                            for (int i = 1; i < buf.Length; i++)
                            {
                                n3[i - 1] = Convert.ToDouble(buf[i]);
                            }
                            break;
                    }
                }
                sr.Close();
            }
        }

        private void 結束ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void 求F統計和自由度dfToolStripMenuItem_Click(object sender, EventArgs e)
        {
            double ut1 = 0, ut2 = 0, ut3 = 0, UT, N1=0, N2=0, N3=0, N, SSb, SSw = 0, dfb = 2, dfw,MSb,MSw,F;
            foreach (double buf in n1)
            {
                if (buf == -1.0)
                {
                    break;
                }
                N1++;
                ut1 += buf;
            }
            foreach (double buf in n2)
            {
                if (buf == -1.0)
                {
                    break;
                }
                N2++;
                ut2 += buf;
            }
            foreach (double buf in n3)
            {
                if (buf == -1.0)
                {
                    break;
                }
                N3++;
                ut3 += buf;
            }
            N = N1 + N2 + N3;
            UT = ut1 + ut2 + ut3;
            ut1 /= N1;
            ut2 /= N2;
            ut3 /= N3;
            UT /= N;
            dfw = N - 3;
            SSb = N1*Math.Pow(ut1 - UT,2)+ N2*Math.Pow(ut2 - UT, 2)+N3*Math.Pow(ut3 - UT, 2);       
            foreach (double buf in n1)
            {
                if (buf == -1.0)
                {
                    break;
                }
                SSw += Math.Pow(buf - ut1,2);
            }
            foreach (double buf in n2)
            {
                if (buf == -1.0)
                {
                    break;
                }
                SSw += Math.Pow(buf - ut2, 2);
            }
            foreach (double buf in n3)
            {
                if (buf == -1.0)
                {
                    break;
                }
                SSw += Math.Pow(buf - ut3, 2);
            }
            MSb = SSb / dfb;
            MSw = SSw / dfw;
            F = MSb / MSw;
            richTextBox2.Clear();
            richTextBox2.Text += "F統計值計算:"+'\n';
            richTextBox2.Text += "F=" +Math.Round(F,3,MidpointRounding.AwayFromZero)+ '\n';
            richTextBox2.Text += "自由度df:" + dfb +','+ dfw;
        }


    }
}
