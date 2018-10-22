using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstaBot.Data
{
    [Table("ib_profile")]
    public class IbProfile
    {
        [Column]
        [Key] public int ProfileId { get; set; }
        public string Username { get; set; }
        public ProfileStatus ProfileStatusId { get; set; }
    }
}
