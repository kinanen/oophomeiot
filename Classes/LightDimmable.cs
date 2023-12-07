using System;
namespace HomeIOT
{
	public class LightDimmable: Light
	{
        public int DimPercent { get; set; }

        public LightDimmable(string name, Room room):base(name, room)
		{
        }

		public void TurnLightOn(int dim)
		{
			if (dim > 99)
			{
				TurnLightOn();
				DimPercent = 100;
			}
			if(dim < 1)
			{
				TurnLightOff();
				DimPercent = 0;				
			}
			else
			{
				DimPercent = dim;
				// SET ACTUAL LIGHT TO DIM PRECENTEGE
			}
		}
	}
}

