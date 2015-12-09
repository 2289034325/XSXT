


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class VCKKCMap : EntityTypeConfiguration<VCKKC>
    {
        public VCKKCMap()
        {
            // Primary Key

            this.HasKey(t => new { t.id, t.cangkuid, t.shangbaoshijian });


            // Properties

            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            this.Property(t => t.cangkuid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            // Table & Column Mappings

            this.ToTable("VCKKC");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.cangkuid).HasColumnName("cangkuid");

            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

        }
    }
}
