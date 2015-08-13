using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TFendianMap : EntityTypeConfiguration<TFendian>
    {
        public TFendianMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.dianming)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.dizhi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.lianxiren)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.dianhua)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TFendian");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.dianming).HasColumnName("dianming");
            this.Property(t => t.fzxingbie).HasColumnName("fzxingbie");
            this.Property(t => t.fzleixing).HasColumnName("fzleixing");
            this.Property(t => t.mianji).HasColumnName("mianji");
            this.Property(t => t.keliuliang).HasColumnName("keliuliang");
            this.Property(t => t.dangci).HasColumnName("dangci");
            this.Property(t => t.dpxingzhi).HasColumnName("dpxingzhi");
            this.Property(t => t.zhuanrangfei).HasColumnName("zhuanrangfei");
            this.Property(t => t.yuezu).HasColumnName("yuezu");
            this.Property(t => t.dizhi).HasColumnName("dizhi");
            this.Property(t => t.lianxiren).HasColumnName("lianxiren");
            this.Property(t => t.dianhua).HasColumnName("dianhua");
            this.Property(t => t.kaidianriqi).HasColumnName("kaidianriqi");
            this.Property(t => t.zhuangtai).HasColumnName("zhuangtai");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasRequired(t => t.TJiamengshang)
                .WithMany(t => t.TFendians)
                .HasForeignKey(d => d.jmsid);
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TFendians)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
