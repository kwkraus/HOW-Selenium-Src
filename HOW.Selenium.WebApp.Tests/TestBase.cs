using HOW.Selenium.WebApp.Framework;
using Microsoft.Extensions.Configuration;
using System;

namespace HOW.Selenium.WebApp.Tests
{
    public abstract class TestBase : IDisposable
    {
        protected TestBase()
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("settings.json")
                .Build();

            Driver.Initialize(
                config["targetBrowser"],
                bool.Parse(config["isPrivateMode"]), //bool.Parse(ConfigurationSettings.AppSettings["isPrivateMode"].ToString()),
                bool.Parse(config["isHeadless"])); //bool.Parse(ConfigurationSettings.AppSettings["isHeadless"].ToString()));

            Driver.BaseUrl = "https://localhost:5001"; // ConfigurationSettings.AppSettings["BaseUrl"].ToString();
        }

        public void Dispose()
        {
            Driver.Quit();
        }
    }
}
