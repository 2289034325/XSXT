using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_CK.Models.Mapping
{
    public class TJiamengshangMap : EntityTypeConfiguration<TJiamengshang>
    {
        public TJiamengshangMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.mingcheng)
                .IsRequired()
                .HasMaxLength(20);

            this.Property(t => t.dizhi)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(t => t.lianxiren)
                .IsRequired()
                .HasMaxLength(5);

            this.Property(t => t.dianhua)
                .IsRequired()
                .HasMaxLength(30);

            // Table & Column Mappings
            this.ToTable("TJiamengshang");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.mingcheng).HasColumnName("mingcheng");
            this.Property(t => t.daima).HasColumnName("daima");
            this.Property(t => t.dizhi).HasColumnName("dizhi");
            this.Property(t => t.lianxiren).HasColumnName("lianxiren");
            this.Property(t => t.dianhua).HasColumnName("dianhua");
            this.Property(t => t.zhuangtai).HasColumnName("zhuangtai");
        }
    }
}
