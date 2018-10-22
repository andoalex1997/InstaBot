using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using InstaBot.Core;
using InstaBot.Core.Models;
using InstaBot.Core.PageModels;
using InstaBot.Data;


namespace InstaBotShell
{
    class Program
    {
        static void Main(string[] args)
        {
            //Исходный данные 
            var username = "";
            var password = "";
            string soureProfile = "";

            //Вход в инсту
            CookiesManager.ReadCookies();
            if (CookiesManager.Token == null || CookiesManager.SessonId == null)
            {
                var startPage = new LogInPage();
                startPage.UsernameTb.SendKeys(username);
                startPage.PassWordTb.SendKeys(password);
                startPage.LogInBtn.Click();
                CookiesManager.WriteCookies(BasePage.Driver);
            }
            else
            {
                var startPage = new HomePage();
                CookiesManager.LoadCookies(BasePage.Driver);
                startPage.ReloadPage();
            }

            //Запись в базу 
            var db = new ApplicationContext();
            db.IbProfiles.Add(new IbProfile {ProfileId = 1 ,Username = username, ProfileStatusId = ProfileStatus.Me});


            //CookiesManager.ReadCookies();
            //if (CookiesManager.Token == null || CookiesManager.SessonId == null)
            //{
            //    var startPage = new LogInPage();
            //    startPage.UsernameTb.SendKeys(user.Username);
            //    startPage.PassWordTb.SendKeys(user.Password);
            //    startPage.LogInBtn.Click();
            //    CookiesManager.WriteCookies(BasePage.Driver);
            //}
            //else
            //{
            //    var startPage = new HomePage();
            //    CookiesManager.LoadCookies(BasePage.Driver);
            //    startPage.ReloadPage();
            //}

            //var profile = new ProfilePage(user);
            //profile.GetPosts();

        }
    }
}
