using OpenQA.Selenium;

namespace HOW.Selenium.WebApp.Framework.Pages
{
    public class LoginPage
    {
        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl($"{Driver.BaseUrl}/Identity/Account/Login");
        }

        public static bool IsAt
        {
            get
            {
                var header = Driver.Instance.FindElement(By.TagName("h1"));

                return (header.Text == "Log in");
            }
        }

        public static void Login(string userName, string password)
        {
            var loginElement = Driver.Instance.FindElement(By.Id("Input_Email"));
            loginElement.Clear();
            loginElement.SendKeys(userName);

            Driver.Instance.FindElement(By.Id("Input_Password")).SendKeys(password);

            loginElement.Submit();
        }
    }
}
