using System;
namespace HomeIOT
{
    public class InitializeDemoHome
    {

        public static Home InitializeDemoHomeOne()
        {
            Home home = new Home("DemoHome");

            Room livingRoom = new Room("Living Room", home);
            Room kitchen = new Room("Kitchen", home);
            Room bedroom = new Room("Bedroom", home);

            Door frontDoor = new Door("Front Door", home);
            Door kitchenDoor = new Door("Kitchen Door", home);
            kitchenDoor.Lock();

            Blinds livingRoomBlinds = new Blinds(livingRoom, "Living Room Window");
            Blinds bedroomBlinds = new Blinds(bedroom, "Bedroom Window");
            bedroomBlinds.SetBlinds(60);

            Light kitchenLight = new Light("Kitchen Light", kitchen);
            LightDimmable livingRoomLight = new LightDimmable("Living Room Light", livingRoom);
            livingRoomLight.TurnLightOn(85);
            LightDimmable bedroomLight = new LightDimmable("Bedroom Light", bedroom);

            Heater bedroomHeater = new Heater(bedroom);
            Heater livingRoomHeater = new Heater(livingRoom);
            livingRoomHeater.StartHeater();

            Applience Tv = new("TV", livingRoom);
            KitchenApplience coffeeMaker = new KitchenApplience("Coffee Maker", kitchen);
            ColdApplience fridge = new ColdApplience("Fridge", kitchen);
            ColdApplience freezer = new ColdApplience("Freezer", kitchen);
            fridge.Stop();

            return home;
        }
    }
}