using System;
namespace HomeIOT
{
	public class Blinds
	{
		private Room Room { get; set; }
		public String Window { get; set; }
		private Boolean BlindsOpen { get; set; }
		private int OpenPrecentage { set; get; }

		public Blinds(Room room, String window)
		{
			Room = room;
			Window = window;
			Room.Blinds.Add(this);
		}

		public void Open()
		{
			// OPEN THE ACUTAL BLINDS FULLY
			BlindsOpen = true;
			OpenPrecentage = 100;
		}
		public void Close()
		{
			// CLOSE THE ACTUAL SMARTBLINDS
			BlindsOpen = false;
            OpenPrecentage = 100;
        }

		public void SetBlinds(int precentage)
		{
			if (precentage < 1)
			{
				Close();
			}
			if (precentage > 99)
			{
				Open();
			}
			else { OpenPrecentage = precentage; }
		}

		public override String ToString()
		{
			return $"{Room}n {Window}, blinds at {OpenPrecentage}%";
		}

	}
}

