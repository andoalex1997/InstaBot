using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using InstaBot.Core.Models;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Resources = InstaBot.Core.Properties.Resources;

namespace InstaBot.Core.PageModels
{
    public class ProfilePage: BasePage
    {
        protected readonly string PageUrl;

        public IWebElement FollowersBtn { get; set; }

        public IWebElement FollowingBtn { get; set; }

        public ProfilePage(string username)
        {
            PageUrl = Constants.InstUrl + username;
            Driver.Navigate().GoToUrl(PageUrl);

            var links = Driver.FindElements(By.TagName("a"), Constants.TimedOut);
            FollowersBtn = links.ToList().Find(x => x.Text.ToLower().Contains("подписчик"));
            FollowingBtn = links.ToList().Find(x => x.Text.ToLower().Contains("подписки"));
            
        }

        public void ReloadPage()
        {
            Driver.Navigate().GoToUrl(PageUrl);
        }

        public void GetFollowers()
        {
            FollowersBtn.Click();
            var follovers = Driver.FindElements(By.ClassName(Resources.FollowersCssClass), Constants.TimedOut);
        }

        public void GetPosts()
        {
            //TODO: Удалить эту строку т.к. она для отладки
            Driver.Navigate().GoToUrl(@"https://www.instagram.com/_andrranik/");

            IJavaScriptExecutor js = (IJavaScriptExecutor)Driver;
            int postsBeforeUpdate = 0;
            var posts = Driver.FindElements(By.ClassName(Resources.PostsCssClass), 100);
            while (posts.Count != postsBeforeUpdate)
            {
                js.ExecuteScript(Resources.ScrollWindowScript);
                postsBeforeUpdate = posts.Count;

                //waiting while all posts load
                Thread.Sleep(5000);
                posts = Driver.FindElements(By.ClassName(Resources.PostsCssClass), 100);
                
            }

            var instaPosts = new List<InstaPost>();
            foreach (var post in posts)
            {
                post.Click();
                instaPosts.Add(new InstaPost(Driver, post, this));
                Driver.FindElement(By.XPath(Resources.ClosePostPageButtonXPath)).Click();

            }
        }

    }
}
