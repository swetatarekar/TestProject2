using LanguageDetection;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V108.Browser;

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
            //todo: create a reusable method which accepts URL as a parameter and now call that method here and pass the URL from here.
           NavigateTo("https://betway.com/en/sports");
           
            _driver.FindElement(By.CssSelector(".messagePromptButton.action")).Click();

            //go to sports page
            
            var element = _driver.FindElement(By.CssSelector("[collectionitem='favouriteLinks'] [collectionitem='soccer'] .categoryListItemWrapper"));
            element.Click();

            //verify betway is displayed
            
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


        [Test]
        public void LoginTest()
        {
            NavigateTo("https://betway.com/en/sports?segment=uk");

            //todo: make a reusable method for click 
            //ClickElement("selector");
            _driver.FindElement(By.CssSelector(".messagePromptButton.action")).Click();

            InputValues("[placeholder='Username']", "ludo195");
            InputValues("[placeholder='Password']", "password1234$");


            _driver.FindElement(By.CssSelector(".loginButton.button.submitButton")).Click();
            
        }

        [Test]
        public void testtest()
        {
            LanguageDetector ld = new LanguageDetector();
            ld.AddLanguages("lv", "lt", "en", "hi", "nl", "es", "fr");
            //ld.AddLanguages();
            var svdc = ld.Detect("nous sommes ici à la plage ce matin"); //french
            var sdgbvdc = ld.Detect("हैलो हम यहाँ समुद्र तट पर हैं hello may be lets see and and "); //hindi
            var sdFVDgbvdc = ld.Detect("HELLO HERE हैलो हम यहाँ समुद्र तट पर हैं hello may be lets see and here we r still typing in english lets what it has to say now. hopefully it geta 2 languages"); //hindi
            var sdgbCDvdc = ld.DetectAll("हैलो हम यहाँ समुद्र तट पर हैं hello may be lets see"); //hindi
            var sdgbCVFCDvdc = ld.DetectAll("HELLO HERE हैलो हम यहाँ समुद्र तट पर हैं hello may be lets see and here we r still typing in english lets what it has to say now. hopefully it geta 2 languages"); //hindi
            var svnfhgdc = ld.Detect("hola estamos aqui en la playa");//spanish
            var sfhnvdc = ld.Detect("we zijn hier vanmorgen op het strand");//dutch
            var svnfhdc = ld.Detect("bisherigen");
        }

        [Test]
        public void CheckLanguage()
        {
            // ChromeOptions options = new ChromeOptions();
            // options.AddArguments("-lang=fr-ca"); //set the browser language
            //
            // _driver = new ChromeDriver(options);

            // _driver.Navigate().GoToUrl("https://stackoverflow.com");
            _driver.Navigate().GoToUrl("https://info.valueactive.eu/MobileHelp/en/default.htm?cshid=1865950300&moduleid=18659&clientid=50300&gameid=assassinMoonDesktop");

            LanguageDetector ld = new LanguageDetector();
            ld.AddLanguages("lv", "lt", "en", "hi", "nl", "es", "fr", "en");


            var lsvfdv = _driver.FindElement(By.TagName("body"));


            var alltext  = _driver.FindElement(By.CssSelector("responsive-topic")).Text;
            Console.WriteLine(alltext);
            var language = ld.Detect(alltext);
            Console.WriteLine(language);
        }


        [TearDown]
        public void TearDown()
        {
            _driver.Close();
            _driver.Quit();
        }
    }
}