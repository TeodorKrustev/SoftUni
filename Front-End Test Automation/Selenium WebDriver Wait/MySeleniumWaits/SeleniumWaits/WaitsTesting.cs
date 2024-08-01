using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace SeleniumWaits
{
    public class WaitsTesting
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.selenium.dev/selenium/web/dynamic.html";
        }
        [TearDown] 
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test, Order(1)]
        public void AddBoxWithoutWaitsFails()
        {
            var addBoxBtn = driver.FindElement(By.XPath("//*[@id=\"adder\"]"));
            addBoxBtn.Click();

            Assert.Throws<NoSuchElementException>(
                () => driver.FindElement(By.Id("box0"))
            );
        }
        [Test, Order(2)]
        public void RevealInputWithoutWaitsFail()
        {
            driver.FindElement(By.Id("reveal")).Click();

            IWebElement revealed = driver.FindElement(By.Id("revealed"));

            Assert.Throws<ElementNotInteractableException>(
                () => revealed.SendKeys("Displayed")
            );
        }
        [Test, Order(3)]
        public void AddBoxWithThreadSleep()
        {
            var addBoxBtn = driver.FindElement(By.XPath("//*[@id=\"adder\"]"));
            addBoxBtn.Click();

            Thread.Sleep(3000);

            var boxElement = driver.FindElement(By.Id("box0"));
            Assert.That(boxElement.Displayed, Is.True);
        }
        [Test, Order(4)]
        public void AddBoxWithImplicitWait()
        {
            var addBoxBtn = driver.FindElement(By.XPath("//*[@id=\"adder\"]"));
            addBoxBtn.Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            var boxElement = driver.FindElement(By.Id("box0"));
            Assert.That(boxElement.Displayed, Is.True);
        }
        [Test, Order(5)]
        public void RevealInputWithImplicitWaits()
        {
            driver.FindElement(By.Id("reveal")).Click();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            IWebElement revealed = driver.FindElement(By.Id("revealed"));

            Assert.That(revealed.TagName, Is.EqualTo("input"));
        }
        [Test, Order(6)]
        public void RevealInputWithExplicitWaits() 
        {
            driver.FindElement(By.Id("reveal")).Click();
            IWebElement revealed = driver.FindElement(By.Id("revealed"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(2));
            wait.Until(d => revealed.Displayed);

            revealed.SendKeys("Displayed");
            Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
        }
        [Test, Order(7)]
        public void AddBoxWithFluentWaitExpectedConditionsAndIgnoredExceptions()
        {
            driver.FindElement(By.XPath("//*[@id=\"adder\"]")).Click();

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.PollingInterval = TimeSpan.FromMilliseconds(500);
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            IWebElement boxElement = wait.Until(ExpectedConditions.ElementIsVisible(By.Id("box0")));

            Assert.IsTrue(boxElement.Displayed);
        }
        [Test, Order(8)]
        public void RevealInputWithCustomFluentWait()
        {
            driver.FindElement(By.Id("reveal")).Click();
            IWebElement revealed = driver.FindElement(By.Id("revealed"));

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.PollingInterval = TimeSpan.FromMilliseconds(200);
            wait.IgnoreExceptionTypes(typeof(ElementNotInteractableException));
            wait.Until(d => {
                revealed.SendKeys("Displayed");
                return true;
            });

            Assert.That(revealed.TagName, Is.EqualTo("input"));
            Assert.That(revealed.GetAttribute("value"), Is.EqualTo("Displayed"));
        }
    }
}