using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using InstaBot.Core;
using InstaBot.Core.PageModels;


namespace InstaBotShell
{
    class Program
    {
        static void Main(string[] args)
        {
            CookiesManager.ReadCookies();
            if (CookiesManager.Token == null || CookiesManager.SessonId == null)
            {
                var startPage = new LogInPage();
                startPage.UsernameTb.SendKeys("");
                startPage.PassWordTb.SendKeys("");
            }
            else
            {
                var startPage = new HomePage();
            }


        }
    }
}
