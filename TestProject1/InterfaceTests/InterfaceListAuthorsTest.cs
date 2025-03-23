using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using Xunit;

namespace TestProject1.InterfaceTests
{
    public class InterfaceListAuthorsTest
    {
        private readonly IWebDriver _driver;

        public InterfaceListAuthorsTest()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void ListAuthorsButtons()
        {
            _driver.Navigate().GoToUrl("https://localhost:7054/swagger");

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(30));

            var listAuthorsEndpoint = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector("[data-path='/api/Author/ListAuthors']")));
            listAuthorsEndpoint.Click();

            var tryItOutButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".try-out__btn")));
            tryItOutButton.Click();

            var executeButton = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.CssSelector(".btn.execute.opblock-control__btn")));
            executeButton.Click();

            Assert.True(true);
        }
    }
}
