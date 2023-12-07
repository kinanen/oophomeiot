using System;
namespace HomeIOT
{
	public class Kitchen : Room
	{
		public List<KitchenApplience> KitchenAppliences {get; set;} = new List<KitchenApplience>();
		public Kitchen(string name, Home home) : base(name, home)
		{
		}
	}
}

