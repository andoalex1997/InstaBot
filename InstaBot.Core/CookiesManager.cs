using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using System.Text;
using OpenQA.Selenium;

namespace InstaBot.Core
{
    public static class CookiesManager
    {

        public static Cookie Token { get; private set; }

        public static Cookie SessonId { get; set; }

        public static void WriteCookies(IWebDriver driver)
        {
            Token = driver.Manage().Cookies.GetCookieNamed("csrftoken");
            SessonId = driver.Manage().Cookies.GetCookieNamed("sessionid");
            var jsonFormatter = new DataContractJsonSerializer(typeof(InstaCookies));

            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + @"\token.json"))
            {
                jsonFormatter.WriteObject(fs, (InstaCookies)Token);
            }

            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + @"\SessionId.json"))
            {
                jsonFormatter.WriteObject(fs, (InstaCookies)SessonId);
            }
        }

        public static void ReadCookies()
        {



            var jsonFormatter = new DataContractJsonSerializer(typeof(InstaCookies));

            try
            {
                using (FileStream fs = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"\token.json", FileMode.Open))
                {
                    
                    Token = (Cookie) ((InstaCookies)jsonFormatter.ReadObject(fs));
                }

                using (FileStream fs = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"\SessionId.json",
                    FileMode.Open))
                {
                    SessonId = (Cookie) ((InstaCookies)jsonFormatter.ReadObject(fs));
                }
            }
            catch (FileNotFoundException e)
            {}
        }

        public static void LoadCookies(IWebDriver driver)
        {
            if (Token == null || SessonId == null) throw new NullReferenceException();
            driver.Manage().Cookies.AddCookie(Token);
            driver.Manage().Cookies.AddCookie(SessonId);
        }
    }

    [Serializable]
    public class InstaCookies
    {
        private string CookieName { get; set; }
        private string CookieValue { get; set; }
        private string CookiePath { get; set; }
        private string CookieDomain { get; set; }
        private DateTime? CookieExpiry { get; set; }

        public InstaCookies(Cookie cookie)
        {
            CookieName = cookie.Name;
            CookieValue = cookie.Value;
            CookiePath = cookie.Path;
            CookieExpiry = cookie.Expiry;
        }

        public Cookie ToSeleniumCookie()
        {
            return new Cookie(CookieName, CookieValue, null, CookiePath, CookieExpiry);
        }

        public static implicit operator InstaCookies(Cookie cookie)
        {
            return new InstaCookies(cookie);
        }

        public static explicit operator Cookie(InstaCookies cookie)
        {
            return cookie.ToSeleniumCookie();
        }
    }
}
