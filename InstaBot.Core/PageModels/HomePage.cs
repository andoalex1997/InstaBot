using System;
using System.Collections.Generic;
using System.Text;
using InstaBot.Core.PageModels;
using OpenQA.Selenium;

namespace InstaBot.Core
{
    public sealed class HomePage: BasePage
    {
        public IWebDriver Driver { get; private set; }

        private IWebElement usernameTextBox = 

        public HomePage(IWebDriver driver)
        {
            Driver = driver;
        }


    }
}
