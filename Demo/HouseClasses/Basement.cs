using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.HouseClasses
{
		public class Basement : Part
		{
				public bool IsReinforced { get; set; }

				public override void CalculateCost()
				{
						base.CalculateCost();
						decimal BaseCost = base.Cost;
						if (IsReinforced)
						{
								Cost += Cost + Cost * 0.3m;
						}
				}
		}
}
