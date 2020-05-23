using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Puzzle_Vilan_Marius
{
    class Timer
    {
        public int minute = 0;
        public int secunde = 0;
        private int total_time = 0;
        public Timer(int minute, int secunde, int total_time)
        {
            this.minute = minute;
            this.secunde = secunde;
            this.total_time = total_time;
        }
        public void Restart()
        {
            minute = 0;
            secunde = 0;
            total_time = 0;
        }
        public int calculateTotalTime()
        {
            return minute * 60 + secunde;
        }
    }
}
