using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
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

            // Table & Column Mappings
            this.ToTable("TXiaoshou");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fendianid).HasColumnName("fendianid");
            this.Property(t => t.oid).HasColumnName("oid");
            this.Property(t => t.xiaoshoushijian).HasColumnName("xiaoshoushijian");
            this.Property(t => t.xiaoshouyuan).HasColumnName("xiaoshouyuan");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.huiyuanid).HasColumnName("huiyuanid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");
            this.Property(t => t.danjia).HasColumnName("danjia");
            this.Property(t => t.zhekou).HasColumnName("zhekou");
            this.Property(t => t.moling).HasColumnName("moling");
            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

            // Relationships
            this.HasRequired(t => t.TFendian)
                .WithMany(t => t.TXiaoshous)
                .HasForeignKey(d => d.fendianid);
            this.HasOptional(t => t.THuiyuan)
                .WithMany(t => t.TXiaoshous)
                .HasForeignKey(d => d.huiyuanid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TXiaoshous)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
