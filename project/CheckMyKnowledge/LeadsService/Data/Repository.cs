using Microsoft.Data.SqlClient;
using MyApp.Models;


namespace MyApp.Data;

public class Repository
{
    private readonly string _connectionString;
    public Repository(string connectionString)
    {
        _connectionString = connectionString;
    }
 
    public void Create(Lead lead)
    {
        using var connection = new SqlConnection(_connectionString);

        string query = """
            INSERT INTO Leads (Tittle, URL, Status, Month)
            VALUES (@Tittle, @URL, @Status, @Month)
        """;

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@Tittle", lead.Tittle);
        command.Parameters.AddWithValue("@URL", lead.URL);
        command.Parameters.AddWithValue("@Status", lead.Status);
        command.Parameters.AddWithValue("@Month", lead.Month);

        connection.Open();
        command.ExecuteNonQuery();
    }
    public List<Lead> Read()
    {
        var leads = new List<Lead>();
        using var connection = new SqlConnection(_connectionString);
        string query = "SELECT ID, Tittle, URL, Status, Month FROM Leads";      
        
        using var command = new SqlCommand(query, connection);

        connection.Open();

        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            leads.Add(new Lead
            {
                ID = reader.GetInt32(0),
                Tittle = reader.GetString(1),
                URL = reader.GetString(2),
                Status = reader.GetString(3),
                Month = reader.IsDBNull(4) ? null : reader.GetInt32(4)
            });
        }
        return leads;
    }
    public void Update(Lead lead)
    {
        using var connection = new SqlConnection(_connectionString);
        string query = """
            UPDATE Leads 
            SET Tittle = @Tittle, URL = @URL, Status = @Status, Month = @Month
            WHERE ID = @ID
        """;

        using var command = new SqlCommand(query, connection);

        command.Parameters.AddWithValue("@Id", lead.ID);
        command.Parameters.AddWithValue("@Tittle", lead.Tittle);
        command.Parameters.AddWithValue("@URL", lead.URL);
        command.Parameters.AddWithValue("@Status", lead.Status);
        command.Parameters.AddWithValue("@Month", lead.Month);

        connection.Open();
        command.ExecuteNonQuery();
    }
    public void Delete(int Id)
    {
        using var connection = new SqlConnection(_connectionString);

        var query = "DELETE FROM Leads WHERE ID = @ID";

        using var command = new SqlCommand(query, connection);
        command.Parameters.AddWithValue("@ID", Id);

        connection.Open();
        command.ExecuteNonQuery();
    }
}

