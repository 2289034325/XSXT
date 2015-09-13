using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
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
            this.Property(t => t.ppid).HasColumnName("ppid");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.bzmingcheng).HasColumnName("bzmingcheng");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.charushijian).HasColumnName("charushijian");

            // Relationships
            this.HasRequired(t => t.TJiamengshang)
                .WithMany(t => t.TJiamengshangGXes)
                .HasForeignKey(d => d.dlsid);
            this.HasRequired(t => t.TJiamengshang1)
                .WithMany(t => t.TJiamengshangGXes1)
                .HasForeignKey(d => d.jmsid);
            this.HasRequired(t => t.TJiamengshangPinpai)
                .WithMany(t => t.TJiamengshangGXes)
                .HasForeignKey(d => d.ppid);

        }
    }
}
