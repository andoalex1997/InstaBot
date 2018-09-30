using System;
using System.Collections.Generic;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace InstaBot.Core.PageModels
{
    public class BasePage
    {
        public static IWebDriver Driver = new ChromeDriver(@"D:\src\InstaBot\");
    }
}
