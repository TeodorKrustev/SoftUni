using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace WebDriverNakovSiteTest
{
    public class NakovComTests

    {
        private ChromeDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }

        [Test]
        public void Test1()
        {
            driver.Navigate().GoToUrl("https://nakov.com");
            var windowTitle = driver.Title;
            Assert.That(windowTitle, Is.EqualTo("Svetlin Nakov - Svetlin Nakov – Official Web Site and Blog"));
            Console.WriteLine(windowTitle);

            var searchLink = driver.FindElement(By.ClassName("smoothScroll"));
            Assert.That(searchLink.Text, Does.Contain("SEARCH"));
            searchLink.Click();
            var searchInput = driver.FindElement(By.Id("s"));
            var placeHolderText = searchInput.GetAttribute("placeholder");
            Assert.That(placeHolderText, Is.EqualTo("Search this site"));
            Console.WriteLine(placeHolderText);
     
        }
       
    }
}