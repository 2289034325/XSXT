using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_CK.Models.Mapping
{
    public class TChurukuMap : EntityTypeConfiguration<TChuruku>
    {
        public TChurukuMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TChuruku");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fangxiang).HasColumnName("fangxiang");
            this.Property(t => t.laiyuanquxiang).HasColumnName("laiyuanquxiang");
            this.Property(t => t.cangkuid).HasColumnName("cangkuid");
            this.Property(t => t.fendianid).HasColumnName("fendianid");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.zhekou).HasColumnName("zhekou");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");
            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");

            // Relationships
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TChurukus)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
