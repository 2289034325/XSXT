using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class VDiquMap : EntityTypeConfiguration<VDiqu>
    {
        public VDiquMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.jibie });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.mingcheng)
                .HasMaxLength(10);

            this.Property(t => t.jibie)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.lujing)
                .HasMaxLength(100);

            this.Property(t => t.lsmingcheng)
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("VDiqu");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fid).HasColumnName("fid");
            this.Property(t => t.mingcheng).HasColumnName("mingcheng");
            this.Property(t => t.jibie).HasColumnName("jibie");
            this.Property(t => t.lujing).HasColumnName("lujing");
            this.Property(t => t.lsmingcheng).HasColumnName("lsmingcheng");
        }
    }
}
