using System;

namespace Demo.HouseClasses
{
		class Wall:Part
		{
				public int Thickness  { get; set; }

				public override void CalculateCost()
				{
						base.CalculateCost();
						Cost = Cost + Thickness * 200;
				}
		}
}
