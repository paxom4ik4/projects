using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class Tank
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private int _ammunition;

        public int Ammunition
        {
            get { return _ammunition; }
            
        }

        private int _armorLevel;

        public int ArmorLevel
        {
            get { return _armorLevel; }
       
        }

        private int _mobility;

        public int Mobility
        {
            get { return _mobility; }
        }

        public Tank(string tankName)
        {
            _ammunition = Randomer.Next(0, 100);
            _armorLevel = Randomer.Next(0, 100);
            _mobility = Randomer.Next(0, 100);
                

        }

        public static Tank operator ^(Tank A, Tank B)
        {
            if(A._ammunition > B._ammunition & A._armorLevel > B._armorLevel | A._ammunition > B._ammunition & A._mobility > B._mobility | A._armorLevel > B._armorLevel & A._mobility > B._mobility)
            {
                return A;
            }
            else
            {
                return B;
            }
        }

        public void GetInfo()
        {
            Console.WriteLine($"Боекоплект: {Ammunition} Уровень брони {ArmorLevel} Мобильность {Mobility}");
        }



    }
}
