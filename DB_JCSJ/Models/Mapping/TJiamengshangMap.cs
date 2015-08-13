using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TJiamengshangMap : EntityTypeConfiguration<TJiamengshang>
    {
        public TJiamengshangMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.mingcheng)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.lianxiren)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.dianhua)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TJiamengshang");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.mingcheng).HasColumnName("mingcheng");
            this.Property(t => t.zhanghaoshu).HasColumnName("zhanghaoshu");
            this.Property(t => t.tiaomashu).HasColumnName("tiaomashu");
            this.Property(t => t.huiyuanshu).HasColumnName("huiyuanshu");
            this.Property(t => t.fendianshu).HasColumnName("fendianshu");
            this.Property(t => t.kuanhaoshu).HasColumnName("kuanhaoshu");
            this.Property(t => t.cangkushu).HasColumnName("cangkushu");
            this.Property(t => t.gongyingshangshu).HasColumnName("gongyingshangshu");
            this.Property(t => t.xsjilushu).HasColumnName("xsjilushu");
            this.Property(t => t.jchjilushu).HasColumnName("jchjilushu");
            this.Property(t => t.kcjilushu).HasColumnName("kcjilushu");
            this.Property(t => t.shoucifufei).HasColumnName("shoucifufei");
            this.Property(t => t.xufeidanjia).HasColumnName("xufeidanjia");
            this.Property(t => t.jiezhiriqi).HasColumnName("jiezhiriqi");
            this.Property(t => t.lianxiren).HasColumnName("lianxiren");
            this.Property(t => t.dianhua).HasColumnName("dianhua");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TJiamengshangs)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
