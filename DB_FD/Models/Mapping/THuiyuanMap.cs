using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace DB_FD.Models.Mapping
{
    public class THuiyuanMap : EntityTypeConfiguration<THuiyuan>
    {
        public THuiyuanMap()
        {
            // Primary Key
            this.HasKey(t => t.id);

            // Properties
            this.Property(t => t.id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);

            this.Property(t => t.shoujihao)
                .IsRequired()
                .HasMaxLength(13);

            this.Property(t => t.xingming)
                .IsRequired()
                .HasMaxLength(5);

            // Table & Column Mappings
            this.ToTable("THuiyuan");
            this.Property(t => t.id).HasColumnName("id");
            this.Property(t => t.fendianid).HasColumnName("fendianid");
            this.Property(t => t.shoujihao).HasColumnName("shoujihao");
            this.Property(t => t.xingming).HasColumnName("xingming");
            this.Property(t => t.xingbie).HasColumnName("xingbie");
            this.Property(t => t.shengri).HasColumnName("shengri");
            this.Property(t => t.jifen).HasColumnName("jifen");
            this.Property(t => t.jfgxshijian).HasColumnName("jfgxshijian");
            this.Property(t => t.xxgxshijian).HasColumnName("xxgxshijian");
        }
    }
}
