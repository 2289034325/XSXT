using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_CK.Models.Mapping
{
    public class TKucunXZMap : EntityTypeConfiguration<TKucunXZ>
    {
        public TKucunXZMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TKucunXZ");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");
            this.Property(t => t.shuliang).HasColumnName("shuliang");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiuggaishijian).HasColumnName("xiuggaishijian");

            // Relationships
            this.HasRequired(t => t.TTiaoma)
                .WithMany(t => t.TKucunXZs)
                .HasForeignKey(d => d.tiaomaid);
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TKucunXZs)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
