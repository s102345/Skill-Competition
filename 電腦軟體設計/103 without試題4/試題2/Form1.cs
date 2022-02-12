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
        List<Data> datas = new List<Data>();
        List<Data> s1 = new List<Data>();
        List<Data> s2 = new List<Data>();
        List<Data> s3 = new List<Data>();
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                FileInfo fi = new FileInfo(openFileDialog1.FileName);
                StreamReader sr = new StreamReader(fi.OpenRead());               
                sr.ReadLine();//trash
                Data d;
                while (sr.Peek() > 0)
                {                   
                    string[] str = sr.ReadLine().Split(' ');
                    d.Height = Convert.ToInt32(str[0]);
                    d.Weight = Convert.ToInt32(str[1]);
                    datas.Add(d);
                    richTextBox1.Text += (datas.Count-1)+"    "+ str[0]+"    "+str[1]+'\n';
                }
            }
        }
        struct Data
        {
            public int Height;
            public int Weight;
        };
        double uj1W,uj1H, uj2W,uj2H, uj3W,uj3H, d1,d2,d3;
        private void Button2_Click(object sender, EventArgs e)
        {
            Initialize();
            richTextBox2.Clear(); richTextBox3.Clear(); richTextBox4.Clear(); richTextBox5.Clear();
           
            for (int i = 0; i < 200; i++)
            {
                GetAverage();
                for (int j = 0; j < datas.Count; j++)
                {
                    GetDistance(datas[j]);
                    if (d1 < d2 && d1 < d3)
                    {
                        Remove(datas[j]);
                        s1.Add(datas[j]);
                    }
                    if (d2 < d1 && d2 < d3)
                    {
                        Remove(datas[j]);
                        s2.Add(datas[j]);
                    }
                    if (d3 < d1 && d3 < d2)
                    {
                        Remove(datas[j]);
                        s3.Add(datas[j]);
                    }
                    //System.Diagnostics.Debug.Print(d1 + ""+d2+""+d3);
                }
            }
            int where=0;
            for(int i = 0; i < datas.Count; i++)
            {
                if (s1.IndexOf(datas[i]) != -1) where = 0;
                else if(s2.IndexOf(datas[i]) != -1) where = 1;
                else if (s3.IndexOf(datas[i]) != -1) where = 2;
                richTextBox2.Text+="第"+i+"筆屬於"+where+"堆" +'\n' ;
            }
            System.Diagnostics.Debug.Print(s1.Count+"");
            for(int i = 0; i < s1.Count; i++)
            {
                richTextBox3.Text+= datas.IndexOf(s1[i])+" "+s1[i].Weight+" "+s1[i].Height+'\n';
            }
            for (int i = 0; i < s2.Count; i++)
            {
                richTextBox4.Text += datas.IndexOf(s2[i]) + " " + s2[i].Weight + " " + s2[i].Height + '\n';
            }
            for (int i = 0; i < s3.Count; i++)
            {
                richTextBox5.Text += datas.IndexOf(s3[i]) + " " + s3[i].Weight + " " + s3[i].Height + '\n';
            }
        }
        private void Remove(Data d)
        {
            s1.Remove(d);
            s2.Remove(d);
            s3.Remove(d);
        }
        private void GetAverage()
        {
            uj1W = 0;uj1H = 0;uj2W = 0;uj2H = 0;uj3W = 0;uj3H = 0;
            foreach(Data d in s1)
            {
                uj1W += d.Weight;
                uj1H += d.Height;
            }
            foreach (Data d in s2)
            {
                uj2W += d.Weight;
                uj2H += d.Height;
            }
            foreach (Data d in s3)
            {
                uj3W += d.Weight;
                uj3H += d.Height;
            }
            
            uj1W /= s1.Count; uj1H /= s1.Count; uj2W /= s2.Count; uj2H /= s2.Count; uj3W /= s3.Count; uj3H /= s3.Count;
 
        }
        private void GetDistance(Data d)
        {
            d1 = Math.Pow((d.Height - uj1H)* (d.Height - uj1H) + (d.Weight - uj1W)* (d.Weight - uj1W),0.5);   
            d2 = Math.Pow((d.Height - uj2H) * (d.Height - uj2H) + (d.Weight - uj2W) * (d.Weight - uj2W),0.5);
            d3 = Math.Pow((d.Height - uj3H) * (d.Height - uj3H) + (d.Weight - uj3W) * (d.Weight - uj3W),0.5);
        }
        private void Initialize()
        {
            s1.Add(datas[0]);
            s2.Add(datas[1]);
            s3.Add(datas[2]);
            Random rnd = new Random();
            for (int i = 3; i < datas.Count; i++)
            {
                switch (rnd.Next(1, 4))
                {
                    case 1:
                        s1.Add(datas[i]);
                        break;
                    case 2:
                        s2.Add(datas[i]);
                        break;
                    case 3:
                        s3.Add(datas[i]);
                        break;
                }
            }
        }
    }
}
