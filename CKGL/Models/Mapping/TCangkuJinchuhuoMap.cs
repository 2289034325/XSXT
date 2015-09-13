using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
{
    public class TCangkuJinchuhuoMap : EntityTypeConfiguration<TCangkuJinchuhuo>
    {
        public TCangkuJinchuhuoMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TCangkuJinchuhuo");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fsckid).HasColumnName("fsckid");
            this.Property(t => t.oid).HasColumnName("oid");
            this.Property(t => t.fangxiang).HasColumnName("fangxiang");
            this.Property(t => t.laiyuanquxiang).HasColumnName("laiyuanquxiang");
            this.Property(t => t.gxckid).HasColumnName("gxckid");
            this.Property(t => t.fdid).HasColumnName("fdid");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.zhekou).HasColumnName("zhekou");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.fashengshijian).HasColumnName("fashengshijian");
            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

            // Relationships
            this.HasRequired(t => t.TCangku)
                .WithMany(t => t.TCangkuJinchuhuos)
                .HasForeignKey(d => d.fsckid);
            this.HasOptional(t => t.TCangku1)
                .WithMany(t => t.TCangkuJinchuhuos1)
                .HasForeignKey(d => d.gxckid);
            this.HasOptional(t => t.TFendian)
                .WithMany(t => t.TCangkuJinchuhuos)
                .HasForeignKey(d => d.fdid);
            this.HasOptional(t => t.TJiamengshang)
                .WithMany(t => t.TCangkuJinchuhuos)
                .HasForeignKey(d => d.jmsid);

        }
    }
}
