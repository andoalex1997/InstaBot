using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI; 

namespace InstaBot.Core
{
    public class DriverPage
    {
        /// <summary>
        /// An object of Chrome Driver
        /// </summary>
        public IWebDriver Driver; 

        /// <summary>
        /// Constructor. Connect to the Chrome driver and open home page
        /// </summary>
        public DriverPage()
        {
            Driver = new ChromeDriver(@"D:\src\InstaBot\");
            Driver.Navigate().GoToUrl(@"https://www.instagram.com/accounts/login/?source=auth_switcher");
        }

        public void LetsGo()
        {
            Enter();



            var profileButton = Driver.FindElement(By.LinkText(@"/_andrranik/"));
            profileButton.Click();

            var followers = Driver.FindElements(By.ClassName("FPmhX"));
            var newFol = followers;
        }

        /// <summary>
        /// Authentificate on the Instagram
        /// </summary>
        public void Enter()
        {
            Driver.FindElement(By.Name("username")).SendKeys("andrran1k");
            Driver.FindElement(By.Name("password")).SendKeys("And0A!ex");
            Driver.FindElement(By.CssSelector("button")).Click();
            var token = Driver.Manage().Cookies.GetCookieNamed("csrftoken");
            var sessionid = Driver.Manage().Cookies.GetCookieNamed("sessionid");
        }

        /// <summary>
        /// Gets a list of current followers
        /// </summary>
        public void GetFollowers()
        {
            Driver.FindElement(By.PartialLinkText(@"/_andrranik/")).Click();
            Driver.FindElement(By.LinkText(@"/_andrranik/followers/")).Click();
            var followers = Driver.FindElements(By.ClassName("FPmhX"));
        }
    }
}
