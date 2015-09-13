using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TPinpaiMap : EntityTypeConfiguration<TPinpai>
    {
        public TPinpaiMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.mingcheng)
                .IsRequired()
                .HasMaxLength(20);

            // Table & Column Mappings
            this.ToTable("TPinpai");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.mingcheng).HasColumnName("mingcheng");
            this.Property(t => t.kejiameng).HasColumnName("kejiameng");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasRequired(t => t.TJiamengshang)
                .WithMany(t => t.TPinpais)
                .HasForeignKey(d => d.jmsid);

        }
    }
}
