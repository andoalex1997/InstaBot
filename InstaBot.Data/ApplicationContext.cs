using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Data
{
    public class ApplicationContext: DbContext
    {
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<IbProfile> IbProfiles { get; set; }
        public DbSet<Task> Tasks { get; set; }
        //public DbSet<ProfileFollowers> ProfileFollowers { get; set; }
    }
}
