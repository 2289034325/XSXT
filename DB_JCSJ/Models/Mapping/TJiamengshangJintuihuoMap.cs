using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TJiamengshangJintuihuoMap : EntityTypeConfiguration<TJiamengshangJintuihuo>
    {
        public TJiamengshangJintuihuoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("TJiamengshangJintuihuo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dlsid).HasColumnName("dlsid");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.fangxiang).HasColumnName("fangxiang");
            this.Property(t => t.fashengriqi).HasColumnName("fashengriqi");
            this.Property(t => t.zhekou).HasColumnName("zhekou");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasRequired(t => t.Dls)
                .WithMany(t => t.Fahuos)
                .HasForeignKey(d => d.dlsid);
            this.HasRequired(t => t.Jms)
                .WithMany(t => t.Jinhuos)
                .HasForeignKey(d => d.jmsid);
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TJiamengshangJintuihuos)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
