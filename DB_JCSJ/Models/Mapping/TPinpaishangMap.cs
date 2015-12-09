


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TPinpaishangMap : EntityTypeConfiguration<TPinpaishang>
    {
        public TPinpaishangMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            this.Property(t => t.mingcheng)
                .IsRequired()
                .HasMaxLength(20);


            this.Property(t => t.shoujihao)
                .IsRequired()
                .HasMaxLength(11);


            this.Property(t => t.youxiang)
                .IsRequired()
                .HasMaxLength(50);


            this.Property(t => t.dizhi)
                .IsRequired()
                .HasMaxLength(50);


            this.Property(t => t.lianxiren)
                .IsRequired()
                .HasMaxLength(20);


            this.Property(t => t.dianhua)
                .IsRequired()
                .HasMaxLength(50);


            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(100);


            this.Property(t => t.dtyzm)
                .IsRequired()
                .HasMaxLength(6);


            // Table & Column Mappings

            this.ToTable("TPinpaishang");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.mingcheng).HasColumnName("mingcheng");

            this.Property(t => t.daima).HasColumnName("daima");

            this.Property(t => t.shoujihao).HasColumnName("shoujihao");

            this.Property(t => t.youxiang).HasColumnName("youxiang");

            this.Property(t => t.diquid).HasColumnName("diquid");

            this.Property(t => t.dizhi).HasColumnName("dizhi");

            this.Property(t => t.lianxiren).HasColumnName("lianxiren");

            this.Property(t => t.dianhua).HasColumnName("dianhua");

            this.Property(t => t.beizhu).HasColumnName("beizhu");

            this.Property(t => t.zhanghaoshu).HasColumnName("zhanghaoshu");

            this.Property(t => t.kuanhaoshu).HasColumnName("kuanhaoshu");

            this.Property(t => t.tiaomashu).HasColumnName("tiaomashu");

            this.Property(t => t.cangkushu).HasColumnName("cangkushu");

            this.Property(t => t.jchjilushu).HasColumnName("jchjilushu");

            this.Property(t => t.kcjilushu).HasColumnName("kcjilushu");

            this.Property(t => t.jmsshu).HasColumnName("jmsshu");

            this.Property(t => t.gysshu).HasColumnName("gysshu");

            this.Property(t => t.dtyzm).HasColumnName("dtyzm");

            this.Property(t => t.charushijian).HasColumnName("charushijian");

            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");


            // Relationships

            this.HasRequired(t => t.TDiqu)

                .WithMany(t => t.TPinpaishangs)

                .HasForeignKey(d => d.diquid);



        }
    }
}
