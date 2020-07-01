using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    public class Randomer
    {
        Random random = new Random();

        public int RandNext(int max)
        {
            return random.Next(max);
        }

        public int RandNext(int min, int max)
        {
            return random.Next(min, max);
        }
    }
}
