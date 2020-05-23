using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Vilan_Marius
{
    public partial class SaveScore : Form
    {
        Form2 f1 = new Form2();
        public SaveScore(Form2 f1)
        {
            InitializeComponent();
            this.f1 = f1;
        }

        private void SaveScore_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("Adauga un nume!", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                f1.saveTb = textBox1.Text;
                MessageBox.Show("Gata!", "Congrates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
        }
    }
}
