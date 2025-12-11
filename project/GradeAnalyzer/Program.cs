using System;

namespace ExerciseOne
{
    class Program
{
    static void Main()
    {
       Student firstStudent = new Student(101, "Alice");
       Student secondStudent = new Student(102, "Bob");
       firstStudent.AddScore("Midterm", 85);
       firstStudent.AddScore("Project", 92);
       secondStudent.AddScore("Quiz1", 110);
       secondStudent.AddScore("Quiz1", 78);
       secondStudent.AddScore("Finaly", 65);
       System.Console.WriteLine(GradeAnalyzer.CalculateAverage(firstStudent)); 
       System.Console.WriteLine(GradeAnalyzer.CalculateAverage(secondStudent));
    }
}

}