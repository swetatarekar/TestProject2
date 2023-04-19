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
    }
}