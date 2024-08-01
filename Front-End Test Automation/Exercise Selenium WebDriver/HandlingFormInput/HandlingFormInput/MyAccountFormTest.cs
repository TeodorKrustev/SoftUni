using HandlingFormInputs;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using static System.Net.WebRequestMethods;

namespace HandlingFormInput
{
    public class Tests
    {
        private IWebDriver driver;
        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
            driver.Url = "http://practice.bpbonline.com/";
        }
        [TearDown] 
        public void TearDown() 
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void MyAccountForm()
        {
            var myAccountElement = driver.FindElement(By.XPath("//*[@id=\"tdb3\"]/span[2]"));
            myAccountElement.Click();

            var continueBtnElement = driver.FindElement(By.CssSelector("#tdb4 > span.ui-button-text"));
            continueBtnElement.Click();

            var maleRadioButton = driver.FindElement(By.CssSelector("#bodyContent > form > div > div:nth-child(2) > table > tbody > tr:nth-child(1) > td.fieldValue > input[type=radio]:nth-child(1)"));
            maleRadioButton.Click();
            Assert.That(maleRadioButton.Selected, Is.True);

            var firstNameInput = driver.FindElement(By.CssSelector("#bodyContent > form > div > div:nth-child(2) > table > tbody > tr:nth-child(2) > td.fieldValue > input[type=text]"));
            firstNameInput.Click();
            firstNameInput.SendKeys("John");

            var lastNameInput = driver.FindElement(By.CssSelector("#bodyContent > form > div > div:nth-child(2) > table > tbody > tr:nth-child(3) > td.fieldValue > input[type=text]"));
            lastNameInput.Click();
            lastNameInput.SendKeys("Doe");

            DatePicker datePicker = new DatePicker(driver);
            datePicker.OpenDatePicker(By.XPath("//td[@class='fieldValue']//input[@name='dob']"));

            datePicker.SelectDate("Jun", "2000", 23);

            // Generate random email
            Random rnd = new Random();
            int num = rnd.Next(1000, 2000);
            string email = "john.doe" + num.ToString() + "@example.com";

            var emailInput = driver.FindElement(By.CssSelector("#bodyContent > form > div > div:nth-child(2) > table > tbody > tr:nth-child(5) > td.fieldValue > input[type=text]"));
            emailInput.Click();
            emailInput.SendKeys(email);

            var companyInput = driver.FindElement(By.CssSelector("#bodyContent > form > div > div:nth-child(4) > table > tbody > tr > td.fieldValue > input[type=text]"));
            companyInput.Click();
            companyInput.SendKeys("ITCompany");

            var streetInput = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[4]/table/tbody/tr[1]/td[2]/input"));
            streetInput.Click();
            streetInput.SendKeys("Street1");

            var suburbInput = driver.FindElement(By.CssSelector("#bodyContent > form > div > div:nth-child(6) > table > tbody > tr:nth-child(2) > td.fieldValue > input[type=text]"));
            suburbInput.Click();
            suburbInput.SendKeys("Sofia");

            var postCodeInput = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[4]/table/tbody/tr[3]/td[2]/input"));
            postCodeInput.Click();
            postCodeInput.SendKeys("1000");

            var cityInput = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[4]/table/tbody/tr[4]/td[2]/input"));
            cityInput.Click();
            cityInput.SendKeys("Sofia");

            var stateInput = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[4]/table/tbody/tr[5]/td[2]/input"));
            stateInput.Click();
            stateInput.SendKeys("Sofia");

            new SelectElement(driver.FindElement(By.Name("country"))).SelectByText("Bulgaria");

            var telephoneInput = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[5]/table/tbody/tr[1]/td[2]/input"));
            telephoneInput.Click();
            telephoneInput.SendKeys("13415151341");

            var newsletterCheckBox = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[5]/table/tbody/tr[3]/td[2]/input"));
            newsletterCheckBox.Click();

            var passwordInput = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[6]/table/tbody/tr[1]/td[2]/input"));
            passwordInput.Click();
            passwordInput.SendKeys("12345");

            var confirmPassInput = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]/form/div/div[6]/table/tbody/tr[2]/td[2]/input"));
            confirmPassInput.Click();
            confirmPassInput.SendKeys("12345");

            var submittBtn = driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span[2]"));
            submittBtn.Click();

            var createdProfileText = driver.FindElement(By.XPath("//*[@id=\"bodyContent\"]"));
            Assert.That(createdProfileText.Displayed, Is.True);

            var logOfftBtn = driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span"));
            logOfftBtn.Click();

            var continueBtn = driver.FindElement(By.XPath("//*[@id=\"tdb4\"]/span[2]"));
            continueBtn.Click();

            Console.WriteLine("User Account Created with email: " + email);
        }
    }
}