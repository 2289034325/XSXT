


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class VFDKCMap : EntityTypeConfiguration<VFDKC>
    {
        public VFDKCMap()
        {
            // Primary Key

            this.HasKey(t => new { t.id, t.fendianid, t.shangbaoshijian });


            // Properties

            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            this.Property(t => t.fendianid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);


            // Table & Column Mappings

            this.ToTable("VFDKC");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.fendianid).HasColumnName("fendianid");

            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

        }
    }
}
