


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TCangkuJinchuhuoMap : EntityTypeConfiguration<TCangkuJinchuhuo>
    {
        public TCangkuJinchuhuoMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            this.Property(t => t.picima)
                .IsRequired()
                .HasMaxLength(8);


            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);


            // Table & Column Mappings

            this.ToTable("TCangkuJinchuhuo");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ckid).HasColumnName("ckid");

            this.Property(t => t.picima).HasColumnName("picima");

            this.Property(t => t.fangxiang).HasColumnName("fangxiang");

            this.Property(t => t.laiyuanquxiang).HasColumnName("laiyuanquxiang");

            this.Property(t => t.zhekou).HasColumnName("zhekou");

            this.Property(t => t.jmsid).HasColumnName("jmsid");

            this.Property(t => t.beizhu).HasColumnName("beizhu");

            this.Property(t => t.fashengshijian).HasColumnName("fashengshijian");

            this.Property(t => t.shangbaoshijian).HasColumnName("shangbaoshijian");


            // Relationships

            this.HasRequired(t => t.TCangku)

                .WithMany(t => t.TCangkuJinchuhuos)

                .HasForeignKey(d => d.ckid);

            this.HasOptional(t => t.TJiamengshang)

                .WithMany(t => t.TCangkuJinchuhuos)

                .HasForeignKey(d => d.jmsid);



        }
    }
}
