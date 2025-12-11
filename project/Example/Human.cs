    namespace Practic
    {
    public interface IGreeting
    {
        void Greeting(); 
    }
    public class Human : IGreeting
    {
        private string _name;
        private int _age;
        private string _address;
        public string Address { private get => _address; set => _address = value ; }

        public Human() 
        {
            _name = "Unknown";
            _age = 0;
            _address = "None";
        }   
            public Human(string name, int age, string address = "None"){
            _name = name; 
            _age = age;
            _address = address;
        }

        public string Name { get => _name; set => _name = value; }

        public int Age { get => _age; set => _age = value; }

        public void print(){
            System.Console.WriteLine($"Name: {_name}\nAge: {_age}\nAddress: {_address}");
        }
        public void Greeting()
        {
           System.Console.WriteLine("Hello, i`m "+ _name);            
        }
    }

    }