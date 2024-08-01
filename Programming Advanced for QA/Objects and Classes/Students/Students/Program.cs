namespace Students
{
    public class Student
    {
        public Student(string firstName, string lastName, int age, string homeTown)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            HomeTown = homeTown;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string HomeTown { get; set; }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();
            List<Student> students = new List<Student>();

            while (command != "end")
            {
                string[] studentData = command.Split(" ");

                if (studentData.Length == 4)
                {
                    string firstName = studentData[0];
                    string lastName = studentData[1];

                    if (int.TryParse(studentData[2], out int age))
                    {
                        string homeTown = studentData[3];

                        Student currentStudent = new Student(firstName, lastName, age, homeTown);
                        students.Add(currentStudent);
                    }
                    else
                    {
                        Console.WriteLine("Invalid age. Please enter a valid integer for age.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter data in the format: FirstName LastName Age HomeTown");
                }

                command = Console.ReadLine();
            }

            string targetCity = Console.ReadLine();
            List<Student> filteredStudents = students.Where(x => x.HomeTown == targetCity).ToList();

            foreach (Student student in filteredStudents)
            {
                Console.WriteLine($"{student.FirstName} {student.LastName} is {student.Age} years old.");
            }
        }
    }
}
