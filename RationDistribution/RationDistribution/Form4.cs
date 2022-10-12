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
    public partial class Form4 : Form
    {
        
        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            //MessageBox.Show(Form1.publicID);

            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-2NKG6GT;Initial Catalog=RationDistributionDatabase;Persist Security Info=True;User ID=sa;Password=ARAFAT");

            con.Open();

            SqlCommand cmd = new SqlCommand("SELECT * FROM RegisteredData WHERE NIDNumber='" + Form1.publicID + "' ", con);


            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you sure..?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {

                Application.Exit();
                //this.Hide();
            }
            else
            {
                MessageBox.Show("You have been return");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show("Are you want to log out..?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

            if (res == DialogResult.Yes)
            {
                this.Hide();

                var Form1 = new Form1();
                Form1.Show();
            }
            else
            {
                MessageBox.Show("You have been return");
            }

        }
    }
}
