using System;
namespace HomeIOT
{
	public class TemperatureMeter
	{
		private static int Temp;

		public TemperatureMeter()
		{
            Temp = Measure();
		}

        public static int GetTemperature()
        {
            return Measure();
        }

        private static int Measure()
        {
            Random random = new();
            Temp = random.Next(18, 26);
            return Temp;

        }

    }
}

