using System;


namespace Demo.HouseClasses
{
		public class Part
		{
				public int Size { get; set; }
				public string Material { get; set; }
				public decimal Cost { get; set; }

				public virtual void CalculateCost()
				{
						decimal materialPrice = 0;
						switch (Material)
						{
								case "Beton": materialPrice = 100; break;
								case "Block": materialPrice = 25; break;
								case "Plastic": materialPrice = 10; break;
						}
						Cost = Size * materialPrice;
				}

				public void Build() 
				{ 
		
				}
		}
}
