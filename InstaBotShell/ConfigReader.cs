using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using Newtonsoft.Json;

namespace InstaBotShell
{
    public class ConfigReader
    {

        public Config Read()
        {

            using (FileStream fs = File.Open(AppDomain.CurrentDomain.BaseDirectory + @"\config.json", FileMode.Open))
            {
                return JsonConvert.DeserializeObject<Config>(fs.ToString());
            }
           
        }
    }
}
