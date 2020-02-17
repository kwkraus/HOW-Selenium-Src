using HOW.Selenium.WebApp.Framework;
using Microsoft.Extensions.Configuration;
using System;

namespace HOW.Selenium.WebApp.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            Driver.Initialize(
                "Chrome", //ConfigurationSettings.AppSettings["TargetBrowser"].ToString(),
                true, //bool.Parse(ConfigurationSettings.AppSettings["isPrivateMode"].ToString()),
                false); //bool.Parse(ConfigurationSettings.AppSettings["isHeadless"].ToString()));

            Driver.BaseUrl = "https://localhost:5001"; // ConfigurationSettings.AppSettings["BaseUrl"].ToString();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
