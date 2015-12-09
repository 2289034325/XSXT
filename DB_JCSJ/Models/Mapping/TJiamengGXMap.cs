


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TJiamengGXMap : EntityTypeConfiguration<TJiamengGX>
    {
        public TJiamengGXMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            this.Property(t => t.bzmingcheng)
                .IsRequired()
                .HasMaxLength(20);


            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(100);


            // Table & Column Mappings

            this.ToTable("TJiamengGX");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ppsid).HasColumnName("ppsid");

            this.Property(t => t.jmsid).HasColumnName("jmsid");

            this.Property(t => t.bzmingcheng).HasColumnName("bzmingcheng");

            this.Property(t => t.beizhu).HasColumnName("beizhu");

            this.Property(t => t.charushijian).HasColumnName("charushijian");


            // Relationships

            this.HasRequired(t => t.TJiamengshang)

                .WithMany(t => t.TJiamengGXes)

                .HasForeignKey(d => d.jmsid);

            this.HasRequired(t => t.TPinpaishang)

                .WithMany(t => t.TJiamengGXes)

                .HasForeignKey(d => d.ppsid);



        }
    }
}
