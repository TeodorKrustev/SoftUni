using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

// Create a new instance of Chrome Driver
WebDriver driver = new ChromeDriver();

// Navigate to Wikipedia home page
driver.Navigate().GoToUrl("https://www.wikipedia.org/");

// Print main page title
Console.WriteLine("Main page title is: " + driver.Title);

// Find the search box
var searchInput = driver.FindElement(By.Id("searchInput"));

// Click on search box
searchInput.Click();

// Type into the search box and click Enter
searchInput.SendKeys("Quality assurance" + Keys.Enter);

// Get the page title
var currentPageTitle = driver.Title;

// Print the page title
Console.WriteLine("Quality assurance page title is: " + currentPageTitle);

// Check currentPage title
if (currentPageTitle == "Quality assurance - Wikipedia")
{
    Console.WriteLine("**** TEST PASS ****");
} else
{
    Console.WriteLine("**** TEST FAIL ****");
}

// Close the browser
driver.Quit();
