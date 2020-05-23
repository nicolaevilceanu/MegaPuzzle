using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Vilan_Marius
{
    public partial class register : Form
    {
        private SqlConnection sqlcon = new SqlConnection();
        //private SqlCommand sqlcmd = new SqlCommand();
        public register()
        {
            InitializeComponent();
            sqlcon.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\c#\Puzzle_Vilan_Marius\Puzzle_Vilan_Marius\dbase\mydatabase.mdf;Integrated Security=True;Connect Timeout=30";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool check = false;
            if (textBox1.Text == "" || textBox2.Text == "")
                check = true;
            if (check == false)
            {
                sqlcon.Open();
                SqlCommand sqlcmd = new SqlCommand("UserAdd", sqlcon);
                sqlcmd.CommandType = CommandType.StoredProcedure;
                sqlcmd.Parameters.AddWithValue("@username", textBox1.Text.Trim());
                sqlcmd.Parameters.AddWithValue("@password", textBox2.Text.Trim());
                sqlcmd.ExecuteNonQuery();
                sqlcon.Close();
                Clear();
            }
            else
            {
                MessageBox.Show("Completeaza campurile!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Clear()
        {
            var result=MessageBox.Show("Ai reusit sa te inregistrezi cu succes, vrei sa creezi alt cont?","OK",MessageBoxButtons.YesNo,MessageBoxIcon.Information);
            if(result==DialogResult.No)
            {
                this.Hide();
                Form form = new Form1();
                form.Closed += (s, args) => this.Close();
                form.ShowDialog();
            }
            else
            {
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new Form1();
            f1.Closed+=(s,args)=>this.Close();
            f1.ShowDialog();
        }
    }
}
