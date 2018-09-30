using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;

namespace InstaBot.Core.PageModels
{
    public sealed class LogInPage: BasePage
    {
        public IWebDriver Driver { get; }

        public IWebElement UsernameTb { get; }

        public IWebElement PassWordTb { get; }

        public IWebElement LogInBtn { get; }


        public LogInPage(IWebDriver driver)
        {
            Driver = driver;
            UsernameTb = Driver.FindElement(By.Name("username"));
            PassWordTb = Driver.FindElement(By.Name("password"));
            LogInBtn = Driver.FindElement(By.CssSelector("button"));
            Driver.FindElement(By.Name("username")).SendKeys("andrran1k");
            Driver.FindElement(By.Name("password")).SendKeys("And0A!ex");
            Driver.FindElement(By.CssSelector("button")).Click();
        }

        public LogInPage(IWebDriver driver, string username, string password): this(driver)
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


        }
    }
}
