namespace StudentsList
{
   class Program
    {
     static void Main(string[] args)
        {
        string connectionString = "Server=127.0.0.1;Database=myBD;User ID=root;Password=rootroot;";
        StudentManager studentManager = new StudentManager(connectionString);

        bool IsExit = true;
        while (IsExit)
        {
            Console.WriteLine("\n--- Menu ---");
            Console.WriteLine("1 - Show all students ");
            Console.WriteLine("2 - Add new student");
            Console.WriteLine("3 - Update student");
            Console.WriteLine("4 - Delete student");
            Console.WriteLine("5 - Show student by ID ");
            Console.WriteLine("0 - Exit");
            System.Console.Write("Enter choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1: 
                {   
                    List<Student> dbStudents = studentManager.GetAll();

                    foreach (Student student in dbStudents)
                    {
                        Console.WriteLine($"Id: {student.Id}");
                        Console.WriteLine($"First name: {student.FirstName}");
                        Console.WriteLine($"Last name: {student.LastName}");
                        Console.WriteLine($"Enrollment date: {student.EnrollmentDate}");
                        Console.WriteLine($"Is active: {student.IsActive}");
                        Console.WriteLine("---------------------------");
                    }
                    break;
                }
                case 2:
                {
                    Console.Write("Enter first name: ");
                    string firstName = Console.ReadLine() ?? "";
                
                    Console.Write("Enter last name: ");
                    string lastName = Console.ReadLine() ?? "";
                
                    Console.Write("Enter is active(True or False): ");
                    bool isActive = Convert.ToBoolean(Console.ReadLine());
                
                    Student student = new Student
                    {
                        FirstName = firstName,
                        LastName = lastName,
                        IsActive = isActive,
                        EnrollmentDate = DateTime.Now
                    };
                
                    studentManager.Add(student);
                    break;
                }
                case 3:
                {
                    System.Console.Write("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());

                    Student studentToUpdate = studentManager.GetById(id);


                     if (studentToUpdate.Id == 0)
                    {
                        Console.WriteLine("Student not found");
                        break;
                    }
                    
                    Console.WriteLine("\n--- What do you want to update? ---");
                    Console.WriteLine("1 - First Name");
                    Console.WriteLine("2 - Last Name");
                    Console.WriteLine("3 - Is Active Status");
                    Console.Write("Enter choice: ");
                    int choiceUpdate = Convert.ToInt32(Console.ReadLine());
                    switch (choiceUpdate)
                    {
                        case 1: 
                        {
                        Console.Write("Enter a first name: ");
                        studentToUpdate.FirstName = Console.ReadLine() ?? "";
                        break;
                        }
                        case 2: 
                        {
                        Console.Write("Enter a last name: ");
                        studentToUpdate.LastName = Console.ReadLine() ?? "";
                        break;
                        }
                        case 3: 
                        {
                        Console.Write("Enter is active(True or False): ");
                        studentToUpdate.IsActive = Convert.ToBoolean(Console.ReadLine());
                        break;
                        }
                        default:
                        break;
                    }
                    studentManager.Update(studentToUpdate);
                    break;
                }
                case 4:
                    {
                        System.Console.Write("Enter ID: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        studentManager.Delete(id);
                        break;
                    }
                case 5:
                {
                    System.Console.WriteLine("Enter ID: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    Student studentsById = studentManager.GetById(id);

                     if (studentsById.Id == 0)
                    {
                        Console.WriteLine("Student not found");
                        break;
                    }

                    Console.WriteLine($"Id: {studentsById.Id}");
                    Console.WriteLine($"First name: {studentsById.FirstName}");
                    Console.WriteLine($"Last name: {studentsById.LastName}");
                    Console.WriteLine($"Enrollment date: {studentsById.EnrollmentDate}");
                    Console.WriteLine($"Is active: {studentsById.IsActive}");
                    Console.WriteLine("---------------------------");
                    
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
}
