using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class TUserMap : EntityTypeConfiguration<TUser>
    {
        public TUserMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.dengluming)
                .IsRequired()
                .HasMaxLength(10);

            this.Property(t => t.mima)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.jiqima)
                .IsRequired()
                .HasMaxLength(16);

            this.Property(t => t.yonghuming)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.beizhu)
                .IsRequired()
                .HasMaxLength(50);

            // Table & Column Mappings
            this.ToTable("TUser");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.dengluming).HasColumnName("dengluming");
            this.Property(t => t.mima).HasColumnName("mima");
            this.Property(t => t.jiqima).HasColumnName("jiqima");
            this.Property(t => t.yonghuming).HasColumnName("yonghuming");
            this.Property(t => t.juese).HasColumnName("juese");
            this.Property(t => t.beizhu).HasColumnName("beizhu");
            this.Property(t => t.zhuangtai).HasColumnName("zhuangtai");
            this.Property(t => t.charushijian).HasColumnName("charushijian");
            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");
        }
    }
}
