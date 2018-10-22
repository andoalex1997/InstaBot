using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstaBot.Data;

namespace InstaBotShell
{
    [Serializable]
    public class Config
    {
        public List<string> ProfilesStr { get; set; }
        public LikingMode LikingModeId { get; set; }
    }


}
