


using System.ComponentModel.DataAnnotations.Schema;

using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TKuanhaoMap : EntityTypeConfiguration<TKuanhao>
    {
        public TKuanhaoMap()
        {
            // Primary Key

            this.HasKey(t => t.id);


            // Properties

            this.Property(t => t.kuanhao)
                .IsRequired()
                .HasMaxLength(20);


            this.Property(t => t.pinming)
                .IsRequired()
                .HasMaxLength(6);


            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);


            // Table & Column Mappings

            this.ToTable("TKuanhao");

            this.Property(t => t.id).HasColumnName("id");

            this.Property(t => t.ppsid).HasColumnName("ppsid");

            this.Property(t => t.kuanhao).HasColumnName("kuanhao");

            this.Property(t => t.leixing).HasColumnName("leixing");

            this.Property(t => t.xingbie).HasColumnName("xingbie");

            this.Property(t => t.pinming).HasColumnName("pinming");

            this.Property(t => t.beizhu).HasColumnName("beizhu");

            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");

            this.Property(t => t.charushijian).HasColumnName("charushijian");

            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");


            // Relationships

            this.HasRequired(t => t.TPinpaishang)

                .WithMany(t => t.TKuanhaos)

                .HasForeignKey(d => d.ppsid);

            this.HasRequired(t => t.TUser)

                .WithMany(t => t.TKuanhaos)

                .HasForeignKey(d => d.caozuorenid);



        }
    }
}
