using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TestProject1.InterfaceTests
{
    public class ResponsivenessTests
    {
        private readonly IWebDriver _driver;

        public ResponsivenessTests()
        {
            _driver = new ChromeDriver();
        }

        [Fact]
        public void SwaggerUIResponsiveness()
        {
            _driver.Navigate().GoToUrl("https://localhost:7054/swagger");

            _driver.Manage().Window.Size = new System.Drawing.Size(1920, 1080);
            Assert.True(_driver.FindElement(By.TagName("body")).Displayed);

            _driver.Manage().Window.Size = new System.Drawing.Size(768, 1024);
            Assert.True(_driver.FindElement(By.TagName("body")).Displayed);

            _driver.Manage().Window.Size = new System.Drawing.Size(375, 667);
            Assert.True(_driver.FindElement(By.TagName("body")).Displayed);
        }
    }
}
