﻿using System;
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
    public partial class MeniuJucator : Form
    {
        public MeniuJucator()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f3 = new Form2();
            f3.Closed += (s, args) => this.Close();
            f3.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
           

       }
    }
}
