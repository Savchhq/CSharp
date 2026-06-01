using System.Runtime.InteropServices;
using Microsoft.Data.SqlClient;

namespace Practic
{
    public class DatabaseManager
    {
        // Private because only this class needs to know the password and connection details
        private string connectionString = "Server=localhost,1433;Database=MyDB;User Id=sa;Password=Root_Root123;TrustServerCertificate=True;";

        public void AddHuman(string firstName, int age, string? address)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "INSERT INTO Humans (FirstName, Age, Adress) VALUES (@name, @age, @address)";
                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", firstName);
                    cmd.Parameters.AddWithValue("@age", age);
                    cmd.Parameters.AddWithValue("@address", (object?)address ?? DBNull.Value); 
                    
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"{firstName} added to the database.");
        }

        public void UpdateHumanAddress(string firstName, string newAddress)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "UPDATE Humans SET Adress = @address WHERE FirstName = @name";
                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@address", newAddress);
                    cmd.Parameters.AddWithValue("@name", firstName);
                    
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"Updated address for {firstName}.");
        }

        public void DeleteHuman(string firstName)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "DELETE FROM Humans WHERE FirstName = @name";
                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@name", firstName);
                    cmd.ExecuteNonQuery();
                }
            }
            Console.WriteLine($"{firstName} was removed from the database.");
        }

        public void PrintAllHumans()
        {
            Console.WriteLine("\n--- Current Humans in Database ---");
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string sql = "SELECT ID, FirstName, Age, Adress FROM Humans";
                
                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader.GetInt32(0);
                            string name = reader.GetString(1);
                            int age = reader.IsDBNull(2) ? 0 : reader.GetInt32(2);
                            string address = reader.IsDBNull(3) ? "No Address" : reader.GetString(3);

                            Console.WriteLine($"ID: {id} | Name: {name} | Age: {age} | Address: {address}");
                        }
                    }
                }
            }
        }
    }
}