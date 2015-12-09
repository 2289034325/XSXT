


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TCangkuKucunMap : EntityTypeConfiguration<TCangkuKucun>
    {
        public TCangkuKucunMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            // Table & Column Mappings

            this.ToTable("TCangkuKucun");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.cangkuid).HasColumnName("cangkuid");

            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");


            // Relationships

            this.HasRequired(t => t.TCangku)

                .WithMany(t => t.TCangkuKucuns)

                .HasForeignKey(d => d.cangkuid);



        }
    }
}
