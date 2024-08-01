using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsPomExercise.Pages
{
    public class LoginPage : BasePage
    {
        private readonly By usernameField = By.Id("user-name");

        private readonly By passwordField = By.Id("password");

        private readonly By loginButton = By.Id("login-button");

        private readonly By errorMessage = By.XPath("//*[@id='login_button_container']/div/form/div[3]");
        public LoginPage(IWebDriver driver) : base(driver)
        {

        }

        public void FillUserName(string username)
        {
            Type(usernameField, username);
        }

        public void FillPassword(string password)
        {
            Type(passwordField, password);
        }
        public void ClickLoginButton()
        {
            Click(loginButton);
        }
        public string GetErrorMessage()
        {
            return GetText(errorMessage);
        }
        public void LoginUser(string username, string password)
        {
            FillUserName(username);
            FillPassword(password);
            ClickLoginButton();
        }
    }
}
