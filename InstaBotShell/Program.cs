using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using InstaBot.Core;


namespace InstaBotShell
{
    class Program
    {
        static void Main(string[] args)
        {          
            var page = new DriverPage();
            
            
            //page.LetsGo();
            page.Enter();
            //page.GetFollowers();
            Console.Read();
        }
    }
}
