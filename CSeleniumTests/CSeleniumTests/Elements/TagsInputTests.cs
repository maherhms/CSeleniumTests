using OpenQA.Selenium;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSeleniumTests.Elements
{
    public class TagsInputTests
    {
        [Fact]
        public void TagsInputBoxTest()
        {
            var options = new EdgeOptions();
            using (var driver = new EdgeDriver(options))
            {
                // Navigate to the tags input box app
                driver.Navigate().GoToUrl("https://qaplayground.dev/apps/tags-input-box/");

                // Find the input box
                var tagsInputBox = driver.FindElement(By.CssSelector("input[type='text'][spellcheck='false']"));

                // Enter a tag
                tagsInputBox.SendKeys("test tag");
                tagsInputBox.SendKeys(Keys.Enter);

                // Verify the tag appears
                var tags = driver.FindElements(By.XPath("/html/body/main/div/div[2]/ul/li[3]"));
                Assert.Contains(tags, t => t.Text == "test tag");
            }
        }

    }
}
