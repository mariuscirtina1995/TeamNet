using ErpDatabase.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace ErpDatabase.Ef
{
    public class ErpContext : DbContext
    {
        public ErpContext(string connectionString):base(connectionString)
        {
            //no lazy loadding
            Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ErpContext>(null);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }

        //add class for mapping with EF
        public DbSet<Client> Client { get; set; }

        public DbSet<Categorie> Categorie { get; set; }

        public DbSet<Factura> Factura { get; set; }

        public DbSet<LinieFactura> LinieFactura { get; set; }

        public DbSet<Produs> Produs { get; set; }

        public DbSet<LinieComanda> LinieComanda { get; set; }

        public DbSet<Comanda> Comanda { get; set; }

    }
}
