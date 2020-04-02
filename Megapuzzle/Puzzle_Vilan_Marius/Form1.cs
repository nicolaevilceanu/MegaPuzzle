using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Puzzle_Vilan_Marius
{
    public partial class Form1 : Form
    {
        private SqlConnection sqlcon = new SqlConnection();
        private SqlCommand sqlcmd = new SqlCommand();
        public Form1()
        {
            InitializeComponent();
            //sqlcon.ConnectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=D:\c#\Puzzle_Vilan_Marius\Puzzle_Vilan_Marius\dbase\mydatabase.mdf;Integrated Security=True;Connect Timeout=30";
        }

        private void button1_Click(object sender, EventArgs e)
        {
                        this.Hide();
                        MeniuJucator f1 = new MeniuJucator();
                        f1.Closed += (s, args) => this.Close();
                        f1.Show();
                    
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}