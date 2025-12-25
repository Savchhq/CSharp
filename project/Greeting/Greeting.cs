namespace Greeting
{
    public interface IGreeting
    {
        void Greeting();
    }
    public class EnglishGreeting : IGreeting
    {
        public void Greeting()
        {
            System.Console.WriteLine("Hello!");
        }
    }
    public class UkraineGreeting : IGreeting
    {
        public void Greeting()
        {
            System.Console.WriteLine("Привіт!");
        }
    }
    public class GreetingService
    {
        private readonly IGreeting _greeting;

        public GreetingService(IGreeting greeting)
        {
            _greeting = greeting;
        }

        public void SendGreeting()
        {
            _greeting.Greeting();
        }
    }
}