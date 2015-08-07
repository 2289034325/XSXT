using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class TTiaomaMap : EntityTypeConfiguration<TTiaoma>
    {
        public TTiaomaMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.tiaoma)
                .IsRequired()
                .HasMaxLength(13);

            this.Property(t => t.kuanhao)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.gongyingshang)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.gyskuanhao)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.pinming)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.yanse)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.chima)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.jinjia)
                .HasPrecision(6,2);

            this.Property(t => t.shoujia)
                .HasPrecision(6,2);

            // Table & Column Mappings
            this.ToTable("TTiaoma");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.tiaoma).HasColumnName("tiaoma");
            this.Property(t => t.kuanhao).HasColumnName("kuanhao");
            this.Property(t => t.gongyingshang).HasColumnName("gongyingshang");
            this.Property(t => t.gyskuanhao).HasColumnName("gyskuanhao");
            this.Property(t => t.leixing).HasColumnName("leixing");
            this.Property(t => t.pinming).HasColumnName("pinming");
            this.Property(t => t.yanse).HasColumnName("yanse");
            this.Property(t => t.chima).HasColumnName("chima");
            this.Property(t => t.jinjia).HasColumnName("jinjia");
            this.Property(t => t.shoujia).HasColumnName("shoujia");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");
        }
    }
}
