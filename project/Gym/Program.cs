using System;
using System.Collections.Generic;

public class Membership
{
    public string Name { get; set; }
    public int CountSessions { get; set; }
    public int Hour { get; set; }

    public Membership(string name,int sessions, int hour)
    {
        Name = name;
        CountSessions = sessions;
        Hour = hour;
    }

    public bool Login(int currentHour)
    {
        return CountSessions > 0 && currentHour < Hour;
    }
}

public class Human
{
    public string FullName { get; private set; }
    public Membership UserMembership { get; set; }

    public Human(string name, Membership membership)
    {
        FullName = name;
        UserMembership = membership;
    }
}

public class GymSystem
{
    public void TryEnter(Human person)
    {
        int currentHour = DateTime.Now.Hour;
        
        Console.WriteLine($"--- Спроба входу: {person.FullName} ---");
        Console.WriteLine($"Абонемент: {person.UserMembership.Name}. Час: {DateTime.Now:HH:mm}");

        if (person.UserMembership.Login(currentHour))
        {
            person.UserMembership.CountSessions--;
            Console.WriteLine("Вхід дозволено!");
            Console.WriteLine($"Залишилось занять: {person.UserMembership.CountSessions}");
        }
        else
        {
            Console.WriteLine("Вхід заборонено!");
            if (person.UserMembership.CountSessions <= 0)
                Console.WriteLine("Причина: Закінчилися заняття.");
            else
                Console.WriteLine($"Причина: Ваш абонемент діє тільки до {person.UserMembership.Hour}:00.");
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main()
    {
        Membership day = new Membership("Денний", 12, 14);
        Membership evening = new Membership("Вечірній", 16, 20);

        Human user1 = new Human("Савчук Владислав", day);
        Human user2 = new Human("Морозко Василь", evening);

        GymSystem gym = new GymSystem();

        gym.TryEnter(user1);
        gym.TryEnter(user2);
    }
}