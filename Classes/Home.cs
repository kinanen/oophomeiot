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

			// Add home applications with no Special room set
			foreach(Applience appliance in Appliences)
			{
				appliances.Add(appliance.ToString()) ;
			}
			// Add all appliances from all rooms
            foreach (Room room in Rooms)
            {
                appliances.AddRange(room.GetAllAppliances());
            }
            return appliances;
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

			return status;
		}

    }
}

