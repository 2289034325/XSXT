using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TTiaomaJinjiaMap : EntityTypeConfiguration<TTiaomaJinjia>
    {
        public TTiaomaJinjiaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TTiaomaJinjia");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.tmid).HasColumnName("tmid");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.jinjia).HasColumnName("jinjia");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasRequired(t => t.TJiamengshang)
                .WithMany(t => t.TTiaomaJinjias)
                .HasForeignKey(d => d.jmsid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TTiaomaJinjias)
                .HasForeignKey(d => d.tmid);

        }
    }
}
