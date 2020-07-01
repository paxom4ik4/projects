using System;
using System.Collections.Generic;

namespace Demo.HouseClasses
{
		public class House
		{
				public List<Part> Parts;
				public House()
				{
						Parts = new List<Part>()
						{
								new Basement() { Size = 50, Material = "Beton", IsReinforced = true },
								new Wall() { Size = 10, Thickness = 3, Material = "Block" },
								new Wall() { Size = 20, Thickness = 4, Material = "Block" },
								new Wall() { Size = 20, Thickness = 4, Material = "Block" },
								new Wall() { Size = 10, Thickness = 3, Material = "Block" },
								new Window() { Size = 100, Countsections = 5, Material = "Plastic" }
						};
				}
		}
}
