


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TFendianKucunMap : EntityTypeConfiguration<TFendianKucun>
    {
        public TFendianKucunMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            // Table & Column Mappings

            this.ToTable("TFendianKucun");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.fendianid).HasColumnName("fendianid");

            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");


            // Relationships

            this.HasRequired(t => t.TFendian)

                .WithMany(t => t.TFendianKucuns)

                .HasForeignKey(d => d.fendianid);



        }
    }
}
