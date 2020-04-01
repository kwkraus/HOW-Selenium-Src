using OpenQA.Selenium;
using System;
using System.Threading;

namespace HOW.Selenium.WebApp.Framework.Pages
{
    public static class HomePage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl($"{Driver.BaseUrl}/");
        }

        public static bool IsAt
        {
            get
            {
                var header = Driver.Instance.FindElement(By.TagName("h1"));

                return (header.Text == "Welcome");
            }
        }

        public static bool IsNavLinkPresent(string linkText)
        {
            var links = Driver.Instance.FindElements(By.LinkText(linkText));

            return (links.Count > 0);
        }

        public static bool IsTextPresent(string textToLocate)
        {
            return Driver.Instance.PageSource.Contains(textToLocate);
        }

        public static bool IsTitleValid(string expectedPageTitle)
        {
            return (expectedPageTitle == Driver.Instance.Title);
        }

        public static void ClickPrivacyLink()
        {
            var linkText = "Privacy";

            try
            {
                Driver.Instance.FindElement(By.LinkText(linkText)).Click();
            }
            catch (NoSuchElementException nseex)
            {
                throw new ApplicationException($"Failed to find link with text={linkText}", nseex);
            }
        }

        public static void ClickAlertFromExecuteJS()
        {
            ((IJavaScriptExecutor)Driver.Instance).ExecuteScript(
                "alert('executed from selenium ExecuteScript');");

            IAlert alert = Driver.Instance.SwitchTo().Alert();
            Thread.Sleep(1500);
            alert.Accept();
        }
    }
}
