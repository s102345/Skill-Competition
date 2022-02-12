using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 試題4
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
                button2.Enabled = true;
            }
        }
        private void Button2_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            Bitmap nbm = new Bitmap(pictureBox1.Image);
            System.Diagnostics.Debug.Print("Processing...");
            for(int i = 0; i < bm.Width; i++)
            {
                for(int j = 0; j < bm.Height; j++)
                {
                    if ((bm.GetPixel(i, j).R + bm.GetPixel(i, j).G + bm.GetPixel(i, j).B) / 3 > 0)//非黑色
                    {
                        nbm.SetPixel(i, j, Color.White);
                        continue;
                    }
                    for (int a = -1; a <= 1; a++)
                    {
                        for(int b = -1; b <= 1; b++)
                        {
                            if (i+a<0 ||j+b<0 ||i+a==bm.Width||j+b==bm.Height) continue;
                            nbm.SetPixel(i + a, j + b, bm.GetPixel(i, j));
                        }
                    }
                }
            }
            pictureBox1.Image = nbm;
            System.Diagnostics.Debug.Print("Done!");
        }

    }
}
