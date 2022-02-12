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

        private void Button1_Click(object sender, EventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Image);
            for(int i = 0; i < bm.Width; i++)
            {
                for(int j = 0; j < bm.Height; j++)
                {
                    int ci =bm.GetPixel(i, j).ToArgb();
                    int R = ((ci >> 16 & 1) == 1) ? 16 : 235;
                    int G = ((ci >> 8 & 1) == 1) ? 16 : 235;
                    int B = ((ci & 1) == 1) ? 16 : 235;
                    bm.SetPixel(i,j,Color.FromArgb(R,G,B));
                }
            }
            pictureBox1.Image = bm;
        }

        private void PictureBox1_DragDrop(object sender, DragEventArgs e)
        {
            string filename = (e.Data.GetData((DataFormats.FileDrop)) as string[])[0];
            pictureBox1.Image = Image.FromFile(filename);
            button1.Enabled = true;
            button1.Text = "Reveal The Image Behind";
            label1.Visible = false;
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.Image =Image.FromFile(openFileDialog1.FileName);
            }
            button1.Enabled = true;
            button1.Text = "Reveal The Image Behind";
            label1.Visible = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach (Control items in Controls)
            {
                if (items.GetType().Name == "PictureBox")
                {
                    items.AllowDrop = true;//允許拖曳
                }
            }
        }

        private void PictureBox1_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.All;
        }
    }
}
