using System;
namespace HomeIOT
{
	public class Light
	{
		public string Name { get; set; }
		public Room Room { get; set; }
		public Boolean LightOn { get; set; }

		public Light(string name, Room room)
		{
			Name = name;
			Room = room;
			Room.Lights.Add(this);
		}

		public void TurnLightOn()
		{
			// Light On API
			LightOn = true;
		}
		public void TurnLightOff()
		{
			//LIGHT off thru API
			LightOn = false;
		}

		public override String ToString()
		{

			return $"{Name} lights on:{LightOn}";
		}

	}
}

