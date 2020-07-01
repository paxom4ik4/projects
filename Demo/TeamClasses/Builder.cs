using Demo.HouseClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.TeamClasses
{
		public class Builder: Worker
		{
				public override void Work(House house)
				{

						foreach (var item in house.Parts)
						{
								Console.WriteLine($"{item.GetType().Name}:{item.Size}, {item.Material}");
						}
				}
		}
}
