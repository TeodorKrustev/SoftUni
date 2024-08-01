using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace MySeleniumWaitsExercise
{
    public class SearhKeyboardImplicitWaitTests
           
    {
        private ChromeDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "http://practice.bpbonline.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [TearDown]
        public void Teardown()
        {
            driver.Dispose();
            driver.Quit();
        }


        [Test]
        public void SearchProduct_Keyboard_ShouldAddToCart()
        {
            driver.FindElement(By.XPath("//*[@id=\"columnLeft\"]/div[3]/div[2]/form/input[1]")).SendKeys("keyboard");

            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.LinkText("Buy Now")).Click();

                Assert.That(driver.PageSource.Contains("keyboard"), Is.True, "The product keyboard was not found in the cart page");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
            
        }
        [Test]
        public void SearchForJunk()
        {
            driver.FindElement(By.Name("keywords")).SendKeys("junk");

            driver.FindElement(By.XPath("//input[@title=' Quick Find ']")).Click();

            try
            {
                driver.FindElement(By.LinkText("Buy Now")).Click();
            }
            catch (NoSuchElementException ex)
            {
                Assert.Pass("Expected NoSuchElementException was thrown");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexcpected exception: " + ex.Message);
            }


        }
    }
}