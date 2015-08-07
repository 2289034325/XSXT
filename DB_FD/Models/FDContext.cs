using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using DB_FD.Models.Mapping;

namespace DB_FD.Models
{
    public partial class FDContext : DbContext
    {
        static FDContext()
        {
            Database.SetInitializer<FDContext>(null);
        }

        public FDContext()
            : base("Name=FDContext")
        {
        }

        public DbSet<THuiyuan> THuiyuans { get; set; }
        public DbSet<THuiyuanZK> THuiyuanZKs { get; set; }
        public DbSet<TJinchuhuo> TJinchuhuos { get; set; }
        public DbSet<TJinchuMX> TJinchuMXes { get; set; }
        public DbSet<TKucunXZ> TKucunXZs { get; set; }
        public DbSet<TPandian> TPandians { get; set; }
        public DbSet<TTiaoma> TTiaomas { get; set; }
        public DbSet<TUser> TUsers { get; set; }
        public DbSet<TXiaoshou> TXiaoshous { get; set; }
        public DbSet<VKucun> VKucuns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new THuiyuanMap());
            modelBuilder.Configurations.Add(new THuiyuanZKMap());
            modelBuilder.Configurations.Add(new TJinchuhuoMap());
            modelBuilder.Configurations.Add(new TJinchuMXMap());
            modelBuilder.Configurations.Add(new TKucunXZMap());
            modelBuilder.Configurations.Add(new TPandianMap());
            modelBuilder.Configurations.Add(new TTiaomaMap());
            modelBuilder.Configurations.Add(new TUserMap());
            modelBuilder.Configurations.Add(new TXiaoshouMap());
            modelBuilder.Configurations.Add(new VKucunMap());
        }
    }
}
