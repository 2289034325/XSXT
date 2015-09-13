using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
{
    public class TCangkuKucunMXMap : EntityTypeConfiguration<TCangkuKucunMX>
    {
        public TCangkuKucunMXMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TCangkuKucunMX");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.kucunid).HasColumnName("kucunid");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");
            this.Property(t => t.jinhuoriqi).HasColumnName("jinhuoriqi");

            // Relationships
            this.HasRequired(t => t.TCangkuKucun)
                .WithMany(t => t.TCangkuKucunMXes)
                .HasForeignKey(d => d.kucunid);
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TCangkuKucunMXes)
                .HasForeignKey(d => d.tiaomaid);

        }
    }
}
