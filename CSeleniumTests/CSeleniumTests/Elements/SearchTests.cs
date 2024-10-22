using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;

namespace CSeleniumTests.Elements
{
    public class SearchTests
    {
        [Fact]
        public void GoogleSearchTest()
        {
            var options = new EdgeOptions();
            using (var driver = new EdgeDriver(options))
            {
                //navigate to google
                driver.Navigate().GoToUrl("https://www.google.com");

                //accept cookies if the appears
                try
                {
                    var acceptCookiesButton = driver.FindElement(By.Id("L2AGLb"));
                    acceptCookiesButton.Click();
                }
                catch (NoSuchDriverException ex)
                {
                    //if no button is found, continue
                    Debug.WriteLine(ex.Message);
                }

                //Find the search box, enter search term, submit
                var searchBox = driver.FindElement(By.Name("q"));
                searchBox.SendKeys("Selenium WebDriver");
                searchBox.Submit();

                //wait for results to appear
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(x => x.Title.Contains("Selenium WebDriver"));

                //verify the title contains the search term
                Assert.Contains("Selenium WebDriver", driver.Title);
            }
        }
    }
}