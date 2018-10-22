using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Data
{

    public class Task
    {
        public int TaskId { get; set; }
        public int ProfileId { get; set; }
        public int LikeCount { get; set; }
        public LikingMode LikingModeId { get; set; }
    }
}
