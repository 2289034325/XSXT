using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
{
    public class TFendianJinchuhuoMap : EntityTypeConfiguration<TFendianJinchuhuo>
    {
        public TFendianJinchuhuoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TFendianJinchuhuo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fendianid).HasColumnName("fendianid");
            this.Property(t => t.oid).HasColumnName("oid");
            this.Property(t => t.fangxiang).HasColumnName("fangxiang");
            this.Property(t => t.laiyuanquxiang).HasColumnName("laiyuanquxiang");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.fashengshijian).HasColumnName("fashengshijian");
            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

            // Relationships
            this.HasRequired(t => t.TFendian)
                .WithMany(t => t.TFendianJinchuhuos)
                .HasForeignKey(d => d.fendianid);

        }
    }
}
