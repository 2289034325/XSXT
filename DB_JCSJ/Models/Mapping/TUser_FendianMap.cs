using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TUser_FendianMap : EntityTypeConfiguration<TUser_Fendian>
    {
        public TUser_FendianMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TUser_Fendian");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.yonghuid).HasColumnName("yonghuid");
            this.Property(t => t.fendianid).HasColumnName("fendianid");

            // Relationships
            this.HasRequired(t => t.TFendian)
                .WithMany(t => t.TUser_Fendian)
                .HasForeignKey(d => d.fendianid);
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TUser_Fendian)
                .HasForeignKey(d => d.yonghuid);

        }
    }
}
