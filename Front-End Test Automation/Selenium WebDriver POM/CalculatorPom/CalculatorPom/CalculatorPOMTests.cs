using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Cryptography.X509Certificates;

namespace CalculatorPom
{
    public class CalculatorPOMTests
    {
        public IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }
        [TearDown] 
        public void Teardown() 
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void Test_AddTwoNumbers_ValidInput()
        {
            var calculatorPage = new SumNumberPage(driver);
            calculatorPage.OpenPage();

            string result = calculatorPage.AddNumbers("3", "3");

            Assert.That(result, Is.EqualTo("Sum: 6"));
        }
        [Test]
        public void Test_AddTwoNumbers_InvalidInput()
        {
            var calculatorPage = new SumNumberPage(driver);
            calculatorPage.OpenPage();

            string result = calculatorPage.AddNumbers("hello", "3");

            Assert.That(result, Is.EqualTo("Sum: invalid input"));
        }
        [Test]
        public void Test_ResetForm()
        {
            var calculatorPage = new SumNumberPage(driver);
            calculatorPage.OpenPage();

            string result = calculatorPage.AddNumbers("3", "3");

            Assert.That(result, Is.EqualTo("Sum: 6"));

            calculatorPage.ResetForm();
            Assert.True(calculatorPage.IsFormEmpty());
        }
    }
}