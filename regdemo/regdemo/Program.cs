using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace regdemo
{
    class Program
    {
        static void Main(string[] args)
        {

            string pattern = @"abcdefghijklmnopqrstuv18340";
            string[] values = { "abcdefghijklmnopqrstuv18340", "abcdefghijklmnoasdfasdpqrstuv18340" };
            foreach (string value in values)
            {
                if (Regex.IsMatch(value, pattern))
                    Console.WriteLine("Является {0}", value);
                else
                    Console.WriteLine("Не является {0}", value);
            }

            string pattern1 = @"[a-fA-F0-9]{8}-([a-fA-F0-9]{4}-){3}[a-fA-F0-9]{12}";
            string[] values1 = { "e02fd0e4-00fd-090A-ca30-0d00a0038ba0", "e02fd0e400fd090Aca300d00a0038ba0" };

            foreach (string value in values1)
            {
                if (Regex.IsMatch(value, pattern1))
                    Console.WriteLine("Является {0}", value);
                else
                    Console.WriteLine("Не является {0}", value);
            }

            string pattern2 = @"([0-9A-Fa-f]{2}[:]){5}([0-9A-Fa-f]{2})";
            string[] values2 = { "aE:dC:cA:56:76:54", "01:23:45:67:89:Az " };

            foreach (string value in values2)
            {
                if (Regex.IsMatch(value, pattern2))
                    Console.WriteLine("Является {0}", value);
                else
                    Console.WriteLine("Не является {0}", value);
            }

            string pattern3 = @"#[a-fA-F0-9]{6}";
            string[] values3 = { "#FFFFFF", "#FF3421", "#00ff00", "232323", "f#fddee", "#fd2" };
            foreach (string value in values3)
            {
                if (Regex.IsMatch(value, pattern3))
                    Console.WriteLine("Является {0}", value);
                else
                    Console.WriteLine("Не является {0}", value);
            }

            string pattern4 = @"\d{2}\/\d{2}\/[2-9]\d{3}";
            string[] values4 = { "29/02/2000", "30/04/2003", "01/01/2003", "30-04-2003", "1/1/1899" };

            foreach (string value in values4)
            {
                if (Regex.IsMatch(value, pattern4))
                    Console.WriteLine("Является {0}", value);
                else
                    Console.WriteLine("Не является {0}", value);
            }

         

            Console.ReadKey();
        }
    }
}
