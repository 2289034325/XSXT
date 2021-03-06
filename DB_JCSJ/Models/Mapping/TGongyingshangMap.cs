using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TGongyingshangMap : EntityTypeConfiguration<TGongyingshang>
    {
        public TGongyingshangMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.jiancheng)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.mingcheng)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.lianxiren)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.dianhua)
                .IsRequired()
                .HasMaxLength(11);

            this.Property(t => t.dizhi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TGongyingshang");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jiancheng).HasColumnName("jiancheng");
            this.Property(t => t.mingcheng).HasColumnName("mingcheng");
            this.Property(t => t.lianxiren).HasColumnName("lianxiren");
            this.Property(t => t.dianhua).HasColumnName("dianhua");
            this.Property(t => t.dizhi).HasColumnName("dizhi");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.caozuorenid).HasColumnName("caozuorenid");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");

            // Relationships
            this.HasRequired(t => t.TUser)
                .WithMany(t => t.TGongyingshangs)
                .HasForeignKey(d => d.caozuorenid);

        }
    }
}
