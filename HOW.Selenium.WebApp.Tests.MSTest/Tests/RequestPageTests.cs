using HOW.Selenium.WebApp.Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HOW.Selenium.WebApp.Tests.MSTest.Tests
{
    [TestClass]
    public class RequestPageTests : TestBase
    {
        [TestMethod]
        public void RequestPage_Link_Visible_When_Logged_In()
        {
            HomePage.GoTo();

            var linkText = "New Request";

            Assert.IsFalse(HomePage.IsNavLinkPresent(linkText),$"Link with name={linkText} was present when it shouldn't be.");

            LoginPage.GoTo();
            LoginPage.Login("a@a.com", "Pass@word1");

            Assert.IsTrue(HomePage.IsNavLinkPresent(linkText), $"Link with name={linkText} was NOT present when it should be.");
        }

        [TestMethod]
        public void RequestPage_Enter_New_Request_Form()
        {
            RequestPage.GoTo();

            //should redirect to login page
            LoginPage.Login("a@a.com", "Pass@word1");

            RequestPage.SubmitRequest("First Request", "My body of proof");

            Assert.IsTrue(HomePage.IsAt, "failed to redirect to home page");
        }
    }
}
