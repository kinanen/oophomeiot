namespace HomeIOT
{
    public class Applience
    {
        public Timer? timer;
        public string Name;
        public Boolean Powered { get; set; }
        public Boolean Running { get; set; }
        public int BeenRunning { get; set; }
        public int WillRunFor { get; set; }
        public Room? Room;
        public Home? Home;
        

        public Applience(string name, Home home)
        {
            Name = name;
            Home = home;
            Home.Appliences.Add(this);
            Powered = true;
            BeenRunning = 0;
        }

        public Applience(string name, Room room)
        {
            Name = name;
            Room = room;
            Powered = true;
            BeenRunning = 0;
            Room.Appliences.Add(this);
        }

        public virtual void Run()
        {
            if (Running)
            {
                return;
            }
            //Start the device thru  API here, add error handling
            Running = true;
            BeenRunning = 0;
            timer = new( _=> BeenRunning++, null, 0, 1000);
        }

        public void Run(int duration)
        {
            if (Running)
            {
                return;
            }
            //Start the device thru  API here, add error handling
            Running = true;
            BeenRunning = 0;
            timer = new(_ => BeenRunning++, null, 0, 1000);

            Thread.Sleep(duration * 1000);

            Stop();
        }

        public void Stop()
        {
            // Stop the device with API here, add error handling
            Running = false;
            timer?.Dispose();
        }

        public override String ToString()
        {
            return $"{Name}, status: Powered {Powered}, Running {Running} current/last run for {BeenRunning}seconds";
        }

    }
}