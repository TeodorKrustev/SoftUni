using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Collections.ObjectModel;

namespace WorkingWithWindows
{
    public class WindowsManageTests
    {
        private WebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "https://the-internet.herokuapp.com/windows";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }

        [Test]
        public void HandleMultipleWindows()
        {
            driver.FindElement(By.LinkText("Click Here")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            Assert.That(windowHandles.Count, Is.EqualTo(2), "There should be two opened windows");

            driver.SwitchTo().Window(windowHandles[1]);

            string newWindowContent = driver.PageSource;
            Assert.IsTrue(newWindowContent.Contains("New Window"), "The content of the new window is not as expected");

            string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");

            if (File.Exists(path))
            {
                File.Delete(path);
            }
            File.AppendAllText(path, "current handle: " + driver.CurrentWindowHandle);
            File.AppendAllText(path, "page content: " + newWindowContent);

            driver.Close();
        }
        [Test]
        public void HandleNoSuchWindowException() 
        {
            driver.FindElement(By.LinkText("Click Here")).Click();

            ReadOnlyCollection<string> windowHandles = driver.WindowHandles;

            driver.SwitchTo().Window(windowHandles[1]);

            driver.Close();

            try
            {
                driver.SwitchTo().Window(windowHandles[1]);
            }
            catch (NoSuchWindowException ex)
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "windows.txt");
                File.AppendAllText(path, "NoSuchWindowExceptionCaught: " + ex.Message + "\n\n");
                Assert.Pass("Expected NoSuchWindowException was thrown");
            }
            catch (Exception ex)
            {
                Assert.Fail("Unexpected exception: " + ex.Message);
            }
            finally
            {
                driver.SwitchTo().Window(windowHandles[0]);
            }
        }
    }
}