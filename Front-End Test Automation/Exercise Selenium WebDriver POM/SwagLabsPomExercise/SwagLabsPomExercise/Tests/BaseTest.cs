﻿

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SwagLabsPOM.Pages;
using SwagLabsPomExercise.Pages;

namespace SwagLabsPomExercise.Tests
{
    public class BaseTest
    {
        protected IWebDriver driver;

        protected LoginPage loginPage;

        protected InventoryPage inventoryPage;

        protected CartPage cartPage;

        protected CheckoutPage checkoutPage;

        protected HiddenMenuPage hiddenMenuPage;

        [SetUp]
        public void SetUp()
        {
           var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("profile.password.manager.enabled", false);

            driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            loginPage = new LoginPage(driver);

            inventoryPage = new InventoryPage(driver);

            cartPage = new CartPage(driver);
            
            checkoutPage = new CheckoutPage(driver);

            hiddenMenuPage = new HiddenMenuPage(driver);
        }
        [TearDown] 
        public void TearDown()
        {
            driver.Quit();
            driver.Dispose();
        }
        protected void Login(string username, string password)
        {
            driver.Navigate().GoToUrl("https://www.saucedemo.com/");
            var loginPage = new LoginPage(driver);
            loginPage.LoginUser(username, password);
        }
    }
}
