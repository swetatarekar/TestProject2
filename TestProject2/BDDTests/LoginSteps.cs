using TechTalk.SpecFlow;

namespace TestProject2.BDDTests
{
    [Binding]
    public class LoginSteps : BaseClass
    {
        [Given(@"I load the website")]
        public void GivenILoadTheWebsite()
        {
            NavigateTo("https://betway.com/en/sports?segment=uk");
            ClickElement(".messagePromptButton.action");
        }

        [When(@"I input username")]
        public void WhenIInputUsername()
        {
            InputValues("[placeholder='Username']", "ludo195");
        }

        [When(@"I input password")]
        public void WhenIInputPassword()
        {
            InputValues("[placeholder='Password']", "password1234$");
        }


        [Then(@"I verify the user is logged in")]
        public void ThenIVerifyTheUserIsLoggedIn()
        {
            ClickElement(".loginButton.button.submitButton");
        }
    }
}
