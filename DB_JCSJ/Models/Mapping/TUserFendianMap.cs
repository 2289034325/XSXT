using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TUserFendianMap : EntityTypeConfiguration<TUserFendian>
    {
        public TUserFendianMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TUserFendian");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.userid).HasColumnName("userid");
            this.Property(t => t.fendianid).HasColumnName("fendianid");

            // Relationships
            this.HasRequired(t => t.TFendian)
                .WithMany(t => t.TUserFendians)
                .HasForeignKey(d => d.fendianid);
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TUserFendians)
                .HasForeignKey(d => d.userid);

        }
    }
}
