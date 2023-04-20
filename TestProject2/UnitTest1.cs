using NUnit.Framework;

namespace TestProject2
{
    public class Tests : BaseClass
    {
        [Test]
        public void Test1()
        {
           NavigateTo("https://betway.com/en/sports");
           ClickElement(".messagePromptButton.action");
           ClickElement("[collectionitem='favouriteLinks'] [collectionitem='soccer'] .categoryListItemWrapper");
           var titleElement = GetElement(".mainPanel.collection .titleWidgetLayout");
           Assert.True(titleElement.Text.Equals("Football"));
        }

        [Test]
        public void LoginTest()
        {

            //todo: create a method to login to the website
            NavigateTo("https://betway.com/en/sports?segment=uk");
            ClickElement(".messagePromptButton.action");
            InputValues("[placeholder='Username']", "ludo195");
            InputValues("[placeholder='Password']", "password1234$");
            ClickElement(".loginButton.button.submitButton");
        }

        [Test]
        public void PlaceBets()
        {
            //login();
            //Add an outcome to the betslip
            //open betslip
            //place bet
            //verify that the bet is placed and "bet placed successfully" message is displayed

        }
    }
}