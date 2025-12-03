
    namespace ExerciseOne
    {
        public class Student
        {
            private int _id;
            private string _name;

            public int Id { get => _id;}
            public string Name { get => _name;}

            public Student()
            {
                _id = 0;
                _name = "None";
            }
            public Student(int id, string name)
            {
                _id = id;
                _name = name;
            }

            private  Dictionary<string, int> _assignmentScores = new Dictionary<string, int>();
            public IReadOnlyDictionary<string, int> AssignmentScores => _assignmentScores;
            public void AddScore(string assignmentName, int score)
            {
                if (score < 0 || score > 100)
                {
                    Console.WriteLine("Error! Score is incorrect.");
                    return;
                }

                if (_assignmentScores.ContainsKey(assignmentName))
                {
                    Console.WriteLine("Error! Assignment name already exists.");
                    return;
                }

                _assignmentScores.Add(assignmentName, score);
            }

        }
    }