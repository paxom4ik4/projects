using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalExam
{
    public class TController {
        public string Name { get; set; }
        private int Weather; 
        
        public int getRecommendedHeight(Plane plane)
        {
            return 7 * plane.Speed - Weather;
        }

        public TController(string _name)
        {
            Name = _name;
            Randomer randomer = new Randomer();
            Weather = randomer.RandNext(-200, 200);
        }

       
}
}
