using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppiumSummatorDemo
{
    public class SummatorPOMTests
    {
        private AndroidDriver _driver;

        private AppiumLocalService _appiumLocalService;

        private SummatorPage _summatorPage;

        [OneTimeSetUp]
        public void Setup()
        {
            _appiumLocalService = new AppiumServiceBuilder()
                .WithIPAddress("127.0.0.1")
                .UsingPort(4723)
                .Build();
            _appiumLocalService.Start();

            var androidOptions = new AppiumOptions
            {
                PlatformName = "Android",
                AutomationName = "UiAutomator2",
                PlatformVersion = "14",
                App = "C:\\Users\\Admin\\Desktop\\Front-End\\Front-End Test Automation\\Exercise Appium Mobile - Part 1\\com.example.androidappsummator.apk",
                DeviceName = "Pixel 7 API 34"
            };
            _driver = new AndroidDriver(_appiumLocalService, androidOptions);

            _summatorPage = new SummatorPage(_driver);
        }
        [OneTimeTearDown]
        public void TearDown()
        {
            _driver?.Quit();
            _driver?.Dispose();
            _appiumLocalService?.Dispose();
        }

        [Test]
        public void TestWithValid_Data()
        {
          var result = _summatorPage.Calculator("3", "3");

            Assert.That(result, Is.EqualTo("6"));
        }
        [Test]
        public void TestWithInvalidValid_Data()
        {
            var result = _summatorPage.Calculator("abv", "3");

            Assert.That(result, Is.EqualTo("error"));
        }

    }

}
