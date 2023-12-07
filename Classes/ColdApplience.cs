using System;
using System.Xml.Linq;

namespace HomeIOT
{
	public class ColdApplience : Applience
	{
		
		public ColdApplience(string name, Room room) : base(name, room)
        {
			Run();
			ActiveStatus();
        }

		public void ActiveStatus()
		{
			Timer statusTimer = new(_=>CheckStatus(), null, 0, 10000); 

		}

		private void CheckStatus()
		{
			if (Running) return;
			Room?.Home.ControlPanel.ShowError($"Attention! Cold applience {Name} not running.");
		}
	}
}

