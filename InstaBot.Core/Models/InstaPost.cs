using System;
using InstaBot.Core.PageModels;
using OpenQA.Selenium;
using Resources = InstaBot.Core.Properties.Resources;

namespace InstaBot.Core.Models
{
    public class InstaPost
    {
        public ProfilePage Profile { get; set; }

        public int LikesCount { get; set; }

        public DateTime DataCreate { get; set; } 

        public bool LikedByMe { get; set; }

        public IWebElement PostWebElement { get; set; }

        public IWebElement LikeBtn { get; set; }

        private IWebDriver Driver { get; set; }

        public InstaPost(IWebDriver driver)
        {
            Driver = driver;
        }

        public InstaPost(IWebDriver driver, IWebElement post, ProfilePage profile) : this(driver)
        {
            Profile = profile;
            PostWebElement = post;
            LikesCount =
                int.Parse(Driver.FindElement(By.XPath(Resources.PostLikesCountXPath), Constants.TimedOut).Text);
            var date = Driver.FindElement(By.TagName("time"), Constants.TimedOut);
            DataCreate = DateTime.Parse(date.GetAttribute("datetime"));
            LikeBtn = Driver.FindElement(By.XPath(Resources.LikeButtonXPath), Constants.TimedOut);
            var likeBtnSPan = Driver.FindElement(By.XPath(Resources.LikeButtonXPathSpan), Constants.TimedOut);
            LikedByMe = likeBtnSPan.GetAttribute("aria-label").ToLower() != "нравится";
        }
    }
}
