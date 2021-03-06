using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class THuiyuanZKMap : EntityTypeConfiguration<THuiyuanZK>
    {
        public THuiyuanZKMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.jifen)
                .HasPrecision(10,2);

            this.Property(t => t.zhekou)
                .HasPrecision(4,2);

            // Table & Column Mappings
            this.ToTable("THuiyuanZK");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jifen).HasColumnName("jifen");
            this.Property(t => t.zhekou).HasColumnName("zhekou");
            this.Property(t => t.gengxinshijian).HasColumnName("gengxinshijian");
        }
    }
}
