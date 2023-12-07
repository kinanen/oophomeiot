using System;
namespace HomeIOT
{
	public class Home
	{
		public String Name { get; private set; }
		public List<Room> Rooms { get; private set; } = new();
		public List<Door> Doors { get; private set; } = new();
        public List<Applience> Appliences { get; private set; } = new();
        public ControlPanel ControlPanel { get; set; }


        public Home(string name)
		{
			Name = name;
			ControlPanel = new(this);
		}

		public void AddRoom(Room room)
		{
			Rooms.Add(room);
			room.SetHome(this);
		}

		public void AddDoor(Door door)
		{
			Doors.Add(door);
		}

		public List<String> GetAllRoomTemperatures()
		{
			List<String> allRoomTemps = new();

			foreach (Room room in Rooms)
			{
				String roomTemp = room.NameAndTemperature();
				if(room.Heater != null){
					roomTemp += $" Heater: {room.Heater}";
				}
				allRoomTemps.Add(roomTemp);
			}
			return allRoomTemps;
		}

		public List<String> GetAllLights()
		{
			List<String> lights = new();
			foreach (Room room in Rooms)
			{
				lights.AddRange(room.GetAllLights());
			}
			return lights;
		}

		public List<String> GetAllAppliances()
		{
            List<String> appliances = new();

			foreach(Applience appliance in Appliences)
			{
				appliances.Add(appliance.ToString()) ;
			}

            foreach (Room room in Rooms)
            {
                appliances.AddRange(room.GetAllAppliances());
            }
            return appliances;
        }

		public List<String> GetAllBlinds()
		{
			List<String> blinds = new();
			foreach (Room room in Rooms)
			{
				blinds.AddRange(room.GetAllBlinds());
			}
			return blinds;
		}
		
		public List<String> GetAllHeaters()
		{
			List<String> heaters = new();
			foreach (Room room in Rooms)
			{
				if(room.Heater != null)
				{
				heaters.Add(room.Name +" "+ room.Heater.ToString());
				}
			}
			return heaters;
		}

		public void RemoveRoom(Room room)
		{
			Rooms.Remove(room);
		}
        public void RemoveDoor(Door door)
        {
            Doors.Remove(door);
        }

		public List<String> GetStatus(){
			List<String> status = new();
			status.Add($"Home: {Name}");
			status.Add($"Rooms: {String.Join(", ", Rooms)}");
			status.Add($"Doors: {String.Join(", ", Doors)}");
			status.Add($"Appliances: {String.Join(", ", GetAllAppliances())}");	
			status.Add($"Lights: {String.Join(", ", GetAllLights())}");
			status.Add($"Blinds: {String.Join(", ", GetAllBlinds())}");

			return status;
		}

    }
}

