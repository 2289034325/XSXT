using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using CKGL.Models.Mapping;

namespace CKGL.Models
{
    public partial class JCSJContext : DbContext
    {
        static JCSJContext()
        {
            Database.SetInitializer<JCSJContext>(null);
        }

        public JCSJContext()
            : base("Name=JCSJContext")
        {
        }

        public DbSet<TCangku> TCangkus { get; set; }
        public DbSet<TCangkuFahuoFendian> TCangkuFahuoFendians { get; set; }
        public DbSet<TCangkuJinchuhuo> TCangkuJinchuhuos { get; set; }
        public DbSet<TCangkuJinchuhuoMX> TCangkuJinchuhuoMXes { get; set; }
        public DbSet<TCangkuKucun> TCangkuKucuns { get; set; }
        public DbSet<TCangkuKucunMX> TCangkuKucunMXes { get; set; }
        public DbSet<TDiqu> TDiqus { get; set; }
        public DbSet<TFendian> TFendians { get; set; }
        public DbSet<TFendianJinchuhuo> TFendianJinchuhuos { get; set; }
        public DbSet<TFendianJinchuhuoMX> TFendianJinchuhuoMXes { get; set; }
        public DbSet<TFendianKucun> TFendianKucuns { get; set; }
        public DbSet<TFendianKucunMX> TFendianKucunMXes { get; set; }
        public DbSet<TGongyingshang> TGongyingshangs { get; set; }
        public DbSet<THuiyuan> THuiyuans { get; set; }
        public DbSet<THuiyuanZK> THuiyuanZKs { get; set; }
        public DbSet<TJiamengshang> TJiamengshangs { get; set; }
        public DbSet<TJiamengshangGX> TJiamengshangGXes { get; set; }
        public DbSet<TJiamengshangGXSQ> TJiamengshangGXSQs { get; set; }
        public DbSet<TJiamengshangPinpai> TJiamengshangPinpais { get; set; }
        public DbSet<TKuanhao> TKuanhaos { get; set; }
        public DbSet<TTiaoma> TTiaomas { get; set; }
        public DbSet<TTiaomaJinjia> TTiaomaJinjias { get; set; }
        public DbSet<TUser> TUsers { get; set; }
        public DbSet<TXiaoshou> TXiaoshous { get; set; }
        public DbSet<VDiqu> VDiqus { get; set; }
        public DbSet<VTiaoma> VTiaomas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new TCangkuMap());
            modelBuilder.Configurations.Add(new TCangkuFahuoFendianMap());
            modelBuilder.Configurations.Add(new TCangkuJinchuhuoMap());
            modelBuilder.Configurations.Add(new TCangkuJinchuhuoMXMap());
            modelBuilder.Configurations.Add(new TCangkuKucunMap());
            modelBuilder.Configurations.Add(new TCangkuKucunMXMap());
            modelBuilder.Configurations.Add(new TDiquMap());
            modelBuilder.Configurations.Add(new TFendianMap());
            modelBuilder.Configurations.Add(new TFendianJinchuhuoMap());
            modelBuilder.Configurations.Add(new TFendianJinchuhuoMXMap());
            modelBuilder.Configurations.Add(new TFendianKucunMap());
            modelBuilder.Configurations.Add(new TFendianKucunMXMap());
            modelBuilder.Configurations.Add(new TGongyingshangMap());
            modelBuilder.Configurations.Add(new THuiyuanMap());
            modelBuilder.Configurations.Add(new THuiyuanZKMap());
            modelBuilder.Configurations.Add(new TJiamengshangMap());
            modelBuilder.Configurations.Add(new TJiamengshangGXMap());
            modelBuilder.Configurations.Add(new TJiamengshangGXSQMap());
            modelBuilder.Configurations.Add(new TJiamengshangPinpaiMap());
            modelBuilder.Configurations.Add(new TKuanhaoMap());
            modelBuilder.Configurations.Add(new TTiaomaMap());
            modelBuilder.Configurations.Add(new TTiaomaJinjiaMap());
            modelBuilder.Configurations.Add(new TUserMap());
            modelBuilder.Configurations.Add(new TXiaoshouMap());
            modelBuilder.Configurations.Add(new VDiquMap());
            modelBuilder.Configurations.Add(new VTiaomaMap());
        }
    }
}