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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {       
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName); 
            }
        }
        double mpp = 0;
        private void Button2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            const int chair = 830;
            double max1=0,max2=0;   
            if (sender.Equals(button2))
            {
                for (int i = 0; i < bm.Width/4; i++)
                {
                    int k=0;
                    for (int j = 0; j < bm.Height; j++)
                    {
                        if(bm.GetPixel(i,j).R*0.3+ bm.GetPixel(i, j).G * 0.59 + bm.GetPixel(i, j).B * 0.11 <=200)
                        {
                            k++;
                        }
                    }
                    if (k > max1) max1 = k;
                }
                for (int i = bm.Width / 4; i < bm.Width; i++)
                {
                    int k = 0;
                    for (int j = 0; j < bm.Height; j++)
                    {
                        if (bm.GetPixel(i, j).R * 0.3 + bm.GetPixel(i, j).G * 0.59 + bm.GetPixel(i, j).B * 0.11 <= 200)
                        {
                            k++;
                        }
                    }
                    if (k > max2) max2 = k;
                }               
                mpp = chair / max1;
                textBox1.Text = Convert.ToString(Math.Round(mpp*max2,1));
                System.Diagnostics.Debug.Print(max2 + "");
            }
            if (sender.Equals(button3))
            {
                /*int tw = 0;
                for (int i=0; i<bm.Height; i++)
                {
                    int k = 0;
                    for (int j = bm.Width-1; j >0 ; j--)
                    {
                        if (bm.GetPixel(j,i).R * 0.3 + bm.GetPixel(j, i).G * 0.59 + bm.GetPixel(j, i).B * 0.11 <= 200)
                        {
                            k++;
                        }
                        else
                        {
                            if (k > 0)
                            {
                                if (k > tw) tw = k;
                                break;
                            }
                        }                   
                    }
                   
                    textBox2.Text=Convert.ToString(mpp*tw);
                }
                System.Diagnostics.Debug.Print(tw + "");
                */
                textBox2.Text = Convert.ToString(Math.Round(Convert.ToDouble(textBox1.Text)/2.8,1));
            }
        }
    }
}
