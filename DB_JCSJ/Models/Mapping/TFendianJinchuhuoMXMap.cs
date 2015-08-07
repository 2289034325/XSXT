using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TFendianJinchuhuoMXMap : EntityTypeConfiguration<TFendianJinchuhuoMX>
    {
        public TFendianJinchuhuoMXMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TFendianJinchuhuoMX");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jinchuhuoid).HasColumnName("jinchuhuoid");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");

            // Relationships
            this.HasRequired(t => t.TFendianJinchuhuo)
                .WithMany(t => t.TFendianJinchuhuoMXes)
                .HasForeignKey(d => d.jinchuhuoid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TFendianJinchuhuoMXes)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
