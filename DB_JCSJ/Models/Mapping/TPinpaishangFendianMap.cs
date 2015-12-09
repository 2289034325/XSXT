


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TPinpaishangFendianMap : EntityTypeConfiguration<TPinpaishangFendian>
    {
        public TPinpaishangFendianMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            // Table & Column Mappings

            this.ToTable("TPinpaishangFendian");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ppsid).HasColumnName("ppsid");

            this.Property(t => t.fendianid).HasColumnName("fendianid");


            // Relationships

            this.HasRequired(t => t.TFendian)

                .WithMany(t => t.TPinpaishangFendians)

                .HasForeignKey(d => d.fendianid);

            this.HasRequired(t => t.TPinpaishang)

                .WithMany(t => t.TPinpaishangFendians)

                .HasForeignKey(d => d.ppsid);



        }
    }
}
