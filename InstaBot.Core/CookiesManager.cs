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
            var jsonFormatter = new DataContractJsonSerializer(typeof(Cookie));

            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + @"\token.json"))
            {
                jsonFormatter.WriteObject(fs, Token);
            }

            using (FileStream fs = File.Create(AppDomain.CurrentDomain.BaseDirectory + @"\SessionId.json"))
            {
                jsonFormatter.WriteObject(fs, SessonId);
            }
        }

        public static void ReadCookies()
        {

            var jsonFormatter = new DataContractJsonSerializer(typeof(Cookie));

            try
            {
                using (FileStream fs = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"\token.json", FileMode.Open))
                {
                    Token = (Cookie) jsonFormatter.ReadObject(fs);
                }

                using (FileStream fs = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"\SessionId.json",
                    FileMode.Open))
                {
                    SessonId = (Cookie) jsonFormatter.ReadObject(fs);
                }
            }
            catch (FileNotFoundException e)
            {}
        }
    }
}
