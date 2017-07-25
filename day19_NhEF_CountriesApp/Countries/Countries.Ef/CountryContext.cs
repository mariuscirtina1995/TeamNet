using Countries.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Countries.Ef
{
    public class ContryContext : DbContext
    {
        public ContryContext(string connectionString) : base(connectionString)
        {
            //no lazy loadding
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ContryContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        //add class for mapping with EF
        public DbSet<Country> Country { get; set; }

    }
}
