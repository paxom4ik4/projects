using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.HouseClasses
{
		public class Window:Part
		{
				public int Countsections { get; set; }

				public override void CalculateCost()
				{
						base.CalculateCost();

						Cost = Cost + Countsections * 1000;
				}
		}
}
