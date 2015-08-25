using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class TVersionMap : EntityTypeConfiguration<TVersion>
    {
        public TVersionMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TVersion");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.banben).HasColumnName("banben");
            this.Property(t => t.shengjishijian).HasColumnName("shengjishijian");
        }
    }
}
