


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TTiaomaMap : EntityTypeConfiguration<TTiaoma>
    {
        public TTiaomaMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

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


            // Table & Column Mappings

            this.ToTable("TTiaoma");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ppsid).HasColumnName("ppsid");

            this.Property(t => t.kuanhaoid).HasColumnName("kuanhaoid");

            this.Property(t => t.gysid).HasColumnName("gysid");

            this.Property(t => t.gyskuanhao).HasColumnName("gyskuanhao");

            this.Property(t => t.tiaoma).HasColumnName("tiaoma");

            this.Property(t => t.yanse).HasColumnName("yanse");

            this.Property(t => t.chima).HasColumnName("chima");

            this.Property(t => t.jinjia).HasColumnName("jinjia");

            this.Property(t => t.shoujia).HasColumnName("shoujia");

            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");

            this.Property(t => t.charushijian).HasColumnName("charushijian");

            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");


            // Relationships

            this.HasRequired(t => t.TGongyingshang)

                .WithMany(t => t.TTiaomas)

                .HasForeignKey(d => d.gysid);

            this.HasRequired(t => t.TKuanhao)

                .WithMany(t => t.TTiaomas)

                .HasForeignKey(d => d.kuanhaoid);

            this.HasRequired(t => t.TPinpaishang)

                .WithMany(t => t.TTiaomas)

                .HasForeignKey(d => d.ppsid);

            this.HasRequired(t => t.TUser)

                .WithMany(t => t.TTiaomas)

                .HasForeignKey(d => d.caozuorenid);



        }
    }
}
