using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    class Program
    {
        static void Main(string[] args)
        {
            Plane plane = new Plane();

            TController controller1 = new TController("1st Cont");
            TController controller2 = new TController("2nd Cont");

            plane.controllers.Add(controller1);
            plane.controllers.Add(controller2);

            Console.WriteLine(plane.controllers[0].getRecommendedHeight(plane)); 

            Randomer randomer = new Randomer();

            Console.WriteLine(randomer.RandNext(-200, 200));

            while (true)
            {

            }

            Console.ReadKey();
        }
    }
}
