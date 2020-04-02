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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "Graphics Files|*.jpg;*.gif;*.png|All Files|*.*"
            };
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Functie.incarcaImaginea(ofd.FileName, pictureBox1, this);
            }
        }
        
        private void SelectMode(object sender, EventArgs e)
        {
            var mode = (ToolStripMenuItem)sender;
            if(mode != toolStripMenuItem2)
            {
                if(mode== toolStripMenuItem3)
                {
                    Functie._tintaDimensiune = 200;
                }
                else
                    if (mode == toolStripMenuItem4)
                {
                    Functie._tintaDimensiune = 150;
                }
            }
            else
            {
                Functie._tintaDimensiune = 250;
            }
            Functie.StartGame(pictureBox1);
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            Functie._mutaPiesa = null; 
            foreach(var piesa in Functie._piese)
            {
                if (!piesa.piesaAcasa() && piesa.Contains(e.Location))
                    Functie._mutaPiesa = piesa;
            }
            if (Functie._mutaPiesa == null) return;
            Functie._mutaPunct = e.Location;
            Functie._piese.Remove(Functie._mutaPiesa);
            Functie._piese.Add(Functie._mutaPiesa);
            Functie.MakeBackground(pictureBox1);
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (Functie._mutaPiesa == null) return;
            int dx = e.X - Functie._mutaPunct.X;
            int dy = e.Y - Functie._mutaPunct.Y;
            Functie._mutaPiesa._locatieCurenta.X += dx;
            Functie._mutaPiesa._locatieCurenta.Y += dy;
            Functie._mutaPunct = e.Location;
            Functie.DrawBoard(pictureBox1);
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (Functie._mutaPiesa == null) return;
            if (Functie._mutaPiesa.piesaAproape())
            {
                Functie._piese.Remove(Functie._mutaPiesa);
                Functie._piese.Reverse();
                Functie._piese.Add(Functie._mutaPiesa);
                Functie._piese.Reverse();
                Functie._gameOver = true;
                foreach (var piesa in Functie._piese)
                {
                    if (piesa.piesaAcasa()) continue; 
                    Functie._gameOver = false; 
                    break;
                }
            }
            Functie._mutaPiesa = null;
            Functie.MakeBackground(pictureBox1);
            Functie.DrawBoard(pictureBox1);
            if (Functie._gameOver == true)
            {
                MessageBox.Show("Felicitari ai reusit sa pui toate piesele la loc!");
            }
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            Functie.Rezolva(pictureBox1);
        }
    }
}
