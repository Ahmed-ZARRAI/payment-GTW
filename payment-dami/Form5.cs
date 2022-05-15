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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");
            SqlCommand cdd = new SqlCommand("Select * from ccc", con);
            SqlDataAdapter da = new SqlDataAdapter(cdd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            f.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");
            con.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO ccc VALUES (@nom,@prenom,@cin,@login,@mot,@date,@role)", con);
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("il faut remplire toute les donnee");

            }
            else
            {
                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
                cmd.Parameters.AddWithValue("@cin", textBox3.Text);
                cmd.Parameters.AddWithValue("@login", textBox4.Text);
                cmd.Parameters.AddWithValue("@mot", textBox5.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToShortDateString());
                cmd.Parameters.AddWithValue("@role", comboBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("utilisateur ajouter avec succes");
                SqlCommand cdd = new SqlCommand("Select * from ccc", con);
                SqlDataAdapter da = new SqlDataAdapter(cdd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dataGridView1.DataSource = dt;
            }
               
        }

        private void Form5_Load(object sender, EventArgs e)
        {
           
        }

      

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.\sqlexpress;Initial Catalog=dami;Integrated Security=True;Pooling=False");

            con.Open();
            SqlCommand cmd = new SqlCommand("Update ccc set prenom=@prenom, nom=@nom, cin=@cin, login=@login, date=@date, mot=@mot where nom = @nom", con);
            
            if (textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || comboBox1.Text == "")
            {
                MessageBox.Show("il faut remplire toute les donnee");

            }
            else
            {
                cmd.Parameters.AddWithValue("@nom", textBox1.Text);
                cmd.Parameters.AddWithValue("@prenom", textBox2.Text);
                cmd.Parameters.AddWithValue("@cin", textBox3.Text);
                cmd.Parameters.AddWithValue("@login", textBox4.Text);
                cmd.Parameters.AddWithValue("@mot", textBox5.Text);
                cmd.Parameters.AddWithValue("@date", dateTimePicker1.Value.ToShortDateString());
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("utilisateur modifier avec succes");
                SqlCommand cdd = new SqlCommand("Select * from ccc", con);
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
            SqlCommand cmd = new SqlCommand("Delete ccc where nom=@nom", con);
            cmd.Parameters.AddWithValue("@nom", textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("utilisateur supprimer avec succes");
            SqlCommand cdd = new SqlCommand("Select * from ccc", con);
            SqlDataAdapter da = new SqlDataAdapter(cdd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        
    }
}
