using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
{
    public class THuiyuanMap : EntityTypeConfiguration<THuiyuan>
    {
        public THuiyuanMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.shoujihao)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.xingming)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("THuiyuan");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.fendianid).HasColumnName("fendianid");
            this.Property(t => t.shoujihao).HasColumnName("shoujihao");
            this.Property(t => t.xingming).HasColumnName("xingming");
            this.Property(t => t.xingbie).HasColumnName("xingbie");
            this.Property(t => t.shengri).HasColumnName("shengri");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.jifen).HasColumnName("jifen");
            this.Property(t => t.jfjsshijian).HasColumnName("jfjsshijian");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasRequired(t => t.TFendian)
                .WithMany(t => t.THuiyuans)
                .HasForeignKey(d => d.fendianid);
            this.HasRequired(t => t.TJiamengshang)
                .WithMany(t => t.THuiyuans)
                .HasForeignKey(d => d.jmsid);

        }
    }
}
