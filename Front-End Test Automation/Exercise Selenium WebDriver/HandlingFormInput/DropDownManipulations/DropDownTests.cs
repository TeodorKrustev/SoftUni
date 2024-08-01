using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.ObjectModel;

namespace DropDownManipulations
{
    public class DropDownTests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "http://practice.bpbonline.com/";
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }
        [TearDown]
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
        [Test]
        public void DropDownMenu() 
        {
            string path = Directory.GetCurrentDirectory() + "/manufacturer.txt";

            if(File.Exists(path)) 
            {
                File.Delete(path);
            }

            SelectElement dropDownElement = new SelectElement(driver.FindElement(By.Name("manufacturers_id")));

            IList<IWebElement> options = dropDownElement.Options;

            List<string> optionsAsString = new List<string>();

            foreach (var option in options) 
            {
                optionsAsString.Add(option.Text);
            }
            optionsAsString.RemoveAt(0);

            foreach (var option in optionsAsString) 
            { 
                dropDownElement.SelectByText(option);
                dropDownElement = new SelectElement(driver.FindElement(By.XPath("//*[@id=\"columnLeft\"]/div[2]/div[2]/form/select")));
                if (driver.PageSource.Contains("There are no products available in this category."))
                {
                    File.AppendAllText(path, $"The manufacturer {option} has no products");
                } else
                {
                    IWebElement productTable = driver.FindElement(By.ClassName("productListingData"));

                    File.AppendAllText(path, $"\n\nThe manufacturer {option} products are listed--\n)");
                    ReadOnlyCollection<IWebElement> rows = productTable.FindElements(By.XPath("//tbody/tr"));

                    foreach (IWebElement row in rows)
                    {
                        File.AppendAllText(path, row.Text + "\n");
                    }
                }
            }
        }

    }
}