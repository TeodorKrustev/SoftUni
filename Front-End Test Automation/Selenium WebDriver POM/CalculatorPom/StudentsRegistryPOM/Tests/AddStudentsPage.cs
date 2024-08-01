

using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class AddStudentsTest : BaseTest
    {
        [Test]
        public void Test_AddStudentsPage_Content()
        {
            AddStudentsPage addStudentsPage = new AddStudentsPage(driver);
            addStudentsPage.OpenPage();

            Assert.That(addStudentsPage.GetPageTitle(), Is.EqualTo("Add Student"));
            Assert.That(addStudentsPage.GetPageHeading(), Is.EqualTo("Register New Student"));

            Assert.That(addStudentsPage.NameField.Text, Is.EqualTo(""));
            Assert.That(addStudentsPage.EmailField.Text, Is.EqualTo(""));
            Assert.That(addStudentsPage.AddButton.Text, Is.EqualTo("Add"));

        }
        [Test]
        public void Test_TestAddStudentPage_AddValidStudent()
        {
            AddStudentsPage addStudentsPage = new AddStudentsPage(driver);
            addStudentsPage.OpenPage();

            string name = GenerateRandomName();
            string email = GenerateRandomEmail(name);

            addStudentsPage.AddStudent(name, email);

            ViewStudentsPage viewStudents = new ViewStudentsPage(driver);
            Assert.That(viewStudents.IsPageOpen(), Is.True);

            var students = viewStudents.GetRegisteredStudents();

            string newStudentFullString = name + " (" + email + ")";

            Assert.True(students.Contains(newStudentFullString));
    
        }
        [Test]
        public void Test_TestAddStudentPage_AddInvalidStudent()
        {
            AddStudentsPage addStudentsPage = new AddStudentsPage(driver);
            addStudentsPage.OpenPage();

            addStudentsPage.AddStudent("", "email@example.com");

            Assert.That(addStudentsPage.IsPageOpen(), Is.True);
            Assert.That(addStudentsPage.GetErrorMessage(), Is.EqualTo("Cannot add student. Name and email fields are required!"));

        }
        private string GenerateRandomName()
        {
            var random = new Random();
            string[] names = { "Gogo", "Simeon", "Petar", "Alex" };

            return names[random.Next(names.Length)] + random.Next(1000, 2000).ToString();
        }
        private string GenerateRandomEmail(string name)
        {
            var random = new Random();

            return name + random.Next(1000, 2000).ToString();
        }
    }
}
