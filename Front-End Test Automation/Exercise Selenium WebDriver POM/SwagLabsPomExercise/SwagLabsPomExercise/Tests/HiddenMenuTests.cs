using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwagLabsPomExercise.Tests
{
    public class HiddenMenuTests : BaseTest
    {
        [SetUp]
        public void SetUp() 
        {
            Login("standard_user", "secret_sauce");
        }
        [Test]
        public void TestOpenMenu()
        {
            hiddenMenuPage.ClickMenuButton();

            Assert.True(hiddenMenuPage.IsMenuOpen());
        }
        [Test]
        public void TestLogout()
        {
            hiddenMenuPage.ClickMenuButton();
            hiddenMenuPage.ClickLogOutButton();

            Assert.That(driver.Url, Is.EqualTo("https://www.saucedemo.com/"));
        }
    }
}
