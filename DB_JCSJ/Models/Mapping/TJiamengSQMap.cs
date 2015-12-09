


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TJiamengSQMap : EntityTypeConfiguration<TJiamengSQ>
    {
        public TJiamengSQMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            // Table & Column Mappings

            this.ToTable("TJiamengSQ");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ppsid).HasColumnName("ppsid");

            this.Property(t => t.jmsid).HasColumnName("jmsid");

            this.Property(t => t.jieguo).HasColumnName("jieguo");

            this.Property(t => t.charushijian).HasColumnName("charushijian");


            // Relationships

            this.HasRequired(t => t.TJiamengshang)

                .WithMany(t => t.TJiamengSQs)

                .HasForeignKey(d => d.jmsid);

            this.HasRequired(t => t.TPinpaishang)

                .WithMany(t => t.TJiamengSQs)

                .HasForeignKey(d => d.ppsid);



        }
    }
}
