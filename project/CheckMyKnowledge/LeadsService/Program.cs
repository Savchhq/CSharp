using MyApp.Data;
using MyApp.Models;
using MyApp.Services;

class Program()
{
     static void Main(string[] args)
    {
        List<Lead> leads = new List<Lead>();
        string connectionString = "Server=localhost,1433;Database=MyDB;User Id=sa;Password=Root_Root123;TrustServerCertificate=True;";
        Repository repository = new Repository(connectionString);

        bool IsExit = true;
        while (IsExit)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1 - Show all leads");
            Console.WriteLine("2 - Add new lead");
            Console.WriteLine("3 - Update lead");
            Console.WriteLine("4 - Delete lead");
            Console.WriteLine("5 - Export all (current month)");
            Console.WriteLine("6 - Export 'Кваліфікованих' (current month)");
            Console.WriteLine("0 - Exit");
            System.Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: 
                {   
                    List<Lead> databaseLeads = repository.Read();

                    foreach (Lead lead in databaseLeads)
                    {
                        Console.WriteLine($"Id: {lead.ID}");
                        Console.WriteLine($"Title: {lead.Tittle}");
                        Console.WriteLine($"URL: {lead.URL}");
                        Console.WriteLine($"Status: {lead.Status}");
                        Console.WriteLine($"Month: {lead.Month}");
                        Console.WriteLine("---------------------------");
                    }
                    break;
                }
                case 2:
                {
                    Console.Write("Enter tittle: ");
                    string tittle = Console.ReadLine() ?? "";
                
                    Console.Write("Enter URL: ");
                    string url = Console.ReadLine() ?? "";
                
                    Console.Write("Enter status: ");
                    string status = Console.ReadLine() ?? "";
                
                    Lead lead = new Lead
                    {
                        Tittle = tittle,
                        URL = url,
                        Status = status,
                        Month = DateTime.Now.Month
                    };
                
                    repository.Create(lead);
                    break;
                }
                case 3:
                {
                    List<Lead> databaseLeads = repository.Read();
                    System.Console.Write("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Lead? leadToUpdate = databaseLeads.FirstOrDefault(x => x.ID == id);

                     if (leadToUpdate == null)
                    {
                        Console.WriteLine("Lead not found");
                        break;
                    }
                    
                    System.Console.Write("Enter choice: ");
                    int choiceUpdate = Convert.ToInt32(Console.ReadLine());
                    switch (choiceUpdate)
                    {
                        case 1: 
                        {
                        Console.Write("Enter a title: ");
                        leadToUpdate.Tittle = Console.ReadLine() ?? "";
                        break;
                        }
                        case 2: 
                        {
                        Console.Write("Enter URL: ");
                        leadToUpdate.URL = Console.ReadLine() ?? "";
                        break;
                        }
                        case 3: 
                        {
                        Console.Write("Enter status: ");
                        leadToUpdate.Status = Console.ReadLine() ?? "";
                        break;
                        }
                        case 4: 
                        {
                        Console.Write("Enter month: ");
                        leadToUpdate.Month = Convert.ToInt32(Console.ReadLine());
                        break;
                        }
                        default:
                        break;
                    }
                    repository.Update(leadToUpdate);
                    break;
                }
                case 4:
                    {
                        System.Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        repository.Delete(id);
                        break;
                    }
                case 5:
                {
                    ExportService exportService = new ExportService(connectionString);
                    exportService.ExportAllCurrentMonth();
                    break;
                }
                case 6:
                {
                    ExportService exportService = new ExportService(connectionString);
                    exportService.ExportQualifiedCurrentMonth();
                    break;
                }
                case 0: 
                    IsExit = false;
                    break;
                default:
                    Console.WriteLine("Invalid choice.");
                    break;
            }
        }
    } 
}