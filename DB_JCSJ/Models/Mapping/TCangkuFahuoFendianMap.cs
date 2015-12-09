


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TCangkufahuoFendianMap : EntityTypeConfiguration<TCangkufahuoFendian>
    {
        public TCangkufahuoFendianMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            // Table & Column Mappings

            this.ToTable("TCangkufahuoFendian");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ckjinchuid).HasColumnName("ckjinchuid");

            this.Property(t => t.fendianid).HasColumnName("fendianid");


            // Relationships

            this.HasRequired(t => t.TCangkuJinchuhuo)

                .WithMany(t => t.TCangkufahuoFendians)

                .HasForeignKey(d => d.ckjinchuid);

            this.HasRequired(t => t.TFendian)

                .WithMany(t => t.TCangkufahuoFendians)

                .HasForeignKey(d => d.fendianid);



        }
    }
}
