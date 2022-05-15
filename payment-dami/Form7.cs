using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Data.SqlClient;

namespace payment_dami
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");
            SqlCommand cdd = new SqlCommand("Select * from ddd", con);
            SqlDataAdapter da = new SqlDataAdapter(cdd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 f = new Form1();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ddd VALUES (@nom,@prenom,@cin,@mat,@ad,@post,@nt1,@nt2,@datt,@datd,@typ)", con);

            if (textBox2.Text == "" || textBox7.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox8.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("il faut remplire toute les donnee");

            }
            else
            {
                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
                cmd.Parameters.AddWithValue("@cin", textBox7.Text);
                cmd.Parameters.AddWithValue("@mat", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@post", textBox5.Text);
                cmd.Parameters.AddWithValue("@nt1", textBox8.Text);
                cmd.Parameters.AddWithValue("@nt2", textBox6.Text);
                cmd.Parameters.AddWithValue("@datt", dateTimePicker2.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@datd", dateTimePicker1.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@typ", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("personnel ajouter avec succes");
                SqlCommand cdd = new SqlCommand("Select * from ddd", con);
                SqlDataAdapter da = new SqlDataAdapter(cdd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Update ddd set nom=@nom, prenom=@prenom, cin=@cin, mat=@mat, ad=@ad, post=@post, nt1=@nt1, nt2=@nt2, datt=@datt, datd=@datd, typ=@typ where nom = @nom", con);
            if (textBox2.Text == "" || textBox7.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox8.Text == "" || textBox6.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("il faut remplire toute les donnee");

            }
            else
            {
                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
                cmd.Parameters.AddWithValue("@cin", textBox7.Text);
                cmd.Parameters.AddWithValue("@mat", textBox3.Text);
                cmd.Parameters.AddWithValue("@ad", textBox4.Text);
                cmd.Parameters.AddWithValue("@post", textBox5.Text);
                cmd.Parameters.AddWithValue("@nt1", textBox8.Text);
                cmd.Parameters.AddWithValue("@nt2", textBox6.Text);
                cmd.Parameters.AddWithValue("@datt", dateTimePicker2.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@datd", dateTimePicker1.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@typ", comboBox1.Text);
                con.Close();
                MessageBox.Show("personnel modifier avec succes");
                SqlCommand cdd = new SqlCommand("Select * from ddd", con);
                SqlDataAdapter da = new SqlDataAdapter(cdd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("Delete ddd where nom=@nom", con);
            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("personnel supprimier avec succes");
            SqlCommand cdd = new SqlCommand("Select * from ddd", con);
            SqlDataAdapter da = new SqlDataAdapter(cdd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
