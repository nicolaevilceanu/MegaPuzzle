using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Vilan_Marius
{
    class TopClass
    {
        private int score;
        private string name;
        private string all;
        public TopClass()
        {
            this.score = 0;
            this.name = "";
            this.all = "";
        }
        public void addUser(string name)
        {
            this.name = name;
        }
        public void addScore(int score)
        {
            this.score = score;
        }
        public void addAll(string all)
        {
            this.all = all;
        }
        public string getAll()
        {
            return all;
        }
        //public void Sort
    }
}
