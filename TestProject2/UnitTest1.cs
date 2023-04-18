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
           var titleElement = _driver.FindElement(By.CssSelector(".mainPanel.collection .titleWidgetLayout"));
           Assert.True(titleElement.Text.Equals("Football"));
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

        public void ClickElement(string cssSelector)
        {
            _driver.FindElement(By.CssSelector(cssSelector)).Click();
        }

        [Test]
        public void LoginTest()
        {
            NavigateTo("https://betway.com/en/sports?segment=uk");

            //todo: make a reusable method webdriver wait and use it instead of  _driver.FindElement
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement cookiesElement = wait.Until(ExpectedConditions.ElementIsVisible(By.CssSelector(".messagePromptButton.action")));
            cookiesElement.Click();

            InputValues("[placeholder='Username']", "ludo195");
            InputValues("[placeholder='Password']", "password1234$");


            _driver.FindElement(By.CssSelector(".loginButton.button.submitButton")).Click();
            
        }

        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}