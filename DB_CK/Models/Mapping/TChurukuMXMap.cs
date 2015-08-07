using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_CK.Models.Mapping
{
    public class TChurukuMXMap : EntityTypeConfiguration<TChurukuMX>
    {
        public TChurukuMXMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TChurukuMX");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.churukuid).HasColumnName("churukuid");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");

            // Relationships
            this.HasRequired(t => t.TChuruku)
                .WithMany(t => t.TChurukuMXes)
                .HasForeignKey(d => d.churukuid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TChurukuMXes)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
