namespace Practic
{
class Program
{
        static void Main(string[] args)
    {  
        Passwords one = new Passwords();
        one.Password = "https123";
        one.ShowInfo();
        
        List<Human> humans = new List<Human>();
        humans.Add(new Human("Sophia", 15));
        humans.Add(new Human("Vitaliy", 18));
        humans.Add(new Human("Vlad", 18, "Pryrodna 10"));
        humans[1].Address = "Zadvirie";
        humans[1].print();
        humans[1].Greeting();
        foreach(Human human in humans)
            {
                System.Console.WriteLine(human.Name);
            }

        Dictionary<int, Human> humanKey = new Dictionary<int, Human>();
        humanKey.Add(1, new Human("Sophia", 15));
        humanKey.Add(2, new Human("Jack", 27));
        humanKey.Add(3, new Human("John Comes", 30));
        humanKey.Remove(2);

        System.Console.WriteLine(humanKey[1].Name);

        Console.ReadKey();
    }
    
}
}