using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_JCSJ.Models.Mapping
{
    public class THuiyuanZKMap : EntityTypeConfiguration<THuiyuanZK>
    {
        public THuiyuanZKMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            // Table & Column Mappings
            this.ToTable("THuiyuanZK");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.jifen).HasColumnName("jifen");
            this.Property(t => t.zhekou).HasColumnName("zhekou");
        }
    }
}
