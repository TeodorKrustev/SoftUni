

using OpenQA.Selenium;
using System.Security.Cryptography.X509Certificates;

namespace StudentsRegistryPOM.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {            
        }

        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/";

        public IWebElement StudentsCountElement => driver.FindElement(By.XPath("/html/body/p"));

        public int StudentsCount() 
        {
            string studentsCountString = this.StudentsCountElement.Text;
            return int.Parse(studentsCountString);
        }
    }
}
