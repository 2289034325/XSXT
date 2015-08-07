using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_CK.Models.Mapping
{
    public class VKucunMap : EntityTypeConfiguration<VKucun>
    {
        public VKucunMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.shuliang });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.shuliang)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("VKucun");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.shuliang).HasColumnName("shuliang");
        }
    }
}
