using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class TPandianMap : EntityTypeConfiguration<TPandian>
    {
        public TPandianMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TPandian");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.pdshuliang).HasColumnName("pdshuliang");
            this.Property(t => t.kcshuliang).HasColumnName("kcshuliang");
            this.Property(t => t.charushijian).HasColumnName("charushijian");

            // Relationships
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TPandians)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
