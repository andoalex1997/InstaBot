using System;
using System.Collections.Generic;
using System.Text;
using InstaBot.Core.Models;

namespace InstaBot.Core
{
    public sealed class InstaProfile
    {
        public string ProfileName { get; private set; }

        public List<InstaPost> Posts { get; set; }

        public List<InstaProfile> Followers { get; set; }

        public List<InstaProfile> Following { get; set; }

    }
}
