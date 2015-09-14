using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TJiamengshangGXMap : EntityTypeConfiguration<TJiamengshangGX>
    {
        public TJiamengshangGXMap()
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
            this.ToTable("TJiamengshangGX");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dlsid).HasColumnName("dlsid");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.bzmingcheng).HasColumnName("bzmingcheng");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.charushijian).HasColumnName("charushijian");

            // Relationships
            this.HasRequired(t => t.Dls)
                .WithMany(t => t.XjGxes)
                .HasForeignKey(d => d.dlsid);
            this.HasRequired(t => t.Jms)
                .WithMany(t => t.SjGxes)
                .HasForeignKey(d => d.jmsid);

        }
    }
}
