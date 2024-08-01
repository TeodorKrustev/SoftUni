
using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    public class BasePage
    {
        protected readonly IWebDriver driver;

        public virtual string PageUrl { get; }

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);           
        }
        public IWebElement HomeLink => driver.FindElement(By.XPath("/html/body/a[1]"));
        public IWebElement ViewStudentsLink => driver.FindElement(By.XPath("/html/body/a[2]"));
        public IWebElement AddStudentsLink => driver.FindElement(By.XPath("/html/body/a[3]"));
        public IWebElement PageHeading => driver.FindElement(By.XPath("/html/body/h1"));
        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }
        public bool IsPageOpen()
        {
            return driver.Url == this.PageUrl;
        }

        public string GetPageTitle()
        {
            return driver.Title;
        }
        
        public string GetPageHeading()
        {
            return PageHeading.Text;
        }
    }
}
