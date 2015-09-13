using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
{
    public class TDiquMap : EntityTypeConfiguration<TDiqu>
    {
        public TDiquMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.mingcheng)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.lsmingcheng)
                .IsRequired()
                .HasMaxLength(100);

            // Table & Column Mappings
            this.ToTable("TDiqu");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.mingcheng).HasColumnName("mingcheng");
            this.Property(t => t.fid).HasColumnName("fid");
            this.Property(t => t.lsmingcheng).HasColumnName("lsmingcheng");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasOptional(t => t.TDiqu2)
                .WithMany(t => t.TDiqu1)
                .HasForeignKey(d => d.fid);

        }
    }
}
