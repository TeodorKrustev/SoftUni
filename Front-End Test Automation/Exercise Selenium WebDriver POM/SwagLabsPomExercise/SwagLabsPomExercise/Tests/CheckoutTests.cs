using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsPomExercise.Tests
{
    public class CheckoutTests : BaseTest
    {
        [SetUp]
        public void SetUp()
        {
            Login("standard_user", "secret_sauce");

            inventoryPage.AddToCartByIndex(1);
            inventoryPage.ClickCartLink();
            cartPage.ClickCheckOutBtn();
        }
        [Test]
        public void TestCheckoutPageLoaded()
        {
            Assert.That(checkoutPage.IsPageLoaded(), Is.True, "Page is not loaded correctly");
        }
        [Test]
        public void TestContinueToNextStep()
        {
            checkoutPage.EnterFirstName("John");
            checkoutPage.EnterLastName("Doe");
            checkoutPage.EnterPostalCode("1000");
            checkoutPage.ClickContinue();

            Assert.That(driver.Url.Contains("checkout-step-two.htm"));
        }
        [Test]
        public void TestCompleteOrder()
        {
            checkoutPage.EnterFirstName("John");
            checkoutPage.EnterLastName("Doe");
            checkoutPage.EnterPostalCode("1000");
            checkoutPage.ClickContinue();
            checkoutPage.ClickFinish();

            Assert.That(checkoutPage.IsCheckOutComplete(), Is.True, "CheckOut is not complete");
        }
    }
}
