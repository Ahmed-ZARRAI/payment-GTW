using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace payment_dami
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

       
        int startpoint = 0;

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            startpoint += 1;
            progressBar2.Value = startpoint;
            if (progressBar2.Value == 100)
            {
                progressBar2.Value = 0;
                timer1.Stop();
                Form1 log = new Form1();
                this.Hide();
                log.Show();
            }
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void progressBar2_Click(object sender, EventArgs e)
        {

        }
    }
}
