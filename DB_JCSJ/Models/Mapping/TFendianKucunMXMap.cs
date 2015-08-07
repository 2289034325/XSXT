using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TFendianKucunMXMap : EntityTypeConfiguration<TFendianKucunMX>
    {
        public TFendianKucunMXMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TFendianKucunMX");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.kucunid).HasColumnName("kucunid");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");

            // Relationships
            this.HasRequired(t => t.TFendianKucun)
                .WithMany(t => t.TFendianKucunMXes)
                .HasForeignKey(d => d.kucunid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TFendianKucunMXes)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
