using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using InstaBot.Core.PageModels;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace InstaBot.Core
{
    public static class WebDriverExtentions
    {
        /// <summary>
        /// Extention method with timeout
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <param name="by">Search param</param>
        /// <param name="timeoutInSeconds">Timeout</param>
        /// <returns>Web Element</returns>
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        /// <summary>
        /// Extention method with timeout
        /// </summary>
        /// <param name="driver">Web driver</param>
        /// <param name="by">Search param</param>
        /// <param name="timeoutInSeconds">Timeout</param>
        /// <returns>Web Element</returns>
        public static ReadOnlyCollection<IWebElement> FindElements(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => (drv.FindElements(by).Count > 0) ? drv.FindElements(by) : null);
            }
            return driver.FindElements(by);
        }

    }
}
