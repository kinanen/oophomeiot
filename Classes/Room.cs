using System;
using System.Reflection.Metadata.Ecma335;

namespace HomeIOT
{
	public class Room
	{
		public Home	Home { get; private set; }
		public string Name { get; private set; }
		public TemperatureMeter TemperatureMeter { get; private set; }
		public List<Applience> Appliences { get; private set; } = new List<Applience>();
		public List<Heater> Heater { get; private set; } = new List<Heater>();
		public List<Light> Lights { get; private set; } = new List<Light>();
		public List<Blinds> Blinds { get; set; } = new();
		
		public Room(string name, Home home)
		{
			Home = home;
			Home.AddRoom(this);
			Name = name;
			TemperatureMeter = new TemperatureMeter();
		}
		public static int GetTemperature()
		{
			return TemperatureMeter.GetTemperature();
		}

		public string NameAndTemperature(){
			int temp = GetTemperature();
			return $"{Name} {temp}°c";
		}

        internal void SetHome(Home home)
        {
			Home = home;
        }

		public void AddApplience(Applience applience)
		{
			Appliences.Add(applience);
		}
		public void RemoveApplience(Applience applience)
		{
			Appliences.Remove(applience);
		}

        public List<String> GetAllLights()
        {
			List <String> lights = new();

			foreach(Light light in Lights)
			{ 
				lights.Add(light.ToString());
			}
			return lights;
        }

        internal IEnumerable<string> GetAllAppliances()
        {
            List<String> appliances = new();
            foreach (Applience appliance in Appliences)
            {
                appliances.Add($"{Name} {appliance.ToString()}");
            }
			return appliances;
        }

		public override string ToString(){
			return Name;
		}
    }
}

