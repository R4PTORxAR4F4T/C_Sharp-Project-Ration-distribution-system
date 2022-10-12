using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RationDistribution
{
    public partial class Form2 : Form
    {
        private string GenderInfo = "";
        private string RationIdInfo = "220000005";
        private string HistoryInfo = "";

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=***********");
        
        public Form2()
        {
            InitializeComponent();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();

            var Form3 = new Form3();
            Form3.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BackColor = Color.CornflowerBlue;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = checkBox1.Checked;
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text) || string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) || string.IsNullOrEmpty(textBox6.Text) || string.IsNullOrEmpty(textBox7.Text) || string.IsNullOrEmpty(textBox8.Text) )
            {
                MessageBox.Show("Pls provide all the information");
            }
            else 
            {
                //if (RadioButton1.Chcked) { }
                //cmd.Parameters.AddWithValue("@Gender", );
                if (radioButton1.Checked == true)
                {
                    GenderInfo = "Male";
                }
                else if (radioButton2.Checked == true)
                {
                    GenderInfo = "Female";
                }
                else if (radioButton1.Checked == false && radioButton2.Checked == false)
                {
                    GenderInfo = "";
                }

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");
                try
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    //MessageBox.Show("insert into RegisteredData values ( \'" + textBox1.Text + "\', \'" + textBox2.Text + "\',\'" + textBox3.Text + "\',\'" + textBox4.Text + "\',\'" + GenderInfo + "\'," + textBox5.Text + "," + textBox6.Text + ",\'" + textBox7.Text + "\'," + textBox8.Text + "," + RationIdInfo + ",\'" + HistoryInfo + "\')");

                    cmd.CommandText = "insert into RegisteredData values ( \'" + textBox1.Text + "\', \'" + textBox2.Text + "\',\'" + textBox3.Text + "\',\'" + textBox4.Text + "\',\'" + GenderInfo + "\'," + textBox5.Text + "," + textBox6.Text + ",\'" + textBox7.Text + "\'," + textBox8.Text + "," + RationIdInfo + ",\'" + HistoryInfo + "\')";
                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("Registration Successsful");
                }

                catch
                {
                    MessageBox.Show("Unexpected Input");
                }

                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                textBox7.Clear();
                textBox8.Clear();
                
                this.Hide();
                var Form3 = new Form3();
                Form3.Show();

                /*SqlConnection con = new SqlConnection("Data Source=desktop-2nkg6gt;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=***********;pooling=False");
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO (User Type, Full Name, Password,Confirm Password,Gender,Age,Number,Address,NID Number)" +
                                                " VALUES (@User Type,@Full Name,@Password,@Confirm Password,@Gender,@Age,@Number,@Address,@NID Number)", con);
                cmd.Parameters.AddWithValue("@User Type", textBox1.Text);
                cmd.Parameters.AddWithValue("@Full Name", textBox2.Text);
                cmd.Parameters.AddWithValue("@Password", textBox3.Text);
                cmd.Parameters.AddWithValue("@Confirm Password", textBox4.Text);
                cmd.Parameters.AddWithValue("@Gender", GenderInfo);
                cmd.Parameters.AddWithValue("@Age", textBox5.Text);
                cmd.Parameters.AddWithValue("@Number", textBox6.Text);
                cmd.Parameters.AddWithValue("@Address", textBox7.Text);
                cmd.Parameters.AddWithValue("@NID Number", textBox8.Text);

                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";

                //BindData();

                this.Hide();
                var Form3 = new Form3();
                Form3.Show();

                */
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                e.Cancel = true;
                textBox1.Focus();
                errorProvider1.SetError(textBox1, "Please Enter your User Name !");
            }
            else
            {
                //e.Cancel = true;
                errorProvider1.SetError(textBox1, null);
            }
        }

        private void textBox2_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox2.Text))
            {
                e.Cancel = true;
                textBox2.Focus();
                errorProvider2.SetError(textBox2, "Please Enter your Full Name !");
            }
            else
            { 
                errorProvider2.SetError(textBox2, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider3.SetError(textBox3, "Please Enter your password !");
            }
            else
            {
                errorProvider3.SetError(textBox3, null);
            }
        }

        private void textBox4_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox4.Text))
            {
                e.Cancel = true;
                textBox4.Focus();
                errorProvider4.SetError(textBox4, "Please re-Enter your password !");
            }
            else
            {
                errorProvider4.SetError(textBox4, null);
            }
        }

        private void textBox5_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox5.Text))
            {
                e.Cancel = true;
                textBox5.Focus();
                errorProvider5.SetError(textBox5, "Please Enter your Age !");
            }
            else
            {
                errorProvider5.SetError(textBox5, null);
            }
        }

        private void textBox6_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox6.Text))
            {
                e.Cancel = true;
                textBox6.Focus();
                errorProvider6.SetError(textBox6, "Please Enter your Number !");
            }
            else
            {
                errorProvider6.SetError(textBox6, null);
            }
        }

        private void textBox7_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox7.Text))
            {
                e.Cancel = true;
                textBox7.Focus();
                errorProvider7.SetError(textBox7, "Please Enter your Address !");
            }
            else
            {
                errorProvider7.SetError(textBox7, null);
            }
        }

        private void textBox8_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox8.Text))
            {
                e.Cancel = true;
                textBox8.Focus();
                errorProvider8.SetError(textBox8, "Please Enter your Address !");
            }
            else
            {
                errorProvider8.SetError(textBox8, null);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
