using MySql.Data.MySqlClient;

namespace StudentsList
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public DateTime EnrollmentDate { get; set; }
        public bool IsActive { get; set; }
    }

    public interface IRepository<T>
    {
        public void Add(Student student);
        public List<Student> GetAll();
        public Student GetById(int Id);
        public void Update(Student student);
        public void Delete(int id);
    }

    public class StudentManager : IRepository<Student>
    {
        private readonly string _connectionString;
        public StudentManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Add(Student student)
        {
            using var connection = new MySqlConnection(_connectionString);
            
            string query = "INSERT INTO Students (FirstName, LastName, EnrollmentDate, IsActive) VALUES (@FirstName, @LastName, @EnrollmentDate, @IsActive)";

            using var command = new MySqlCommand(query ,connection);

            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@EnrollmentDate", student.EnrollmentDate);
            command.Parameters.AddWithValue("@IsActive", student.IsActive);

            connection.Open();
            command.ExecuteNonQuery();
        }

        public List<Student> GetAll()
        {
            List<Student> students = new List<Student>();

            using var connection = new MySqlConnection(_connectionString);

            string query = "SELECT Id, FirstName, LastName, EnrollmentDate, IsActive FROM Students";

            using var command = new MySqlCommand(query ,connection);

            connection.Open();
            using var reader = command.ExecuteReader();

            while (reader.Read())
            {
                students.Add(new Student {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                EnrollmentDate = reader.GetDateTime(3),
                IsActive = reader.GetBoolean(4)
                });
            }
            return students;
        }

        public Student GetById(int id)
        {   
            Student student = new Student();
            using var connection = new MySqlConnection(_connectionString);

            string query = "SELECT Id, FirstName, LastName, EnrollmentDate, IsActive FROM Students WHERE Id = @Id" ;

            using var command = new MySqlCommand(query ,connection);
            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            using var reader = command.ExecuteReader();

            if (reader.Read())
            {   
                return new Student
                {
                    Id = reader.GetInt32(0),
                    FirstName = reader.GetString(1),
                    LastName = reader.GetString(2),
                    EnrollmentDate = reader.GetDateTime(3),
                    IsActive = reader.GetBoolean(4)
                };
            }
            return student;
        }
        public void Update(Student student)
        {
            using var connection = new MySqlConnection(_connectionString);
            
            string query = "UPDATE Students SET FirstName = @FirstName, LastName = @LastName, IsActive = @IsActive WHERE Id = @Id;";

            using var command = new MySqlCommand(query ,connection);

            command.Parameters.AddWithValue("@FirstName", student.FirstName);
            command.Parameters.AddWithValue("@LastName", student.LastName);
            command.Parameters.AddWithValue("@IsActive", student.IsActive);
            command.Parameters.AddWithValue("@Id", student.Id);

            connection.Open();
            command.ExecuteNonQuery();

        }
        public void Delete(int id)
        {
            using var connection = new MySqlConnection(_connectionString);
            
            string query = "DELETE FROM Students WHERE Id = @Id";

            using var command = new MySqlCommand(query ,connection);

            command.Parameters.AddWithValue("@Id", id);

            connection.Open();
            command.ExecuteNonQuery();

        }
    }

}