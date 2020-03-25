using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace HOW.Selenium.WebApp.Framework
{
    public class Driver
    {
        public static IWebDriver Instance { get; set; }

        public static string BaseUrl { get; set; }

        public static void Initialize(
            string driverType,
            bool isPrivateMode = true,
            bool isHeadless = false)
        {
            switch (driverType)
            {
                case "Chrome":
                    //chrome
                    var svc = ChromeDriverService.CreateDefaultService();
                    var chromeOptions = new ChromeOptions();
                    if (isPrivateMode)
                        chromeOptions.AddArgument("incognito");

                    if (isHeadless)
                        chromeOptions.AddArgument("headless");

                    Instance = new ChromeDriver(svc, chromeOptions);
                    break;

                case "Firefox":
                    //firefox
                    var geckoSvc = FirefoxDriverService.CreateDefaultService();
                    var geckoOptions = new FirefoxOptions
                    {
                        AcceptInsecureCertificates = true
                    };

                    if (isPrivateMode)
                        geckoOptions.AddArgument("-private");

                    if (isHeadless)
                        geckoOptions.AddArgument("-headless");

                    Instance = new FirefoxDriver(geckoSvc, geckoOptions);
                    break;

                default:
                    Instance = new ChromeDriver();
                    break;
            }

            Instance.Manage().Window.Maximize();
            Instance.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        public static void Quit()
        {
            Instance.Quit();
        }
    }
}
