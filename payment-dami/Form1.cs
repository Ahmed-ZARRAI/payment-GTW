using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace payment_dami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            textBox2.UseSystemPasswordChar = true;
            
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new  SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");
            SqlDataAdapter sda = new SqlDataAdapter("SELECT COUNT(*) FROM ccc WHERE login='" + textBox1.Text + "' AND mot='" + textBox2.Text + "'", con);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            
            if (dt.Rows[0][0].ToString() == "1"  && comboBox1.Text =="super-utilisateur")
            {
                this.Hide();
                Form4 f = new Form4();
                f.Show();
            }
                else if (dt.Rows[0][0].ToString() == "1" && comboBox1.Text == "utilisateur")
            {
                this.Hide();
                Form7 f = new Form7();
                f.Show();
            }
            else
                MessageBox.Show("mot de passe incorrect");
        }
        
        private void checkBox1_CheckedChanged(object sender, EventArgs e)

        {
            
            if (checkBox1.Checked)
                textBox2.UseSystemPasswordChar = false;
            else
                textBox2.UseSystemPasswordChar = true ;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }

}

