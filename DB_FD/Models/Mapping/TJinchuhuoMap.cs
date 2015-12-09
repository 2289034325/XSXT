using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class TJinchuhuoMap : EntityTypeConfiguration<TJinchuhuo>
    {
        public TJinchuhuoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.picima)
                .HasMaxLength(8);

            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TJinchuhuo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fangxiang).HasColumnName("fangxiang");
            this.Property(t => t.laiyuanquxiang).HasColumnName("laiyuanquxiang");
            this.Property(t => t.picima).HasColumnName("picima");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.queding).HasColumnName("queding");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");
            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

            // Relationships
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TJinchuhuos)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
