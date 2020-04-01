using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace HOW.Selenium.WebApp.Framework.Pages
{
    public class RequestPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl($"{Driver.BaseUrl}/Request");
        }

        public static bool IsAt
        {
            get
            {
                var header = Driver.Instance.FindElement(By.TagName("h1"));

                return (header.Text == "Request");
            }
        }

        public static void SubmitRequest(string title, string body)
        {
            try
            {
                Driver.Instance.FindElement(By.Id("Title")).SendKeys(title);
                Driver.Instance.FindElement(By.Id("Body")).SendKeys(body);

                new WebDriverWait(Driver.Instance, new TimeSpan(0, 0, 5))
                    .Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementToBeClickable(By.Id("Create_Request"))).Click();
            }
            catch (WebDriverTimeoutException wdex)
            {
                Helper.TakeScreenShot(Driver.Instance, nameof(SubmitRequest));
                throw new ApplicationException($"Timeout reached when trying to click Create_Request button", wdex);
            }
        }
    }
}
