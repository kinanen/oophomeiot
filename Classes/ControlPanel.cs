namespace HomeIOT
{
    public class ControlPanel
    {
        private readonly Action<string> Output = Console.WriteLine;
        public Home Home { get; private set; }

        public ControlPanel(Home home)
        {
            Home = home; 
        }

        public void ShowMessage(string msg)
        {
            Output(msg);
        }

        public void ShowError(string msg)
        {
            Output(msg);
        }
    }
}