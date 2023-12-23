using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UcakBiletSatisOtomasyonu.Mapping;

namespace UcakBiletSatisOtomasyonu
{
    public class Context:DbContext
    {
        public Context()
        {
            Database.Connection.ConnectionString = @"server=ADEMCOSKUN\SQLEXPRESS;database=UcakDb;Trusted_Connection=True";
            //Database.Connection.ConnectionString = @"server=(localdb)\MSSQLLocalDB;database=UcakDb;Trusted_Connection=True;";
            Database.SetInitializer<Context>(new DropCreateDatabaseIfModelChanges<Context>());
        }
        public DbSet<SeferBilgi> SeferBilgileri { get; set; }
        public DbSet<SaatFarki> SaatFarklari { get; set; }
        public DbSet<SeferSaatleri> SeferSaatleri { get; set; }
        public DbSet<OdemeBilgi> OdemeBilgileri { get; set; }
        public DbSet<Musteri> Musteriler { get; set; }
        public DbSet<Yemek> Yemekler { get; set; }
        public DbSet<Ulke> Ulkeler { get; set; }
        public DbSet<KartBilgileri> KartBilgileri { get; set; }
        public DbSet<Sinif> Siniflar { get; set; }
        public DbSet<UcusBilgi> UcusBilgileri { get; set; }
        public DbSet<Ucak> Ucaklar { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new KartBilgileriMapping());
            modelBuilder.Configurations.Add(new OdemeBilgiMapping());


            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
