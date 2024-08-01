using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V124.Network;
using System.Security.Cryptography.X509Certificates;

namespace LocatorsPractice
{
    public class LocatorsPracticeTests

    {

        private ChromeDriver driver;

        [OneTimeSetUp]
        public void OneTimeSetup()
        {
            driver = new ChromeDriver();
            driver.Url = "file:///C:/Users/Admin/Desktop/Front-End/Front-End%20Test%20Automation/Selenium%20WebDriver/SimpleForm/Locators.html";
        }
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            driver.Quit();
            driver.Dispose();
        }

        [Test]
        public void BasicLocators()
        {
           var lastNameElement = driver.FindElement(By.Id("lname"));
            Assert.That(lastNameElement.Displayed, Is.True);

           var newsletterElement = driver.FindElement(By.Name("newsletter"));
            Assert.That(newsletterElement.Displayed, Is.True);

           var linkElement = driver.FindElement(By.TagName("a"));
            Assert.That(linkElement.Displayed, Is.True);

           var informationElement = driver.FindElement(By.ClassName("additional-info"));
            Assert.That(informationElement.Displayed, Is.True);
        }
        [Test]
        public void TextLinkLocators() 
        {
           var softUniLink = driver.FindElement(By.LinkText("Softuni Official Page"));
            var hrefAttribute = softUniLink.GetAttribute("href");
            Assert.That(hrefAttribute, Is.EqualTo("http://www.softuni.bg/"));

            var partialElementText = driver.FindElement(By.PartialLinkText("Official Page"));
            Assert.That(partialElementText.Displayed, Is.True);
        }
        [Test]
        public void CSSselectors() 
        {
           var firstNameInputById = driver.FindElement(By.CssSelector("#fname"));
            var firstNameValue = firstNameInputById.GetAttribute("value");
            Assert.That(firstNameValue, Is.EqualTo("Vincent"));

           var firstNameInputByName = driver.FindElement(By.CssSelector("input[name='fname']"));
            var firstNameValueByName = firstNameInputByName.GetAttribute("value");
            Assert.That(firstNameValueByName, Is.EqualTo("Vincent"));

          var button = driver.FindElement(By.CssSelector("input[class*='button']"));
            var buttonValue = button.GetAttribute("value");
            Assert.That(buttonValue, Is.EqualTo("Submit"));

           var phoneNumberInput = driver.FindElement(By.CssSelector("body > form > div > p > input[type=text]"));
            Assert.That(phoneNumberInput.Displayed, Is.True);

           var phoneNumberInputWithDifferentLocator = driver.FindElement(By.CssSelector("form div.additional-info input[type=text]"));
            Assert.That(phoneNumberInputWithDifferentLocator.Displayed, Is.True);
        }
        [Test]
        public void XPathLocators() 
        {
            var firstNameInput = driver.FindElement(By.XPath("//*[@id=\"fname\"]"));
            var firstNameValue = firstNameInput.GetAttribute("value");
            Assert.That(firstNameValue, Is.EqualTo("Vincent"));

           var maleRadioButton = driver.FindElement(By.XPath("//input[@value='m']"));
            var maleRadioButtonValue = maleRadioButton.GetAttribute("value");
            Assert.That(maleRadioButtonValue, Is.EqualTo("m"));

           var lastNameInput = driver.FindElement(By.XPath("//*[@id=\"lname\"]"));
            var lastNameValue = lastNameInput.GetAttribute("value");
            Assert.That(lastNameValue, Is.EqualTo("Vega"));

           var newsletterCheckbox = driver.FindElement(By.XPath("//input[@type='checkbox']"));
            var newsletterCheckBoxType = newsletterCheckbox.GetAttribute("type");
            Assert.That(newsletterCheckBoxType, Is.EqualTo("checkbox"));

           var button = driver.FindElement(By.XPath("//input[@class='button']"));
            var buttonValue = button.GetAttribute("value");
            Assert.That(buttonValue, Is.EqualTo("Submit"));

            var phoneNumberInput = driver.FindElement(By.XPath("//input[@type='text']"));
            Assert.That(phoneNumberInput.Displayed, Is.True);

            
        }
        [Test]
        public void fillTheFormTest()
        {

            var contactFormTitle = driver.FindElement(By.XPath("/html/body/h2"));
            Assert.That(contactFormTitle.Displayed, Is.True);

            var maleRadioButton = driver.FindElement(By.XPath("/html/body/form/input[1]"));
            maleRadioButton.Click();
            Assert.That(maleRadioButton.Selected, Is.True);

            var firstNameInput = driver.FindElement(By.XPath("//*[@id=\"fname\"]"));
            firstNameInput.Clear();
            firstNameInput.SendKeys("Butch");
            var firstNameInputValue = firstNameInput.GetAttribute("value");
            Assert.That(firstNameInputValue, Is.EqualTo("Butch"));

            var lastNameInput = driver.FindElement(By.XPath("//*[@id=\"lname\"]"));
            lastNameInput.Clear();
            lastNameInput.SendKeys("Coolidge");
            var lastNameValue = lastNameInput.GetAttribute("value");
            Assert.That(lastNameValue, Is.EqualTo("Coolidge"));

            var additionalInfoSection = driver.FindElement(By.XPath("/html/body/form/div"));
            Assert.That(additionalInfoSection.Displayed, Is.True);

            var phoneNumberInput = driver.FindElement(By.XPath("/html/body/form/div/p/input"));
            phoneNumberInput.Clear();
            phoneNumberInput.SendKeys("0888999777");
            var phoneNumberValue = phoneNumberInput.GetAttribute("value");
            Assert.That(phoneNumberValue, Is.EqualTo("0888999777"));

            var newsletterCheckBox = driver.FindElement(By.XPath("/html/body/form/input[5]"));
            newsletterCheckBox.Click();
            Assert.That(newsletterCheckBox.Selected, Is.True);

            var submittButton = driver.FindElement(By.XPath("/html/body/form/input[6]"));
            submittButton.Click();

            var thankYouMessage = driver.FindElement(By.XPath("/html/body"));
            Assert.That(thankYouMessage.Displayed, Is.True);

        }
    }
}