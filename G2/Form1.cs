using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace G2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(global.color);
            g.Dispose();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            form.Owner = this;
            form.ShowDialog();
            if (form.button1.DialogResult == DialogResult.OK)
            {
                if (form.textBox1.Text != "" && form.textBox2.Text != "" && form.textBox3.Text != "")
                {
                    if (int.Parse(form.textBox1.Text) < 255 && int.Parse(form.textBox2.Text) < 255 && int.Parse(form.textBox3.Text) < 255)
                    {
                        global.color = Color.FromArgb(int.Parse(form.textBox1.Text), int.Parse(form.textBox2.Text), int.Parse(form.textBox3.Text));
                    }
                }
            }
        }
        class global
        {
            public static Color color;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.PageUnit = GraphicsUnit.Pixel;

            printMain(g, pictureBox1.Width, pictureBox1.Height, 1);//ширина и высота pictureBox1
            showGraphics(g, pictureBox1.Width, pictureBox1.Height, global.color, 1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.PageUnit = GraphicsUnit.Millimeter;

            float width_M = (float)(((pictureBox1.Width - 1) / g.DpiX * 25.4) + 1);//ширина в миллиметрах
            float height_M = (float)(((pictureBox1.Height - 1) / g.DpiY * 25.4) + 1);//высота в миллиметрах

            printMain(g, width_M, height_M, 2);
            showGraphics(g, width_M, height_M, global.color, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Graphics g = pictureBox1.CreateGraphics();
            g.Clear(Color.White);
            g.PageUnit = GraphicsUnit.Inch;

            float width_I = (float)(((pictureBox1.Width - 1) / g.DpiX) + 1);//ширина в дюймах
            float height_I = (float)(((pictureBox1.Height - 1) / g.DpiY) + 1);//высота в дюймах           
            printMain(g, width_I, height_I, 3);
            showGraphics(g, width_I - 1, height_I - 3, global.color, 3);
        } 
        public void printMain(Graphics g, float width,float height,float n)
        {
            Pen p = new Pen(Color.Red, n);
            if (n == 1) p = new Pen(Color.Red, 1);
            else if (n == 2) p = new Pen(Color.Red, 0.3f);
            else if (n == 3) p = new Pen(Color.Red, 0.005f);
            Font aFont = new Font("Arial", 20, FontStyle.Regular);

            g.DrawRectangle(p, 0, 0, width - 1, height - 1);
            g.DrawLine(p, (width - 1) / 2, 0, (width - 1) / 2, height - 1);
            g.DrawLine(p, 0, (height - 1) / 2, width - 1, (height - 1) / 2);
            if (n == 1)
            {
                g.DrawString("Х", aFont, Brushes.Red, width - 23, (height / 2) + 5);
                g.DrawString("Y", aFont, Brushes.Red, (width / 2), 2);
            }
            else if (n == 2)
            {
                g.DrawString("Х", aFont, Brushes.Red, width - 7f, (height / 2) + 1f);
                g.DrawString("Y", aFont, Brushes.Red, (width / 2) - 0.5f, 0.6f);
            }
            else if (n == 3)
            {
                g.DrawString("Х", aFont, Brushes.Red, (width / 2) + 3.43f, (height / 2) - 0.45f);
                g.DrawString("Y", aFont, Brushes.Red, (width / 2) - 0.5f, 0.005f);
            }

        }
        public static void showGraphics(Graphics g, float MaxX, float MaxY, Color color, int n)
        {
            //Определяем каким пером выводить график
            //
            Pen p = new Pen(color, 0);
            if (n == 1) p = new Pen(color, 1.8f);
            else if (n == 2) p = new Pen(color, 0.5f);
            else if (n == 3) p = new Pen(color, 0.01f);
            //

            g.TranslateTransform(MaxX / 2, MaxY / 2);// начало координат в центре

            PointF[] point = new PointF[(int)MaxX];

            //Правая часть
            for (int i = 0; i < point.Length; i++)
            {
                point[i].X = i;
                point[i].Y = (float)(1 - (Math.Cos(i * (4 * Math.PI / MaxX))) * MaxY / 4);
            }
            g.DrawLines(p, point);
            //Левая часть
            for (int i = 0; i < point.Length; i++)
            {
                point[i].X = -i;
                point[i].Y = (float)(1 - (Math.Cos(i* (4 * Math.PI / MaxX))) * MaxY / 4);
            }
            g.DrawLines(p, point);
            //
            p.Dispose();
        }

    }

}
