using Microsoft.Data.SqlClient;

namespace MyApp.Services;

public class ExportService
{
    private readonly string _connectionString;
    public ExportService(string connectionString)
    {
        _connectionString = connectionString;
    }
    public void ExportAllCurrentMonth()
    {
        int currentMonth = DateTime.Now.Month;
        string query = "SELECT ID, Tittle, URL, Status, Month FROM Leads WHERE Month = @Month";        string filePath = @"/home/savchuk/Desktop/Work/export_all.csv"; 

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Month", currentMonth);

        connection.Open();

        using var reader = command.ExecuteReader();
        using var writer = new StreamWriter(filePath);
        
        writer.WriteLine("Id,Title,Url,Status,Month");
        
        int counter = 0; 

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            string url = reader.GetString(2);
            string status = reader.GetString(3);
            int? month = reader.IsDBNull(4) ? null : reader.GetInt32(4);

            writer.WriteLine($"{id},{title},{url},{status},{month}");
            counter++; 
        }
        
        Console.WriteLine($"\nExport succsess.");
        Console.WriteLine($"Кількість: {counter}. Файл: {filePath}\n");
    }

    public void ExportQualifiedCurrentMonth()
    {
        int currentMonth = DateTime.Now.Month;
        string query = "SELECT ID, Tittle, URL, Status, Month FROM Leads WHERE Month = @Month AND Status = 'Qualified'";        string filePath = @"/home/savchuk/Desktop/Work/export_qualified.csv";

        using var connection = new SqlConnection(_connectionString);
        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Month", currentMonth);

        connection.Open();

        using var reader = command.ExecuteReader();
        using var writer = new StreamWriter(filePath);
        
        writer.WriteLine("Id,Title,Url,Status,Month");
        
        int counter = 0;

        while (reader.Read())
        {
            int id = reader.GetInt32(0);
            string title = reader.GetString(1);
            string url = reader.GetString(2);
            string status = reader.GetString(3);
            int? month = reader.IsDBNull(4) ? null : reader.GetInt32(4);

            writer.WriteLine($"{id},{title},{url},{status},{month}");
            counter++; 
        }
        
        Console.WriteLine($"\nExport succsess.");
        Console.WriteLine($"Кількість: {counter}. Файл: {filePath}\n");
    }
}