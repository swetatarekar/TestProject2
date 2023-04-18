using LanguageDetection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace TestProject2
{
    public class Tests
    {
        private IWebDriver _driver;

        [SetUp]
        public void Setup()
        {
            _driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
           NavigateTo("https://betway.com/en/sports");
           ClickElement(".messagePromptButton.action");
           ClickElement("[collectionitem='favouriteLinks'] [collectionitem='soccer'] .categoryListItemWrapper");
           var titleElement = WaitForElement(".mainPanel.collection .titleWidgetLayout");
           Assert.True(titleElement.Text.Equals("Football"));
        }


        [Test]
        public void LoginTest()
        {
            NavigateTo("https://betway.com/en/sports?segment=uk");
            ClickElement(".messagePromptButton.action");
            InputValues("[placeholder='Username']", "ludo195");
            InputValues("[placeholder='Password']", "password1234$");
            ClickElement(".loginButton.button.submitButton");
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }

        public void NavigateTo(string URL)
        {
            _driver.Navigate().GoToUrl(URL);
            _driver.Manage().Window.Maximize();
        }

        public void InputValues(string elementSelector, string inputValue)
        {
            _driver.FindElement(By.CssSelector(elementSelector)).Clear();
            _driver.FindElement(By.CssSelector(elementSelector)).SendKeys(inputValue);
        }

        public void ClickElement(string cssSelector, int seconds = 20)
        {
            WaitForElement(cssSelector, seconds).Click();
        }

        public IWebElement WaitForElement(string cssSelector, int seconds = 20)
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(seconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(cssSelector)));
        }
    }
}