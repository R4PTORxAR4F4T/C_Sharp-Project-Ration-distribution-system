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

namespace RationDistribution
{
    public partial class Form1 : Form
    {
        private string input1 = "";
        public static string publicID ="";



        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string input1 = textBox1.Text;

            //input1 = Convert.ToString((textBox1));
        }


        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Validating(object sender, CancelEventArgs e)
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
                errorProvider2.SetError(textBox2, "Please Enter your User ID !");
            }
            else
            {
                //e.Cancel = true;
                errorProvider2.SetError(textBox1, null);
            }
        }

        private void textBox3_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrEmpty(textBox3.Text))
            {
                e.Cancel = true;
                textBox3.Focus();
                errorProvider3.SetError(textBox3, "Please Enter your Password !");
            }
            else
            {
                //e.Cancel = true;
                errorProvider3.SetError(textBox1, null);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Welcome to Bangladesh Ration Distribution System");
            BackColor = Color.CornflowerBlue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            input1 = textBox1.Text;

            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(textBox3.Text))
            {
                MessageBox.Show("Input all the information");
            }
            else
            {
                //MessageBox.Show("   login Successful");

                if (input1 == "Admin")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");
                        string query = "Select * from RegisteredData where UserType='" + textBox1.Text.Trim() + "' and NIDNumber='" + textBox2.Text.Trim() + "' and Password = '" + textBox3.Text.Trim() + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(query, con);
                        DataTable dtbl = new DataTable();
                        sda.Fill(dtbl);

                        if (ValidateChildren(ValidationConstraints.Enabled))
                        {
                            if (dtbl.Rows.Count == 1)
                            {
                                this.Hide();
                                var form3 = new Form3();
                                form3.Show();

                                /*Form4 f4 = new Form4();
                                this.Hide();
                                f4.Show();*/
                            }

                            else
                            {
                                MessageBox.Show("Wrong username or password");
                                textBox2.Clear();
                                textBox3.Clear();
                            }
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
                else if (input1 == "Public")
                {
                    try
                    {
                        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");
                        string query = "Select * from RegisteredData where UserType='" + textBox1.Text.Trim() + "' and NIDNumber='" + textBox2.Text.Trim() + "' and Password = '" + textBox3.Text.Trim() + "'";
                        SqlDataAdapter sda = new SqlDataAdapter(query, con);
                        DataTable dtbl = new DataTable();
                        sda.Fill(dtbl);

                        if (ValidateChildren(ValidationConstraints.Enabled))
                        {
                            if (dtbl.Rows.Count == 1)
                            {
                                publicID = textBox2.Text;

                                this.Hide();
                                var form4 = new Form4();
                                form4.Show();

                                /*Form4 f4 = new Form4();
                                this.Hide();
                                f4.Show();*/
                            }

                            else
                            {
                                MessageBox.Show("Wrong username or password");
                                textBox2.Clear();
                                textBox3.Clear();
                            }
                        }
                    }

                    catch
                    {
                        MessageBox.Show("Invalid Input");
                    }
                }
                else
                {
                    DialogResult res = MessageBox.Show("     Access Denied \n\n" + "Incorrect information", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();

                    input1 = "";
                    
                }
            }
            

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure..?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes )
            {
                
                Application.Exit();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("You have been return");
            }
        }
    }
}
