namespace Generics{
public delegate int Compare<T>(T one, T two);
class Person
{
    public int Age { get; set; }
    public string Name { get; set; }
    
}
class PersonSorter
{
    public void SortFunc(Person[] person, Compare<Person> compare)
    {
        for(int i = 0; i < person.Length - 1; i++)
        {
            for(int j = i + 1; j < person.Length; j++)
            {
                if(compare(person[i], person[j])> 0)
                {
                    Person temp = person[i];
                    person[i] = person[j];
                    person[j] = temp;
                }
            }
        }

    }
}

class Program
{
      static void Main(string[] args)
    { 
    Person[] people =
    {
        new Person {Name = "Sophia", Age = 15},
        new Person {Name = "Vlad", Age = 28},
        new Person {Name = "Danya", Age = 23}
    };
   PersonSorter sorter = new PersonSorter();
   sorter.SortFunc(people, CompareByAge);
   foreach(Person person in people)
        {
            System.Console.WriteLine(person.Name + ": " + person.Age);
        }

   sorter.SortFunc(people, CompareByName);
   foreach(Person person in people)
        {
            System.Console.WriteLine(person.Name + ": " + person.Age);
        }
    }
    static int CompareByAge(Person one, Person two)
    {
        return one.Age.CompareTo(two.Age);
    }
    static int CompareByName(Person one, Person two)
    {
        return one.Name.CompareTo(two.Name);
    }
}
}