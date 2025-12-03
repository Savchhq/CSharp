
namespace ExerciseOne
{
    static public class GradeAnalyzer
    {
        static public double CalculateAverage(Student student)
        {
            double sum = 0;
            int count = 0;
            foreach(int score in student.AssignmentScores.Values)
            {
                sum+= score;
                count++;
            }
            if(count > 0)
            {
                return sum / count;
            }
            else
            {
                System.Console.WriteLine("Error! DivideByZeroException!");
                return 0.0;
            }
        }
    }
}