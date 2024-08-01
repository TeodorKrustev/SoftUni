

using OpenQA.Selenium;

namespace StudentsRegistryPOM.Pages
{
    public class AddStudentsPage : BasePage
    {
        public AddStudentsPage(IWebDriver driver) : base(driver)
        {            
        }
        public override string PageUrl => "http://softuni-qa-loadbalancer-2137572849.eu-north-1.elb.amazonaws.com:82/add-student";

        public IWebElement NameField => driver.FindElement(By.XPath("//*[@id='name']"));
        public IWebElement EmailField => driver.FindElement(By.XPath("//*[@id='email']"));
        public IWebElement AddButton => driver.FindElement(By.XPath("/html/body/form/button"));
        public IWebElement ErrorMessage => driver.FindElement(By.XPath("/html/body/div"));

        public string GetErrorMessage()
        {
            return ErrorMessage.Text;
        }
        public void AddStudent(string name, string email)
        {
            this.NameField.SendKeys(name);
            this.EmailField.SendKeys(email);
            this.AddButton.Click();
        }
    }
}
