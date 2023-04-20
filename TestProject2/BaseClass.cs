using NUnit.Framework;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using OpenQA.Selenium.Chrome;

namespace TestProject2
{
    public class BaseClass
    {
        private IWebDriver _driver = new ChromeDriver();

        [SetUp]
        public void Setup()
        {
            // _driver = new ChromeDriver();
        }

        public void NavigateTo(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();
        }

        public void InputValues(string elementSelector, string inputValue)
        {
            GetElement(elementSelector).Clear();
            GetElement(elementSelector).SendKeys(inputValue);
        }

        public void ClickElement(string cssSelector, int seconds = 20)
        {
            GetElement(cssSelector, seconds).Click();
        }

        public IWebElement GetElement(string cssSelector, int seconds = 20)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}
