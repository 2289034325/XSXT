using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class TXiaoshouMap : EntityTypeConfiguration<TXiaoshou>
    {
        public TXiaoshouMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.xiaoshouyuan)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TXiaoshou");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.xiaoshoushijian).HasColumnName("xiaoshoushijian");
            this.Property(t => t.xiaoshouyuan).HasColumnName("xiaoshouyuan");
            this.Property(t => t.huiyuanid).HasColumnName("huiyuanid");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");
            this.Property(t => t.jinjia).HasColumnName("jinjia");
            this.Property(t => t.shoujia).HasColumnName("shoujia");
            this.Property(t => t.zhekou).HasColumnName("zhekou");
            this.Property(t => t.moling).HasColumnName("moling");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");
            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

            // Relationships
            this.HasOptional(t => t.THuiyuan)
                .WithMany(t => t.TXiaoshous)
                .HasForeignKey(d => d.huiyuanid);
            this.HasOptional(t => t.TTiaoma)
                .WithMany(t => t.TXiaoshous)
                .HasForeignKey(d => d.tiaomaid);
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TXiaoshous)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
