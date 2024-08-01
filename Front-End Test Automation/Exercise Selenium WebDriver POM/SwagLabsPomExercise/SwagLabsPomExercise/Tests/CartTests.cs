

namespace SwagLabsPomExercise.Tests
{
    public class CartTests : BaseTest
    {
        [SetUp]
        public void SetUp() 
        {
            Login("standard_user", "secret_sauce");

            inventoryPage.AddToCartByIndex(1);
            inventoryPage.ClickCartLink();
        }
        [Test]
        public void TestCartItemDisplayed()
        {
            Assert.That(cartPage.IsCartItemDisplayed(), Is.True);
        }
        [Test]
        public void TestClickCheckout()
        {
            cartPage.ClickCheckOutBtn();

            Assert.That(checkoutPage.IsPageLoaded(), Is.True, "Page is not loaded correctly");
        }
    }
}
