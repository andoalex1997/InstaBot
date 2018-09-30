using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InstaBot.Core.PageModels
{
    public sealed class LogInPage: BasePage
    {
        public IWebElement UsernameTb { get; }

        public IWebElement PassWordTb { get; }

        public IWebElement LogInBtn { get; }

        public LogInPage()
        {
            UsernameTb = Driver.FindElement(By.Name("username"), 10);
            PassWordTb = Driver.FindElement(By.Name("password"), 10);
            LogInBtn = Driver.FindElement(By.CssSelector("button"), 10);
            //Driver.FindElement(By.Name("username")).SendKeys("andrran1k");
            //Driver.FindElement(By.Name("password")).SendKeys("And0A!ex");
            //Driver.FindElement(By.CssSelector("button")).Click();
        }

        public LogInPage(string username, string password): this()
        {
            UsernameTb.SendKeys(username);
            PassWordTb.SendKeys(password);
        }

        public void LogIn()
        {
            if (string.IsNullOrEmpty(UsernameTb.GetAttribute("value")) ||
                string.IsNullOrEmpty(PassWordTb.GetAttribute("value")))
            {
                throw new ArgumentException("Text box username or password are empty");
            }

            LogInBtn.Click();
        }
    }
}
