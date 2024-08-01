using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

namespace DataDrivenTests
{
    public class TestCalculator
    {
        private IWebDriver driver;
        IWebElement textBoxNumber1;
        IWebElement textBoxNumber2;
        IWebElement dropdownOperation;
        IWebElement calcButton;
        IWebElement resetButton;
        IWebElement divResult;
        [OneTimeSetUp] 
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Url = "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com/number-calculator/";
        }
        [SetUp]
        public void Setup()
        {
            
            textBoxNumber1 = driver.FindElement(By.Id("number1"));
            textBoxNumber2 = driver.FindElement(By.Id("number2"));
            dropdownOperation = driver.FindElement(By.Id("operation"));
            calcButton = driver.FindElement(By.Id("calcButton"));
            resetButton = driver.FindElement(By.Id("resetButton"));
            divResult = driver.FindElement(By.Id("result"));
        }
        [OneTimeTearDown] 
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }
        public void PerformTestLogic(string firstNumber, string operation, string secondNumber, string expectedResult)
        {
            resetButton.Click();

            if (!string.IsNullOrEmpty(firstNumber))
            {
                textBoxNumber1.SendKeys(firstNumber);
            }

            if (!string.IsNullOrEmpty(secondNumber))
            {
                textBoxNumber2.SendKeys(secondNumber);
            }

            if (!string.IsNullOrEmpty(operation))
            {
                new SelectElement(dropdownOperation).SelectByText(operation);
            }

            calcButton.Click();

            Assert.That(divResult.Text, Is.EqualTo(expectedResult));

        }

        [Test]
        [TestCase("5", "+ (sum)", "10", "Result: 15")]
        [TestCase("3.5", "- (subtract)", "1.2", "Result: 2.3")]
        [TestCase("2e2", "* (multiply)", "1.5", "Result: 300")]
        [TestCase("5", "/ (divide)", "0", "Result: Infinity")]
        [TestCase("invalid", "+ (sum)", "10", "Result: invalid input")]
        public void TestNumberCalculator(string firstNumber, string operation, string secondNumber, string expectedResult)
        {

         PerformTestLogic(firstNumber, operation, secondNumber, expectedResult);
            
        }
    }
}