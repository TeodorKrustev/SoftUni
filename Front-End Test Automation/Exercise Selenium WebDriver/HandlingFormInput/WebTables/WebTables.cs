using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System.Collections.ObjectModel;

namespace WebTables
{
    public class Tests
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
        public void ManageTable()
        {
            IWebElement productsTable = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/div/div[2]/table/tbody"));

          ReadOnlyCollection<IWebElement> tableRows = productsTable.FindElements(By.XPath("//tbody/tr"));

            string path = System.IO.Directory.GetCurrentDirectory() + "/productinformation.csv";

            if (File.Exists(path))
                File.Delete(path);

            foreach (IWebElement trow in tableRows) 
            {
                ReadOnlyCollection<IWebElement> tableData = trow.FindElements(By.XPath(".//td"));

                foreach (var tData in tableData) 
                {
                    string data = tData.Text;
                    string[] productInfo = data.Split("\n");

                    File.AppendAllText(path, productInfo[0].Trim() + ", " + productInfo[1].Trim() + "\n");
                }

                Assert.IsTrue(File.Exists(path));
                Assert.IsTrue(new FileInfo(path).Length > 0);
            }
        }
    }
}