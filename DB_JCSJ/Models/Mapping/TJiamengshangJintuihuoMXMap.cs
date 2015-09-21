using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TJiamengshangJintuihuoMXMap : EntityTypeConfiguration<TJiamengshangJintuihuoMX>
    {
        public TJiamengshangJintuihuoMXMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TJiamengshangJintuihuoMX");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jintuiid).HasColumnName("jintuiid");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.chengbenjia).HasColumnName("chengbenjia");
            this.Property(t => t.diaopaijia).HasColumnName("diaopaijia");
            this.Property(t => t.jinhuojia).HasColumnName("jinhuojia");
            this.Property(t => t.shuliang).HasColumnName("shuliang");

            // Relationships
            this.HasRequired(t => t.TJiamengshangJintuihuo)
                .WithMany(t => t.TJiamengshangJintuihuoMXes)
                .HasForeignKey(d => d.jintuiid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TJiamengshangJintuihuoMXes)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
