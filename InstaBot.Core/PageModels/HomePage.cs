using System;
using System.Collections.Generic;
using System.Text;
using InstaBot.Core.PageModels;
using OpenQA.Selenium;

namespace InstaBot.Core
{
    public sealed class HomePage: BasePage
    {
        public IWebElement SearchTb { get; set; }

        public HomePage()
        {
            Driver.Navigate().GoToUrl(@"https://www.instagram.com/");
            SearchTb =  Driver.FindElement(By.TagName("input"), 10);
        }

        public void ReloadPage()
        {
            Driver.Navigate().GoToUrl(@"https://www.instagram.com/");
        }
    }
}
