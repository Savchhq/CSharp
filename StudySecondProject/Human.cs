    namespace Practic
    {
        public class Human
    {
        private string name;
        private int age;
        public string Address { get; set; }

        public Human() 
        {
            name = "Unknown";
            age = 0;
            Address = "None";
        }   
            public Human(string name, int age, string Address = "None"){
            this.name = name; 
            this.age = age;
            this.Address = Address;
        }

        public string Name { get => name; set => name = value; }

        public int Age { get => age; set => age = value; }

        public void print(){
            System.Console.WriteLine($"Name: {name}\nAge: {age}\nAddress: {Address}");
        }
    }

    }