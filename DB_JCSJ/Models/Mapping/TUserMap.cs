


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
                .HasMaxLength(20);


            this.Property(t => t.mima)
                .IsRequired()
                .HasMaxLength(16);


            this.Property(t => t.jiqima)
                .IsRequired()
                .HasMaxLength(16);


            this.Property(t => t.yonghuming)
                .IsRequired()
                .HasMaxLength(20);


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

            this.Property(t => t.ppsid).HasColumnName("ppsid");

            this.Property(t => t.jmsid).HasColumnName("jmsid");

            this.Property(t => t.beizhu).HasColumnName("beizhu");

            this.Property(t => t.zhuangtai).HasColumnName("zhuangtai");

            this.Property(t => t.charushijian).HasColumnName("charushijian");

            this.Property(t => t.xiugaishijian).HasColumnName("xiugaishijian");


            // Relationships

            this.HasOptional(t => t.TJiamengshang)

                .WithMany(t => t.TUsers)

                .HasForeignKey(d => d.jmsid);

            this.HasOptional(t => t.TPinpaishang)

                .WithMany(t => t.TUsers)

                .HasForeignKey(d => d.ppsid);



        }
    }
}
