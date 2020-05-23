using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Puzzle_Vilan_Marius
{
    public partial class top : Form
    {
        private List<TopClass> user = new List<TopClass>();
        private String[] readFF;
        private String[] player;
        private int[] playertime;
        private int maxLength = 0;
        public top()
        {
            InitializeComponent();
        }
        private int getNumberOfLines()
        {
            int nrline=0;
            try
            {
                using (StreamReader sr = new StreamReader("result.txt"))
                {
                    while (sr.ReadLine() != null)
                    {
                        nrline++;
                    }
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show("The file could not be read:");
                MessageBox.Show(ex.Message);
            }
            return nrline;
        }
        private void readFromFile()
        {
            readFF = new String[getNumberOfLines()];
            string line = "";
            int i = 0;
            try
            {
                using (StreamReader sr = new StreamReader("result.txt"))
                {
                    while ((line = sr.ReadLine()) != null)
                    {
                        readFF[i++] = line;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("The file could not be read:");
                MessageBox.Show(ex.Message);
            }
        }
        private void getPlayerAndTime()
        {
            player = new String[getNumberOfLines()];
            playertime = new int[getNumberOfLines()];
            int max = 0;
            int countPlayer = 0;
            int countPlayerTime = 0;
            for(int i=0;i<readFF.Length;i++)
            {
                String[] strlist = readFF[i].Split(' ');
                player[countPlayer++] = strlist[0];
                playertime[countPlayerTime++] = Convert.ToInt32(strlist[1]);
                max = strlist[0].Length;
                if(max>maxLength)
                {
                    maxLength = max;
                }
            }
            bubblesort();
            string line = "";
            max = 0;
            for(int k=0;k<getNumberOfLines();k++)
            {
                max = player[k].Length;
                line = player[k]+"      ";
                for(int i=0;i<(maxLength-max);i++)
                {
                    line += " ";
                }
                line+=+ playertime[k];
                WriteInFile(line);
            }
        }
        private void WriteInFile(string str)
        {
            using (StreamWriter sw = new StreamWriter("Leaderboard.txt", true))
            {
                sw.WriteLine(str);
            };
        }
        private void bubblesort()
        {
            int aux = 0;
            string stringaux = "";
            for(int i=0;i<getNumberOfLines();i++)
            {
                for(int j = i+1; j < getNumberOfLines(); j++)
                {
                    if(playertime[i]>playertime[j])
                    {
                        aux = playertime[j];
                        playertime[j] = playertime[i];
                        playertime[i] = aux;
                        stringaux = player[j];
                        player[j] = player[i];
                        player[i] = stringaux;
                    }
                }
            }
        }
        private void EmptyFile()
        {
            File.WriteAllText("Leaderboard.txt", string.Empty);
        }
        private void top_Load(object sender, EventArgs e)
        {
            EmptyFile();
            readFromFile();
            getPlayerAndTime();
            TopClass[] aux=new TopClass[10];
            int scor = 0;
            string nume = "";
            int auxcount = 0;
            for(int i=0;i<10;i++)
            {
                aux[i] = new TopClass();
                aux[i].addAll("TBD!");
                user.Add(aux[i]);
            }
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                using (StreamReader sr = new StreamReader("Leaderboard.txt"))
                {
                    string line="";
                    // Read and display lines from the file until the end of 
                    // the file is reached.
                    while ((line = sr.ReadLine()) != null)
                    {
                        //MessageBox.Show(line);
                        (aux[auxcount]).addAll(line);
                        user.Add(aux[auxcount]);
                        auxcount++;
                    }
                }
            }
            catch (Exception ex)
            {
                // Let the user know what went wrong.
                MessageBox.Show("The file could not be read:");
                MessageBox.Show(ex.Message);
            }
            //MessageBox.Show(user.Count().ToString());
            int count = 1;
            foreach(TopClass i in user)
            {
                //i.setAll("TBD");
                //MessageBox.Show(i.getAll());
                switch(count)
                {
                    case 1:
                        label1.Text = "1. "+i.getAll();
                        break;
                    case 2:
                        label3.Text = "2. "+i.getAll();
                        break;
                    case 3:
                        label2.Text = "3. "+i.getAll();
                        break;
                    case 4:
                        label6.Text = "4. "+i.getAll();
                        break;
                    case 5:
                        label4.Text = "5. "+i.getAll();
                        break;
                    case 6:
                        label5.Text = "6. "+i.getAll();
                        break;
                    case 7:
                        label9.Text = "7. "+i.getAll();
                        break;
                    case 8:
                        label7.Text = "8. "+i.getAll();
                        break;
                    case 9:
                        label8.Text = "9. "+i.getAll();
                        break;
                    case 10:
                        label10.Text = "10. "+i.getAll();
                        break;
                }
                count++;
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form f1 = new MeniuJucator();
            f1.Closed += (s, args) => this.Close();
            f1.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
