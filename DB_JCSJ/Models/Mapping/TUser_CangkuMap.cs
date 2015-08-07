using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TUser_CangkuMap : EntityTypeConfiguration<TUser_Cangku>
    {
        public TUser_CangkuMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TUser_Cangku");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.yonghuid).HasColumnName("yonghuid");
            this.Property(t => t.cangkuid).HasColumnName("cangkuid");

            // Relationships
            this.HasRequired(t => t.TCangku)
                .WithMany(t => t.TUser_Cangku)
                .HasForeignKey(d => d.cangkuid);
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TUser_Cangku)
                .HasForeignKey(d => d.yonghuid);

        }
    }
}
