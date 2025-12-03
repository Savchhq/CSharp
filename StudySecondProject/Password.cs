namespace Practic
{
    public class Passwords
    {
        private string _password;
        public string Password { set { _password = value; } }

        public Passwords()
        {
            _password = "";
        }   

        public void ShowInfo()
        {
            string password;
            System.Console.Write("Enter the password: ");
            password = Console.ReadLine();
            if(password == _password)
            {
                System.Console.WriteLine("Good, password is: " + _password);
            }
            else
            {
                System.Console.WriteLine("Password incorrect!");
            }
        }
    }
}