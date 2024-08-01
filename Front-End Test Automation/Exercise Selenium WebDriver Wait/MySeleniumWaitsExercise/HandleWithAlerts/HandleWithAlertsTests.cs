using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace HandleWithAlerts
{
    public class HandleWithAlertsTests
    {
        private WebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://the-internet.herokuapp.com/javascript_alerts";
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }

        [Test]
        public void HandleBasicAlert()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[1]/button")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.EqualTo("I am a JS Alert"), "Alert text is not as expected");

            alert.Accept();

            var resultElement = driver.FindElement(By.Id("result"));
            Assert.That(resultElement.Text, Is.EqualTo("You successfully clicked an alert"), "Result text is not as expected");
        }

        [Test]
        public void HandleConfirmAlert()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[2]/button")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.EqualTo("I am a JS Confirm"), "Alert text is not as expected");

            alert.Accept();

            var resultElement = driver.FindElement(By.Id("result"));
            Assert.That(resultElement.Text, Is.EqualTo("You clicked: Ok"), "Result text is not as expected");

            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[2]/button")).Click();

            alert = driver.SwitchTo().Alert();

            alert.Dismiss();

            resultElement = driver.FindElement(By.Id("result"));
            Assert.That(resultElement.Text, Is.EqualTo("You clicked: Cancel"), "Result text is not as expected");
        }
        [Test]
        public void HandlePromptAlert()
        {
            driver.FindElement(By.XPath("//*[@id=\"content\"]/div/ul/li[3]/button")).Click();

            IAlert alert = driver.SwitchTo().Alert();

            Assert.That(alert.Text, Is.EqualTo("I am a JS prompt"), "Alert text is not as expected");

            string inputText = "Hello";
            alert.SendKeys(inputText);

            alert.Accept();

           IWebElement resultElement = driver.FindElement(By.Id("result"));
            Assert.That(resultElement.Text, Is.EqualTo("You entered: " + inputText), "Result message is not as expected");
        }
    }
}