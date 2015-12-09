using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DB_CK.Models.Mapping;

namespace DB_CK.Models
{
    public partial class CKContext : DbContext
    {
        static CKContext()
        {
            Database.SetInitializer<CKContext>(null);
        }

        public CKContext()
            : base("Name=CKContext")
        {
        }

        public DbSet<TChuruku> TChurukus { get; set; }
        public DbSet<TChurukuMX> TChurukuMXes { get; set; }
        public DbSet<TJiamengshang> TJiamengshangs { get; set; }
        public DbSet<TKucunXZ> TKucunXZs { get; set; }
        public DbSet<TTiaoma> TTiaomas { get; set; }
        public DbSet<TUser> TUsers { get; set; }
        public DbSet<TVersion> TVersions { get; set; }
        public DbSet<VKucun> VKucuns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TChurukuMap());
            modelBuilder.Configurations.Add(new TChurukuMXMap());
            modelBuilder.Configurations.Add(new TJiamengshangMap());
            modelBuilder.Configurations.Add(new TKucunXZMap());
            modelBuilder.Configurations.Add(new TTiaomaMap());
            modelBuilder.Configurations.Add(new TUserMap());
            modelBuilder.Configurations.Add(new TVersionMap());
            modelBuilder.Configurations.Add(new VKucunMap());
        }
    }
}
