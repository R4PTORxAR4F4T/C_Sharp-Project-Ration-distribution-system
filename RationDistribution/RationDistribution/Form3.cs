using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace RationDistribution
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Ther is no User ID");
                    errorProvider1.SetError(textBox1, "Please Enter User ID!");
                }
                else
                {

                    DialogResult res = MessageBox.Show("    Are you sure..? \n\n" + "you want to Delete User", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                    if (res == DialogResult.Yes)
                    {
                        /*SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");

                    con.Open();

                    SqlCommand cmd = new SqlCommand("SELECT * FROM RegisteredData WHERE NIDNumber='" + textBox1.Text.Trim() + "' ", con);
                    
                    
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;
                    
                    textBox1.Clear();
                    textBox2.Clear();*/

                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");
                        con.Open();

                        SqlCommand cmd = new SqlCommand("DELETE RegisteredData WHERE NIDNumber = '" + textBox1.Text.Trim() + "' ", con);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("Successfully Deleted");

                        this.Hide();
                        var form3 = new Form3();
                        form3.Show();

                        textBox1.Clear();
                        textBox2.Clear();
                    }
                    else
                    {
                        textBox1.Clear();
                        MessageBox.Show("User not Deleted");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }
            /*cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
            cmd.Parameters.AddWithValue("@Name", textBox2.Text);
            cmd.Parameters.AddWithValue("@Age", textBox3.Text);
            cmd.Parameters.AddWithValue("@Password", textBox4.Text);
             cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Successfully Deleted");
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";*/

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();

            var Form2 = new Form2();
            Form2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.Hide();

            var Form1 = new Form1();
            Form1.Show();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Ther is no User ID");
                    errorProvider1.SetError(textBox1, "Please Enter User ID!");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");
                    con.Open();

                    SqlCommand cmd = new SqlCommand("update RegisteredData set History = '" + textBox2.Text.Trim() + "' where NIDNumber = '" + textBox1.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Successfully Updated");

                    textBox1.Clear();
                    textBox2.Clear();
                    this.Hide();
                    var Form3 = new Form3();
                    Form3.Show();
                    /*SqlCommand cmd = new SqlCommand("SELECT * FROM RegisteredData WHERE NIDNumber='" + textBox1.Text.Trim() + "' ", con);
                    //cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dataGridView1.DataSource = dt;*/
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");
            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM RegisteredData", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("Ther is no User ID");
                    errorProvider1.SetError(textBox1, "Please Enter User ID!");
                }
                else
                {
                    SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM RegisteredData WHERE NIDNumber='" + textBox1.Text.Trim() + "' ", con);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    this.Hide();
                    var form3 = new Form3();
                    form3.Show();

                    textBox1.Clear();
                    textBox2.Clear();
                    /*var Form3 = new Form3();
                    Form3.Show();*/

                    //cmd.Parameters.AddWithValue("@ID", int.Parse(textBox1.Text));
                    //SqlDataAdapter da = new SqlDataAdapter(cmd);
                    //DataTable dt = new DataTable();
                    //da.Fill(dt);
                    //dataGridView1.DataSource = dt;
                }
            }
            catch
            {
                MessageBox.Show("Invalid Input");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
