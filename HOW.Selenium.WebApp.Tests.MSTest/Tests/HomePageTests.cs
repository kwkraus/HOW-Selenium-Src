using HOW.Selenium.WebApp.Framework.Pages;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HOW.Selenium.WebApp.Tests.MSTest.Tests
{
    [TestClass]
    public class HomePageTests : TestBase
    {
        [TestMethod]
        public void HomePage_Navigate_To_Page()
        {
            HomePage.GoTo();

            Assert.IsTrue(HomePage.IsAt);
        }
    }
}
