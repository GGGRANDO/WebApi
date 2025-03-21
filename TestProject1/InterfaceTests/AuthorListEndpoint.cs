using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;

namespace TestProject1.IntegrationTests
{
    public class AuthorListEndpoint
    {
        [Fact]
        public void TestSwaggerUIListAuthorsEndpoint()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl("https://localhost:5001/swagger");

                var expandButton = driver.FindElement(By.CssSelector("button[aria-expanded='false']"));
                expandButton.Click();

                var executeButton = driver.FindElement(By.CssSelector(".execute-wrapper .btn.execute"));
                executeButton.Click();

                var responseContainer = driver.FindElement(By.CssSelector(".response .response-body pre"));
                Assert.NotNull(responseContainer);
                var responseText = responseContainer.Text;
                Assert.Contains("200 OK", responseText);

                driver.Quit();
            }
        }
    }
}
