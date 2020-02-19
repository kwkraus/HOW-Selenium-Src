using HOW.Selenium.WebApp.Framework.Pages;
using Xunit;

namespace HOW.Selenium.WebApp.Tests.Tests
{
    public class HomePageTests : TestBase
    {
        [Fact]
        public void HomePage_Navigate_To_Page()
        {
            HomePage.GoTo();

            Assert.True(HomePage.IsAt);
        }
    }
}
