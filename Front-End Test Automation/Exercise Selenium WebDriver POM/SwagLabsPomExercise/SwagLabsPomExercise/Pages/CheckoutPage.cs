

using OpenQA.Selenium;

namespace SwagLabsPomExercise.Pages
{
    public class CheckoutPage : BasePage
    {
        private readonly By firstNameInput = By.Id("first-name");
        private readonly By lastNameInput = By.Id("last-name");
        private readonly By postalCode = By.Id("postal-code");
        private readonly By continueBtn = By.Id("continue");
        private readonly By finishBtn = By.Id("finish");
        private readonly By completeHeader = By.ClassName("complete-header");
        public CheckoutPage(IWebDriver driver) : base(driver)
        {
            
        }
        public void EnterFirstName(string firstName)
        {
            Type(firstNameInput, firstName);
        }
        public void EnterLastName(string lastName)
        {
            Type(lastNameInput, lastName);
        }
        public void EnterPostalCode(string postCode)
        {
            Type(postalCode, postCode);
        }
        public void ClickContinue()
        {
            Click(continueBtn);
        }
        public void ClickFinish()
        {
            Click(finishBtn);
        }
        public bool IsPageLoaded()
        {
            return driver.Url.Contains("checkout-step-one.html") ||
               driver.Url.Contains("checkout - step - two.html");
        }
        public bool IsCheckOutComplete()
        {
            return GetText(completeHeader) == "Thank you for your order!";
        }
    }
}
