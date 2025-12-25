using System;

namespace Greeting
{
    class Program
    {
        static void Main()
        {
            IGreeting uk = new UkraineGreeting();
            IGreeting en = new EnglishGreeting();

            GreetingService serviceUk = new GreetingService(uk);
            GreetingService serviceEn = new GreetingService(en);
            
            serviceUk.SendGreeting();
            serviceEn.SendGreeting();     
        }
    }
}
    