using OpenQA.Selenium;


namespace SwagLabsPomExercise.Pages
{
    public class CartPage : BasePage
    {
        private readonly By CartItem = By.CssSelector(".cart_item");
        private readonly By CheckOutBtn = By.Id("checkout");
        public CartPage(IWebDriver driver) : base(driver)
        {
            
        }
        public bool IsCartItemDisplayed()
        {
            return FindElement(CartItem).Displayed;
        }
        public void ClickCheckOutBtn()
        {
            Click(CheckOutBtn);
        }
    }
}
