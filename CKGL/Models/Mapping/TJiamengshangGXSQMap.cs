using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
{
    public class TJiamengshangGXSQMap : EntityTypeConfiguration<TJiamengshangGXSQ>
    {
        public TJiamengshangGXSQMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TJiamengshangGXSQ");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dlsid).HasColumnName("dlsid");
            this.Property(t => t.ppid).HasColumnName("ppid");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.jieguo).HasColumnName("jieguo");
            this.Property(t => t.charushijian).HasColumnName("charushijian");

            // Relationships
            this.HasRequired(t => t.TJiamengshang)
                .WithMany(t => t.TJiamengshangGXSQs)
                .HasForeignKey(d => d.dlsid);
            this.HasRequired(t => t.TJiamengshang1)
                .WithMany(t => t.TJiamengshangGXSQs1)
                .HasForeignKey(d => d.jmsid);
            this.HasRequired(t => t.TJiamengshangPinpai)
                .WithMany(t => t.TJiamengshangGXSQs)
                .HasForeignKey(d => d.ppid);

        }
    }
}
