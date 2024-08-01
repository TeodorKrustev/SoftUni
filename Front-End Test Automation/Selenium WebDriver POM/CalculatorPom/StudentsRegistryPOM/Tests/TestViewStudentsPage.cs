

using StudentsRegistryPOM.Pages;

namespace StudentsRegistryPOM.Tests
{
    public class TestViewStudentsPage : BaseTest
    {
        [Test]
        public void Test_ViewStudentsPage_Content()
        {
            ViewStudentsPage viewStudentsPage = new ViewStudentsPage(driver);
            viewStudentsPage.OpenPage();

            Assert.That(viewStudentsPage.GetPageTitle(), Is.EqualTo("Students"));
            Assert.That(viewStudentsPage.GetPageHeading(), Is.EqualTo("Registered Students"));

            var students = viewStudentsPage.GetRegisteredStudents();

            foreach(var student in students )
            {
                Assert.That(student.Contains("("), Is.True);
                Assert.That(student.LastIndexOf(")") == student.Length - 1, Is.True);
            }
        }
    }
}
