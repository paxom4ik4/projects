using System;
using Demo.HouseClasses;
using Demo.TeamClasses;

namespace Demo
{
		class Program
		{
				static void Main(string[] args)
				{
						House house = new House();

						Builder builder1 = new Builder();
						builder1.Work(house);

						TeamLead tm1 = new TeamLead();
						tm1.Work(house);

						Console.ReadKey();
				}
		}
}
