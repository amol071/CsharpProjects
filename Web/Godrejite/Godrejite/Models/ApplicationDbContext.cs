using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Godrejite.Models
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext() : base("GodrejiteConnection")
        {
        }

        public DbSet<User> Users { get; set; }
    }
}