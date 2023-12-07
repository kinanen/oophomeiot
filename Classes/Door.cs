using Microsoft.AspNetCore.Authorization.Infrastructure;

namespace HomeIOT
{

    public class Door
    {
        public String Name { get; private set; }
        public Home Home { get; private set; }
        public Boolean Locked { get; private set; }
        public Boolean Open { get; private set; }

        public Door(String name, Home home)
        {
            Name = name;
            Home = home;
            home.AddDoor(this);
            Open = false;
            Locked = false;
        }

        public void Unlock()
        {
            //LOCK API HERE
            Locked = false;
        }

        public void Lock()
        {
            // LOCK API HERE
            Locked = true;
        }

        public Boolean IsLocked()
        {
            return Locked;
        }

        public Boolean IsOpen()
        {
            return Open;
        }

        public override string ToString()
        {
            return $"{Name} is Open: {Open} and Locked: {Locked}";
        }

    }
}