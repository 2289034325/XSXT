


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TCangkuJinchuhuoMXMap : EntityTypeConfiguration<TCangkuJinchuhuoMX>
    {
        public TCangkuJinchuhuoMXMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            // Table & Column Mappings

            this.ToTable("TCangkuJinchuhuoMX");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.jinchuhuoid).HasColumnName("jinchuhuoid");

            this.Property(t => t.tiaomaid).HasColumnName("tiaomaid");

            this.Property(t => t.danjia).HasColumnName("danjia");

            this.Property(t => t.shuliang).HasColumnName("shuliang");


            // Relationships

            this.HasRequired(t => t.TCangkuJinchuhuo)

                .WithMany(t => t.TCangkuJinchuhuoMXes)

                .HasForeignKey(d => d.jinchuhuoid);

            this.HasRequired(t => t.TTiaoma)

                .WithMany(t => t.TCangkuJinchuhuoMXes)

                .HasForeignKey(d => d.tiaomaid);



        }
    }
}
