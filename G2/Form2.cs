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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            Form1 form1 = this.Owner as Form1;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.DialogResult == DialogResult.OK)
            {
                if(textBox1.Text!=""&&textBox2.Text!=""&& textBox3.Text != "")
                {
                    if(int.Parse(textBox1.Text)<255&& int.Parse(textBox2.Text) < 255&& int.Parse(textBox3.Text) < 255)
                    {
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Слишком большое значение");
                    }
                }
                else
                {
                    MessageBox.Show("Ничего не введено");
                }
            }
        }
    }
}
