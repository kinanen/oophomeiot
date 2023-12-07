namespace HomeIOT
{
    public class KitchenApplience: Applience
    {
        //NOTE Cold Appliences are listed separately!
        public KitchenApplience(String name, Room room): base(name, room)
        {
        }

        public override void Run()
        {
            if (Running)
            {
                return;
            }
            Running = true;
            BeenRunning = 0;
            timer = new(_ => BeenRunning++, null, 0, 1000);

            //MAX RunningTime for kitchen Some KitchenAppliance
            Thread.Sleep(2*60*1000);
            Stop();
        }
    }
}