using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class TJinchuMXMap : EntityTypeConfiguration<TJinchuMX>
    {
        public TJinchuMXMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TJinchuMX");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jinchuid).HasColumnName("jinchuid");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");

            // Relationships
            this.HasRequired(t => t.TJinchuhuo)
                .WithMany(t => t.TJinchuMXes)
                .HasForeignKey(d => d.jinchuid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TJinchuMXes)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
