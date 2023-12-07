using System;
namespace HomeIOT
{
	public class Heater 
	{
		public int MaxTemperature { get; private set; }
		public int MinTemperature { get; private set; }
		public int Temp { get; private set; }
		public Room Room { get; private set; }
		public Boolean HeatingOn;


		public Heater(Room room)
		{
			Room = room;
			Room.Heater = this;
			Temp = Room.GetTemperature();
			HeatingOn = false;
		}
		
        public void SetTemperature(int temp)
		{
			Temp = temp;
		}

        public void StartHeater()
        {
            Thread heaterThread = new(HeaterOn);
            heaterThread.Start();
        }

        public void HeaterOn()
		{
			//TURN ON THE HEATER
			HeatingOn = true; 
			while (HeatingOn)
			{
				int currentTemp = Room.GetTemperature();
				MinTemperature = Temp - 1;
				MaxTemperature = Temp + 1;
				if (currentTemp > MaxTemperature)
				{
					//Console.WriteLine($"Heat({currentTemp}) higher than set({Temp}), idling");
					//Turn heat element off thru API
				}
				if(currentTemp < MinTemperature)
				{
					//Console.WriteLine($"Heat({currentTemp}) Lower than set({Temp}, heating up");
					//Turn Heater element on thru API
				}
				else
				{
					//Console.WriteLine($"temperature({Temp}) withing set limit");
					// No Action to Heater Element.
				}
				// check temperature in 60 seconds
				Thread.Sleep(60000);
			}
		}
		public void HeaterOff()
		{
			// Turn off Heater device
			HeatingOn = false;

		}

		public override String ToString()
		{
			return $"set to {Temp}°c and is heating is on: {HeatingOn}";
		}

	}
}

