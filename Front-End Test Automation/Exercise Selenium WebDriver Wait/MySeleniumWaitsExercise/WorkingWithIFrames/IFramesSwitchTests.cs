using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace WorkingWithIFrames
{
    public class IFramesSwitchTests
    {
        private WebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://codepen.io/pervillalva/full/abPoNLd";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }
        [Test]
        public void TestIFrameByIndex()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt(By.TagName("iframe")));

            var dropDownBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
            dropDownBtn.Click();

            var dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("body > div > div")));

            foreach (var link in dropDownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.IsTrue(link.Displayed);
            }

            driver.SwitchTo().DefaultContent();
        }
        [Test]
        public void TestIFrameById()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.FrameToBeAvailableAndSwitchToIt("result"));

            var dropDownBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
            dropDownBtn.Click();

            var dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("body > div > div")));

            foreach (var link in dropDownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.IsTrue(link.Displayed);
            }

            driver.SwitchTo().DefaultContent();
        }
        [Test]
        public void TestIFrameByWebElement()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
           var frameElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector("#result")));

            driver.SwitchTo().Frame(frameElement);

            var dropDownBtn = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".dropbtn")));
            dropDownBtn.Click();

            var dropDownLinks = wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(By.CssSelector("body > div > div")));

            foreach (var link in dropDownLinks)
            {
                Console.WriteLine(link.Text);
                Assert.IsTrue(link.Displayed);
            }

            driver.SwitchTo().DefaultContent();
        }
    }
}