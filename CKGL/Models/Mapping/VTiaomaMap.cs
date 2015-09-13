using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace CKGL.Models.Mapping
{
    public class VTiaomaMap : EntityTypeConfiguration<VTiaoma>
    {
        public VTiaomaMap()
        {
            // Primary Key
            this.HasKey(t => new { t.id, t.jmsid, t.jms, t.ppid, t.pinpai, t.kuanhaoid, t.kuanhao, t.leixing, t.pinming, t.gysid, t.gys, t.gyskuanhao, t.tiaoma, t.yanse, t.chima, t.jinjia, t.shoujia, t.caozuorenid, t.charushijian, t.xiugaishijian });

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.jmsid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.jms)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.ppid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.pinpai)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.kuanhaoid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.kuanhao)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.pinming)
                .IsRequired()
                .HasMaxLength(6);

            this.Property(t => t.gysid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.gys)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.gyskuanhao)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.tiaoma)
                .IsRequired()
                .HasMaxLength(13);

            this.Property(t => t.yanse)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.chima)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.jinjia)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.shoujia)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.caozuorenid)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            // Table & Column Mappings
            this.ToTable("VTiaoma");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.laiyuan).HasColumnName("laiyuan");
            this.Property(t => t.jmsid).HasColumnName("jmsid");
            this.Property(t => t.jms).HasColumnName("jms");
            this.Property(t => t.ppid).HasColumnName("ppid");
            this.Property(t => t.pinpai).HasColumnName("pinpai");
            this.Property(t => t.kuanhaoid).HasColumnName("kuanhaoid");
            this.Property(t => t.kuanhao).HasColumnName("kuanhao");
            this.Property(t => t.leixing).HasColumnName("leixing");
            this.Property(t => t.pinming).HasColumnName("pinming");
            this.Property(t => t.gysid).HasColumnName("gysid");
            this.Property(t => t.gys).HasColumnName("gys");
            this.Property(t => t.gyskuanhao).HasColumnName("gyskuanhao");
            this.Property(t => t.tiaoma).HasColumnName("tiaoma");
            this.Property(t => t.yanse).HasColumnName("yanse");
            this.Property(t => t.chima).HasColumnName("chima");
            this.Property(t => t.jinjia).HasColumnName("jinjia");
            this.Property(t => t.shoujia).HasColumnName("shoujia");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");
        }
    }
}
