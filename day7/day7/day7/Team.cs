using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace day7
{
    class Team
    {
        Tank[] tanks = new Tank[5];

        public Tank[] Tanks
        {
            get { return tanks; }
            set { tanks = value; }
        }

        public Team(int TeamSize, string tankName)
        {
            tanks = new Tank[TeamSize];
            for (int i = 0; i < TeamSize; i++)
            {
                Tank NewTank = new Tank(tankName);
                tanks[i] = NewTank;
            }
        }

        public Tank this[int index]
        {
            get { return tanks[index]; } 
            
        }

       

    }
}
