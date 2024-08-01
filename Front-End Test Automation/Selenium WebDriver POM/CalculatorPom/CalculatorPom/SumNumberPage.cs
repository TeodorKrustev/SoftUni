using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorPom
{
    public class SumNumberPage
    {
        private readonly IWebDriver driver;

        public SumNumberPage(IWebDriver driver)
        {
            this.driver = driver;

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);
        }
        public const string PageUrl = "https://bade3093-3e85-45c1-a979-1ae1f88d0417-00-rlaubxudmkwy.spock.replit.dev/";

        public IWebElement FieldNum1 => driver.FindElement(By.XPath("//*[@id='number1']"));

        public IWebElement FieldNum2 => driver.FindElement(By.XPath("//*[@id='number2']"));

        public IWebElement CalcButton => driver.FindElement(By.XPath("//*[@id='calcButton']"));

        public IWebElement ResetButton => driver.FindElement(By.XPath("//*[@id='resetButton']"));

        public IWebElement ResultElement => driver.FindElement(By.XPath("//*[@id='result']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(PageUrl);
        }

        public string AddNumbers(string num1, string num2)
        {
            FieldNum1.SendKeys(num1);
            FieldNum2.SendKeys(num2);
            CalcButton.Click();

            return ResultElement.Text;
        }

        public void ResetForm()
        {
            ResetButton.Click();
        }

        public bool IsFormEmpty()
        {
            return FieldNum1.Text + FieldNum2.Text + ResultElement.Text == "";
        }
    }
}
