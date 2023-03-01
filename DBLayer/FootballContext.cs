using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Web;
using M3gogo.Models;

namespace M3gogo.DBLayer
{
    public class FootballContext: DbContext
    {
       
        public DbSet <Club> clubs { get; set; }

        public DbSet<AM> users { get; set; }

        public System.Data.Entity.DbSet<M3gogo.Models.Stadium> Stadia { get; set; }
    }

}