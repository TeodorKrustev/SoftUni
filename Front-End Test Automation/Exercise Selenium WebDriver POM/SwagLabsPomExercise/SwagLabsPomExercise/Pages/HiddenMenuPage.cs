

using OpenQA.Selenium;

namespace SwagLabsPomExercise.Pages
{
    public class HiddenMenuPage : BasePage
    {
        private readonly By menuButton = By.CssSelector(".bm-burger-button");
        private readonly By logOutBtn = By.Id("logout_sidebar_link");
        public HiddenMenuPage(IWebDriver driver) : base(driver)
        {            
        }
        public void ClickMenuButton()
        {
            Click(menuButton);
        }
        public void ClickLogOutButton()
        {
            Click(logOutBtn);
        }
        public bool IsMenuOpen()
        {
            return driver.FindElement(logOutBtn).Displayed;
        }
    }
}
