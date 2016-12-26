using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TableSoccerStats.Database.EntityModel
{
    public class TssDbContext : DbContext
    {
        public TssDbContext() : base("TableSoccerStats") { }
        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players{ get; set; }
    }
}